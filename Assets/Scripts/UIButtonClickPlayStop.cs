using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MG_BlocksEngine2.Environment;

public class UIButtonClickPlayStop : MonoBehaviour
{
    [SerializeField] private GameObject targetButton;
    [SerializeField] private string buttonName;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            targetButton.SetActive(true);
            gameObject.SetActive(false);
            BE2_AudioManager.instance.PlaySound(0);

            if (buttonName == "play") return;
            GameManager.Instance.ResetPlayerPosition();
        });
    }
}
