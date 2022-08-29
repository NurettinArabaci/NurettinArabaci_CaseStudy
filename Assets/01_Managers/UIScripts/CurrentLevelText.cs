using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentLevelText : MonoBehaviour
{
    static TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

        TextUpdate();
        
    }

    static void TextUpdate()
    {
        _text.text = Tags.Level+" "+(LevelManager.Level + 1).ToString();
    }

    public static void Visible(bool _state)
    {
        TextUpdate();
        _text.enabled = _state;
    }
}
