using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GachaCurrency : MonoBehaviour
{
    public static int Money;
    public int startMoney = 200;
    public int crate = 0;

    void Start()
    {
        Money = startMoney;
    }

    public void PurchaseCrate()
    {
        if(Money > 99)
        {
            crate += 1;
            Money -= 100;
        }
        else
        {
            Debug.Log("Not enough Money")
        }
    }
}