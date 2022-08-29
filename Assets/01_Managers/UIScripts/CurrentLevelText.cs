using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public partial class EventManager
{
    public static event System.Action<bool> OnLevelTextVisible;
    public static void Fire_OnLevelTextVisible(bool state) { OnLevelTextVisible?.Invoke(state); }
}
public class CurrentLevelText : MonoBehaviour
{

    TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        EventManager.OnLevelTextVisible += OnLevelTextVisible;

        TextUpdate();
        
    }

    public void TextUpdate()
    {
        _text.text = Tags.Level+" "+(LevelManager.Level + 1).ToString();
    }

    public void OnLevelTextVisible(bool _state)
    {
        TextUpdate();
        _text.enabled = _state;
    }

    private void OnDisable()
    {
        EventManager.OnLevelTextVisible -= OnLevelTextVisible;
    }
}


