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

    bool changed = false;

    protected override void Awake()
    {
        base.Awake();

        EventManager.OnChangeVacuum += OnChangeVacuum;

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
        
        Destroy(gameObject, 3f);
    }

    protected override void OnMouseDrag()
    {
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
            Chips chips = other.GetComponent<Chips>();

            chips.OnClean();
        }
    }

    private void OnDisable()
    {
        EventManager.OnChangeVacuum -= OnChangeVacuum;
    }
}
