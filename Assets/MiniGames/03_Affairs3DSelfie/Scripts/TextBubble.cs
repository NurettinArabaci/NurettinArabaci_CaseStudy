using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextBubble : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }
}
