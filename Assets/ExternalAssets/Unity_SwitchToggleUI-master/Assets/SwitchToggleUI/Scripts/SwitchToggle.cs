using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using MG_BlocksEngine2.Environment;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;
    [SerializeField] string settingName;

    Image backgroundImage, handleImage;

    Color backgroundDefaultColor, handleDefaultColor;

    Toggle toggle;

    Vector2 handlePosition;

    void Start()
    {
        toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;


        toggle.onValueChanged.AddListener(OnSwitch);

        if (settingName == "music")
        {
            if (GameMusicPlayer.Instance.isMusicOn)
            {
                OnSwitch(true);
            }
            else
            {
                OnSwitch(false);
            }
        }
        else if (settingName == "sfx")
        {
            if (GameMusicPlayer.Instance.isSFXOn)
            {
                OnSwitch(true);
            }
            else
            {
                OnSwitch(false);
            }
        }

    }

    void OnSwitch(bool on)
    {
        //uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition ; // no anim
        uiHandleRectTransform.DOAnchorPos(on ? handlePosition * -1 : handlePosition, .4f).SetEase(Ease.InOutBack);

        //backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor ; // no anim
        backgroundImage.DOColor(on ? backgroundActiveColor : backgroundDefaultColor, .6f);

        //handleImage.color = on ? handleActiveColor : handleDefaultColor ; // no anim
        handleImage.DOColor(on ? handleActiveColor : handleDefaultColor, .4f);

        if (settingName == "music")
        {
            GameMusicPlayer.Instance.isMusicOn = on ? true : false;
            GameMusicPlayer.Instance.GetComponent<AudioSource>().mute = !GameMusicPlayer.Instance.isMusicOn;
        }
        else if (settingName == "sfx")
        {
            GameMusicPlayer.Instance.isSFXOn = on ? true : false;
            BE2_AudioManager.instance.GetComponent<AudioSource>().mute = !GameMusicPlayer.Instance.isSFXOn;
        }
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
