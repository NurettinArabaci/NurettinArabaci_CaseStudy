using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EventManager
{
    public static event System.Action OnChangeVacuum;
    public static void Fire_OnChangeVacuum() { OnChangeVacuum?.Invoke(); }
}
public class HandHeldVacuum : MovementController
{
    Vector3 lookPose;

    static bool changed;

    protected override void Awake()
    {
        EventManager.OnChangeVacuum += OnChangeVacuum;
        base.Awake();
        changed = false;

        lookPose = new Vector3(-5f, 0f, 4f);

        moveHeight = 3f;
        minZ = -9f;
        maxX = -1f;

    }

    void OnChangeVacuum()
    {
        changed = true;
        GetComponent<Collider>().enabled = false;
        NAEngine.MoveBySpeed(mT, Vector3.up * 20, 100);

        EventManager.Fire_OnCoinUpdate(50);

        Destroy(gameObject, 1f);
    }

    protected override void OnMouseDrag()
    {
        if (changed) return;
        base.OnMouseDrag();
        mT.LookAt(lookPose);
       
    }

    protected override void OnMouseUp()
    {
        if (changed) return;
        base.OnMouseUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chips"))
        {
            other.GetComponent<Chips>().OnClean();           
        }
    }

    private void OnDisable()
    {
        EventManager.OnChangeVacuum -= OnChangeVacuum;
    }
}
