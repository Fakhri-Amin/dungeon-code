using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private Transform box;
    [SerializeField] private CanvasGroup background;

    private void OnEnable()
    {
        // LeanTween.cancel(gameObject);
        background.alpha = 0;
        box.localPosition = new Vector3(0, -Screen.height, box.localPosition.z);

        // LeanTween
        // LeanTween.alphaCanvas(background, 1.0f, 0.5f);
        // box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;

        // DoTween
        background.DOFade(1, 0.5f);
        box.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutExpo).SetDelay(0.1f);
    }

    public void CloseDialog()
    {
        // LeanTween
        // background.LeanAlpha(0, 0.5f);
        // box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);

        // DoTween
        background.DOFade(0, 0.5f);
        box.DOLocalMoveY(-Screen.height, 0.5f).SetEase(Ease.InExpo).OnComplete(OnceComplete);

    }

    private void OnceComplete()
    {
        gameObject.SetActive(false);
    }
}
