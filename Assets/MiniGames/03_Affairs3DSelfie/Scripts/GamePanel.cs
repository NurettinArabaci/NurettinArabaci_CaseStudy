using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] GameObject gameBG;

    public static int arrowAmount;

    private void Awake()
    {
        arrowAmount = 0;
        EventManager.OnStartGame += () => gameBG.SetActive(true);
    }

    private void OnDisable() => EventManager.OnStartGame -= () => gameBG.SetActive(true);


}
