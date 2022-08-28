using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EventManager
{
    public static event System.Action<Chips> OnClean;
    public static void Fire_OnClean(Chips chips) { OnClean?.Invoke(chips); }
}

public class Chips : MonoBehaviour
{
    Transform mT;

    private void Awake()
    {
        mT = transform;

        GameManager.chipsAmount++;
    }

    public void OnClean()
    {
        GetComponent<CapsuleCollider>().enabled = false;

        CleanCompleted();

        mT.DOScale(Vector3.zero, 0.5f);

        Destroy(gameObject, 1);
    }

    void CleanCompleted()
    {
        GameManager.chipsAmount--;

        if (GameManager.chipsAmount<=0)
        {
            EventManager.Fire_OnChangeVacuum();
        }
    }

}
