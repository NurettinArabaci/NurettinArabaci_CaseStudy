using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woman : MonoBehaviour
{
    static bool isPlay;
    Vector2 firstPose, secPose,endPose;

    Animator mAnim;

    private void Awake()
    {
        isPlay = false;
        mAnim = GetComponent<Animator>();
        EventManager.OnStartGame += () => isPlay = true;
    }

    private void Update()
    {
        if (!isPlay) return;

        PlayGame();
    }

    void CheckCorrect()
    {
        if (BoxStroke.arrows.Count <= 0)
        {
            Incorrect();
        }
        else
        {
            if (BoxStroke.arrows[0].arrowType == WhichArrow())
            {
                Correct();
                BoxStroke.arrows[0].CorrectEffect();
            }
            else
            {
                Incorrect();
            }
        }
    }

    void PlayGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPose = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            secPose = Input.mousePosition;

            CheckCorrect();
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
            else
                return ArrowType.Left;
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


    string AnimationParameter()
    {
        switch (WhichArrow())
        {
            case ArrowType.Up:
                return "Pose_1";

            case ArrowType.Down:
                return "Pose_2";

            case ArrowType.Right:
                return "Pose_3";

            case ArrowType.Left:
                return "Pose_4";

            default:
                return "None"; 
        }
    }

    void Correct()
    {
        mAnim.SetTrigger(AnimationParameter());
        EventManager.Fire_OnCoinUpdate(10);
        EventManager.Fire_OnCorrect();
    }

    void Incorrect()
    {
        EventManager.Fire_OnWrong();
    }

    private void OnDisable() => EventManager.OnStartGame -= () => isPlay=true;

}
