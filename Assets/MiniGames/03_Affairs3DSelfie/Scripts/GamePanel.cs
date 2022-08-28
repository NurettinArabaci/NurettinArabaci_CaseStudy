using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] GameObject gameBG;

    private void Awake() => EventManager.OnMessageInActive += () => gameBG.SetActive(true);

    private void OnDisable() => EventManager.OnMessageInActive -= () => gameBG.SetActive(true);


}
