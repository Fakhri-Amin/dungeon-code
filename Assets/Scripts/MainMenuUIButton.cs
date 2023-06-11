using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuUIButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup parentUI;
    [SerializeField] private CanvasGroup targetUI;

    // Start is called before the first frame update
    public void EnableTargetUI()
    {
        parentUI.gameObject.SetActive(false);
        targetUI.gameObject.SetActive(true);
        targetUI.alpha = 0;
        targetUI.DOFade(1, 0.3f);
    }
}
