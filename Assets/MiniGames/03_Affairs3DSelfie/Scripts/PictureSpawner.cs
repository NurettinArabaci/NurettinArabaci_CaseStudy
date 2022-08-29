using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EventManager
{
    public static event System.Action<GameObject> OnSpawnPicture;
    public static void Fire_OnSpawnPicture(GameObject prefab) { OnSpawnPicture?.Invoke(prefab); }
}

public class PictureSpawner : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.OnSpawnPicture += OnSpawnPicture;
    }
    void OnSpawnPicture(GameObject _prefab)
    {
        int rand = Random.Range(-2, 3);
        GameObject go= Instantiate(_prefab, transform.position, Quaternion.Euler(0, 0, rand * 5), transform);
        go.transform.DOScale(1, 0.2f).SetEase(Ease.OutFlash);

        Flash.FlashEffect();
    }

    private void OnDisable()
    {
        EventManager.OnSpawnPicture -= OnSpawnPicture;
    }
}
