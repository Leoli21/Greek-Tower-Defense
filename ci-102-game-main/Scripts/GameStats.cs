using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    public static GameStats instance;
    public int enemiesKilled = 0;
    public int goldCollected = 0;
    public int goldSpent = 0;
    public int livesLost = 0;
    public int cratesOpened = 0;
    public int towers = 0;

    public int crate = 0;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
