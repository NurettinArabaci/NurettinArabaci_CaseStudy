using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject[] levelPrefabs;
   
    public static int Level
    {
        get { return PlayerPrefs.GetInt(Tags.Level, 0); }
        set { PlayerPrefs.SetInt(Tags.Level, value); }
    }

    private void Awake()
    {

        EventManager.OnLevelCompleted += OnLevelCompleted;

        levelPrefabs = Resources.LoadAll<GameObject>(Tags.Level);
        LevelLoad();
    }

    void OnLevelCompleted()
    {
        Level++;
        ConfettiControl.PlayConfetti();
        CurrentLevelText.Visible(false);
        EventManager.Fire_OnCoinVisible(false);
        NAEngine.Delay(() => LevelLoad(),3f);
    }

    void LevelLoad()
    {
        if (GameObject.FindGameObjectWithTag(Tags.Level))
        {
            Destroy(GameObject.FindGameObjectWithTag(Tags.Level));
        }

        Instantiate(levelPrefabs[Level % levelPrefabs.Length]);
        CurrentLevelText.Visible(true);
        EventManager.Fire_OnCoinVisible(true);
    }

    private void OnDisable()
    {
        EventManager.OnLevelCompleted -= OnLevelCompleted;
    }

}
