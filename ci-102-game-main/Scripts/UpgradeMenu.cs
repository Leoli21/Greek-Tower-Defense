using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour{
    
    private static UpgradeMenu Instance { get; set; }

    private void Awake(){
        Instance = this;

        transform.Find("RangeBtn").GetComponent<Button_Sprite>().ClickFunc = Upgraderange
        transform.Find("DamageBtn").GetComponent<Button_Sprite>().ClickFunc = Upgradedamage
        transform.Find("CloseBtn").GetComponent<Button_Sprite>().ClickFunc = hide;

        Hide();
    }

    public static void Show_Static(Tower tower){
        Instance.Show(tower);
    }

    private void Show(Tower tower){
        gameObject.setActice(true);
        Transform.position = tower.transform.position;
    }

    private void Hide(){
        gameObject.SetActive(false);
    }

    private void UpgradeRange(){
        tower.UpgradeRange();
    }

    private void Upgradedamage(){
        tower.Upgradedamage();
    }
}