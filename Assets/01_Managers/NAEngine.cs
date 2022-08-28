using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAEngine : MonoBehaviour
{
    static NAEngine instance_;


    public static NAEngine instance
    {
        get
        {
            if (instance_)
                return instance_;
            else
            {
                instance_ = new GameObject("NAEngine").AddComponent<NAEngine>();
                return instance_;
            }
        }
    }


    /// <summary>
    /// This method can delay any method you want.
    /// </summary>
    public static Coroutine Delay(System.Action action, float duration)
    {
        return instance.StartCoroutine(instance.DelayCR(action, duration));
    }

    IEnumerator DelayCR(System.Action _action, float _duration)
    {
        yield return new WaitForSeconds(_duration);
        _action?.Invoke();
    }


    /// <summary>
    /// You can move to target position from the current position.
    /// </summary>
    public static Coroutine MoveBySpeed(Transform tr, Vector3 targetPose, float speed)
    {
        return instance.StartCoroutine(instance.MoveBySpeedCR(tr, targetPose, speed));
    }

    IEnumerator MoveBySpeedCR(Transform _tr, Vector3 _targetPose, float _speed)
    {
        Vector3 _currentPose = _tr.position;
        float timeCounter = 0f;

        while (_targetPose != _currentPose)
        {
            //Change position
            timeCounter += Time.deltaTime;
            _tr.position = Vector3.MoveTowards(_currentPose, _targetPose, timeCounter * _speed * Time.deltaTime);
            _currentPose = _tr.position;

            yield return null;
        }
    }


    /// <summary>
    /// You can move to two different points in order.
    /// Firstly the first position from the current position.
    /// Then the second position from the first position.
    /// </summary>

    public static Coroutine DoubleCheckpointMove(Transform tr, Vector3 firstPose, Vector3 secPose, float firstSpeed, float secSpeed)
    {
        return instance.StartCoroutine(instance.DoubleCheckpointMoveCR(tr, firstPose, secPose, firstSpeed, secSpeed));
    }

    IEnumerator DoubleCheckpointMoveCR(Transform _tr, Vector3 _firstPose, Vector3 _secPose, float _firstSpeed, float _secSpeed)
    {

        Vector3 _currentPose = _tr.position;
        float timeCounter = 0f;

        while (_firstPose != _currentPose)
        {
            //Change position
            timeCounter += Time.deltaTime;
            _tr.position = Vector3.MoveTowards(_currentPose, _firstPose, timeCounter * _firstSpeed * Time.deltaTime);
            _currentPose = _tr.position;

            yield return null;
        }

        while (_secPose != _firstPose)
        {
            //Change position
            timeCounter += Time.deltaTime;
            _tr.position = Vector3.MoveTowards(_firstPose, _secPose, timeCounter * _secSpeed * Time.deltaTime);
            _firstPose = _tr.position;

            yield return null;
        }

    }

    /// <summary>
    /// You can turn your children's active off or on with delay.
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public static Coroutine ChildActive(Transform tr, float delay, bool state)
    {
        return instance.StartCoroutine(instance.ChildActiveCR(tr, delay, state));
    }

    IEnumerator ChildActiveCR(Transform _tr, float _delay, bool _state)
    {
        for (int i = 0; i < _tr.childCount; i++)
        {
            yield return new WaitForSeconds(i * _delay);
            _tr.GetChild(i).gameObject.SetActive(_state);
        }

    }

    /// <summary>
    /// You can add the initial wait time to the Child Active method.
    /// </summary>

    public static Coroutine ChildActive_Wait(Transform tr, float delay, bool state,float waitTime)
    {
        return instance.StartCoroutine(instance.ChildActive_WaitCR(tr, delay, state, waitTime));
    }

    IEnumerator ChildActive_WaitCR(Transform _tr, float _delay, bool _state, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        for (int i = 0; i < _tr.childCount; i++)
        {
            yield return new WaitForSeconds(i * _delay);
            _tr.GetChild(i).gameObject.SetActive(_state);
        }

    }

}

