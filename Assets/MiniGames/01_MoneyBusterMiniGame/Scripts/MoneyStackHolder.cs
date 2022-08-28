using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyStackHolder : MonoBehaviour
{
    public static Animator mAnim;

    private void Awake()
    {
        mAnim = GetComponent<Animator>();

    }

    public static void OnSuccessAnim()
    {
        mAnim.SetTrigger("success");
    }

}
