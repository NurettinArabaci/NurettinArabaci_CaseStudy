using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MoneyType
{
    Fake,
    Real
}

public class Money : MovementController
{
    public MoneyType moneyType;

    bool isFinish = false;

    private void Start()
    {
        moveHeight = 0;
        maxZ = 5;
    }

    protected override void OnMouseUp()
    {
        if (!isFinish)
        {
            base.OnMouseUp();
        }
        
    }

    protected override void OnMouseDrag()
    {
        if (!isFinish)
        {
            base.OnMouseDrag();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(Tags.MoneyHolder))
        {
            MoveAnimation(other.transform, AnimParam.MoneyStack);
            if (moneyType == MoneyType.Real)
            {
                EventManager.Fire_OnCoinUpdate(30);
            }
            else if (moneyType == MoneyType.Fake)
            {

                EventManager.Fire_OnCoinUpdate(-30);
            }
        }

        else if (other.CompareTag(Tags.PaperShredder))
        {

            other.transform.DOShakePosition(1.2f,0.7f);

            MoveAnimation(other.transform, AnimParam.MoneyShredStart);

            other.GetComponentInChildren<ParticleSystem>().Play();

            if (moneyType == MoneyType.Fake)
            {
                EventManager.Fire_OnCoinUpdate(30);
            }
            else if (moneyType == MoneyType.Real)
            {

                EventManager.Fire_OnCoinUpdate(-30);
            }



        }
    }

    

    void MoveAnimation(Transform tr, string animParam)
    {
        isFinish = true;
        GetComponent<BoxCollider>().enabled = false;
        mT.DORotate(Vector3.up * (-90), 0.2f);
        NAEngine.DoubleCheckpointMove(mT, tr.position + Vector3.back * 10, tr.position, 500, 20);
        tr.GetComponent<Animator>().SetTrigger(animParam);

        NAEngine.Delay(() => EventManager.Fire_OnLevelCompleted(), 2);

        Destroy(gameObject, 1.6f);

    }



}