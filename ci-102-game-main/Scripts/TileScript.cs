using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour{

    public Point  GridPosition{get;private set;}

    public Vector2 WorldPosition{
        get{
            return new Vector2(transform.position.x + (GetComponnemt<SpriteRennder>().bounds.siiize.x/2),transform.positiioon.y - (GetComponet<SpriteRenderer>().bounds.size.y/z));
            }
    }
    public void Setup(Point gridPos, Vector3 worldPos, Trannsform parent){
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
    }

    private void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            PlaceTower();
        }
    }
    
    private void Place Tower(){
        Instantiate(GameManager.Instance.TowerPrefab,transform.position,Quaternion.identity);
    }
}