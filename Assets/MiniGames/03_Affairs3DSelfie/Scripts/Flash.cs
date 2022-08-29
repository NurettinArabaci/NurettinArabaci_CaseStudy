using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Flash : MonoBehaviour
{
    static Image flash;
    static Color shineColor, transparentColor;

    private void Awake()
    {
        flash = GetComponent<Image>();
        shineColor = new Color(1, 1, 1, 0.4f);
        transparentColor = new Color(1, 1, 1, 0f);
    }



    public static void FlashEffect()
    {
        flash.DOColor(shineColor, 0.06f);
        NAEngine.Delay(() => flash.DOColor(transparentColor, 0.06f), 0.1f);
    }
}
