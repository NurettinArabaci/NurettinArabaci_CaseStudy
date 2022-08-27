using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    static Delay instance_;


    public static Delay instance
    {
        get
        {
            if (instance_)
                return instance_;
            else
            {
                instance_ = new GameObject("Delay").AddComponent<Delay>();
                return instance_;
            }
        }
    }

    public static Coroutine WaitForMe(System.Action _action, float _duration)
    {
        return instance.StartCoroutine(instance.WaitForMeCR(_action, _duration));
    }

    IEnumerator WaitForMeCR(System.Action action, float duration)
    {
        yield return new WaitForSeconds(duration);
        action?.Invoke();
    }

  
}
