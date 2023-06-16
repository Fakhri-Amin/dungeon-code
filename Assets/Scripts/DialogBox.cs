using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private Transform[] boxes;
    [SerializeField] private CanvasGroup background;

    private void OnEnable()
    {
        // LeanTween.cancel(gameObject);
        background.alpha = 0;
        foreach (var box in boxes)
        {
            box.localPosition = new Vector3(box.localPosition.x, -Screen.height, box.localPosition.z);
        }

        // LeanTween
        // LeanTween.alphaCanvas(background, 1.0f, 0.5f);
        // box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;

        // DoTween
        background.DOFade(1, 0.5f);
        foreach (var box in boxes)
        {
            box.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutExpo).SetDelay(0.1f);
        }
    }

    public void CloseDialog()
    {
        // LeanTween
        // background.LeanAlpha(0, 0.5f);
        // box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);

        // DoTween
        background.DOFade(0, 0.5f);
        foreach (var box in boxes)
        {
            box.DOLocalMoveY(-Screen.height, 0.5f).SetEase(Ease.InExpo).OnComplete(OnceComplete);
        }
    }

    private void OnceComplete()
    {
        gameObject.SetActive(false);
    }
}
