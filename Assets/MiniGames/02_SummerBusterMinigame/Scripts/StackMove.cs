using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackMove : MonoBehaviour
{
    Vector3 gap;
    
    public int goPose;

    public static List<Vector3> poses= new List<Vector3>();

    public static List<Vector3> headPoses= new List<Vector3>();


    void Poses()
    { 
        poses.Clear();
        headPoses.Clear();

        for (int i = -1; i < 2; i++)
        {
            headPoses.Add(new Vector3(i * 5, 8, 0));

            for (int j = 0; j < 3; j++)
            {
                
                poses.Add( new Vector3(i * 5, (float)(1 + j*1.75f), 0));
                
            }
            
        }
    }

    private void Awake()
    {
        Poses();

        
    }


    bool moveDone = false;

    void OnMouseDown()
    {
        gap = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position + HeadPose(poses[goPose]) - poses[goPose]);
        transform.DOMove(HeadPose(transform.position), 0.2f);
        Delay.WaitForMe(() => moveDone = true, 0.2f);

    }

    Vector3 HeadPose(Vector3 pos)
    {
        return new Vector3(pos.x, 8, 0);

    }

    void OnMouseDrag()
    {
        if (!moveDone) return;

        Vector3 smooth = Camera.main.ScreenToWorldPoint(Input.mousePosition - gap);
        transform.position = Vector3.MoveTowards(transform.position, smooth, 0.5f);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), Mathf.Clamp(transform.position.y, 8, 25), Mathf.Clamp(transform.position.z, -20, 20));

    }

    

    private void OnMouseUp()
    {
        moveDone = false;
        transform.DOMove(HeadPose(poses[goPose]), 0.4f);
        
        Delay.WaitForMe(() => transform.DOMove(poses[goPose], 0.2f), 0.4f);
    }
}
