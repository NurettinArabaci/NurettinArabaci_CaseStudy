using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanAnimationEvent : MonoBehaviour
{
    List<GameObject> poses = new List<GameObject>();

    private void Awake()
    {
        poses.Clear();

        foreach (var item in Resources.LoadAll<GameObject>("AffairsPoses"))
        {
            poses.Add(item);
        }
    }

    protected void OpenMessagePanelAnimEvent()
    {
        EventManager.Fire_OnMessageActive();

    }

    protected void CloseMessagePanelAnimEvent()
    {
        EventManager.Fire_OnStartGame();
    }

    protected void CreatePose1()
    {
        EventManager.Fire_OnSpawnPicture(poses[0]);
    }
    protected void CreatePose2()
    {
        EventManager.Fire_OnSpawnPicture(poses[1]);
    }
    protected void CreatePose3()
    {
        EventManager.Fire_OnSpawnPicture(poses[2]);
    }
    protected void CreatePose4()
    {
        EventManager.Fire_OnSpawnPicture(poses[3]);
    }
}
