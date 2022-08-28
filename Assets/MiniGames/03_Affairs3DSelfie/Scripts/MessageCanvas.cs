using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EventManager
{
    public static event System.Action OnMessageActive;
    public static void Fire_OnMessageActive() { OnMessageActive?.Invoke(); }

    public static event System.Action OnMessageInActive;
    public static void Fire_OnMessageInActive() { OnMessageInActive?.Invoke(); }
}

public class MessageCanvas : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnMessageActive += OnMessageActive;
        EventManager.OnMessageInActive += OnMessageInActive;


    }

    void OnMessageActive()
    {
        NAEngine.ChildActive_Wait(transform, 1, true, 0.5f);

    }

    void OnMessageInActive()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.DOScale(0, 0.3f);
        }
        Destroy(gameObject, 0.5f);
    }


    private void OnDisable()
    {
        EventManager.OnMessageActive -= OnMessageActive;
        EventManager.OnMessageInActive -= OnMessageInActive;
    }
}
