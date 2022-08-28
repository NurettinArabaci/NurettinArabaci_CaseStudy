using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : MonoBehaviour
{
    Vector2 firstPose, secPose,endPose;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            firstPose = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            secPose = Input.mousePosition;
            Debug.Log(WhichArrow());

        }
  
        
    }


    ArrowType WhichArrow()
    {
        endPose = secPose - firstPose;

        if (Mathf.Abs(endPose.x) > Mathf.Abs(endPose.y))
        {
            if (endPose.x > 0)
            {
                return ArrowType.Right;
            }
            else return ArrowType.Left;
        }
        else if (Mathf.Abs(endPose.x) < Mathf.Abs(endPose.y))
        {
            if (endPose.y > 0)
            {
                return ArrowType.Up;
            }
            else
                return ArrowType.Down;
        }
        else
            return ArrowType.None;
    } 

    protected void OpenMessagePanelAnimEvent()
    {
        EventManager.Fire_OnMessageActive();
        
    }

    protected void CloseMessagePanelAnimEvent()
    {
        EventManager.Fire_OnMessageInActive();
    }
}
