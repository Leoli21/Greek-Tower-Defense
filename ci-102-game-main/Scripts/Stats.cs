using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int Life;
    public int startLife = 10;

    public static int Money;
    public int startMoney = 500;

    void Start()
    {
        Life = startLife;
        Money = startMoney;
    }

    void Update()
    {
        if (Life <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver");
    }
}
