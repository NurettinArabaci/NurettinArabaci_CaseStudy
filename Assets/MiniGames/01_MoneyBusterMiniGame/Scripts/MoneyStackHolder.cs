using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EventManager
{
    public static event System.Action OnSuccessAnim;
    public static void Fire_OnSuccessAnim() { OnSuccessAnim?.Invoke(); }
}

public class MoneyStackHolder : MonoBehaviour
{
    Animator mAnim;

    private void Awake()
    {
        mAnim = GetComponent<Animator>();

        EventManager.OnSuccessAnim += OnSuccessAnim;
    }

    void OnSuccessAnim()
    {
        mAnim.SetTrigger("success");
    }

    private void OnDisable()
    {
        EventManager.OnSuccessAnim -= OnSuccessAnim;
    }
}
