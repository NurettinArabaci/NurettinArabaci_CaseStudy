using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public partial class EventManager
{
    public static event System.Action<int> OnCoinUpdate;
    public static void Fire_OnCoinUpdate(int value) { OnCoinUpdate?.Invoke(value); }

    public static event System.Action<bool> OnCoinVisible;
    public static void Fire_OnCoinVisible(bool state) { OnCoinVisible?.Invoke(state); }
}
public class CoinManager : MonoBehaviour
{
    TextMeshProUGUI coinText;

    public static int Coin
    {
        get { return PlayerPrefs.GetInt(Tags.Coin, 0); }
        set { PlayerPrefs.SetInt(Tags.Coin, value); }
    }

    private void Awake()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        EventManager.OnCoinUpdate += OnCoinUpdate;
        coinText.text = Coin.ToString();

        EventManager.OnCoinVisible += OnCoinVisible;

    }

    void OnCoinVisible(bool _state)
    {
        coinText.enabled = _state;
        transform.GetChild(0).gameObject.SetActive(_state);
    }

    void OnCoinUpdate(int _value)
    {
        Coin += _value;
        SpawnCoinUpgradeText(_value);
        NAEngine.Delay(() => coinText.text = Coin.ToString(), 0.2f);
        transform.DOShakeScale(0.4f, 0.2f);
    }

    void SpawnCoinUpgradeText(float value)
    {
        if (value != 0)
        {
            
            GameObject go = Instantiate(Resources.Load<GameObject>("CoinUpgradeText"), transform.parent);
            go.transform.DOMoveY(go.transform.position.y + 100, 1);

            TextMeshProUGUI tmproUI;
            tmproUI = go.GetComponent<TextMeshProUGUI>();
            tmproUI.text = value.ToString();

            if (value > 0)
            {
                tmproUI.color = Color.green;
            }else
                tmproUI.color = Color.red;

            tmproUI.DOColor(Color.clear, 1f);

            Destroy(go, 1.5f);
        }
        
    }

    private void OnDisable()
    {
        EventManager.OnCoinUpdate -= OnCoinUpdate;
        EventManager.OnCoinVisible -= OnCoinVisible;
    }


}
