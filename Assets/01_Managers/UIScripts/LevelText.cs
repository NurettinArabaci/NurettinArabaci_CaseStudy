using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public partial class LevelText : MonoBehaviour
{
    TextMeshProUGUI levelText;


    private void Awake()
    {
        transform.DOMoveY(-200, 0.01f);
        levelText = GetComponent<TextMeshProUGUI>();
        levelText.text = Tags.Level+" "+(LevelManager.Level+1).ToString();
        EventManager.OnLevelCompleted += LevelUpgrade;
        EnabledOnOff(false);
    }

    void LevelUpgrade()
    {
        EnabledOnOff(true);
        levelText.text = Tags.Level + " " + (LevelManager.Level + 1).ToString();
        
        transform.DOMoveY(1200, 1f);
        NAEngine.Delay(() => EnabledOnOff(false), 3);
        NAEngine.Delay(() => transform.DOMoveY(-200, 0.5f), 2);

        EventManager.Fire_OnCoinUpdate(30);
    }

    protected virtual void EnabledOnOff(bool _state)
    {
        foreach (var item in GetComponentsInChildren<TextMeshProUGUI>())
        {
            item.enabled = _state;
        }
        
    }

    private void OnDisable() => EventManager.OnLevelCompleted -= LevelUpgrade;
}
