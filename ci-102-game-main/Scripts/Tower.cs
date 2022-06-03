using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
  private float range;
  private float damage;
  private float shootTimer;
  private float nextshotTimer;
  
  private void Awake() {
      range = 60f;
      damage = 20;
      shotstimer = .2f
  }

  public void Upgraderange(){
      range += 5f;
  }

  public void Upgradedamage(){
      damage += 10;
  }

  private void OnMouseEnter(){
      UpgradeMenu.Show_Static(this);
  }




    
}
