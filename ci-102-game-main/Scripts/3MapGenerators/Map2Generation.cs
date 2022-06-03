using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2Generation : MonoBehaviour
{
    public GameObject MapTile;

    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;

    private List<GameObject> mapTiles = new List<GameObject>();
    private List<GameObject> pathTiles = new List<GameObject>();
    
    private GameObject currentTile;
    
    private int currentTileIndex;
    private int nextTileIndex;

    public Color pathColor;

    private void Start()
    {
        generateMap();
    }

    private void moveDown() 
    {
        pathTiles.Add(currentTile);
        currentTileIndex = mapTiles.IndexOf(currentTile);
        nextTileIndex = currentTileIndex-mapWidth;
        currentTile = mapTiles[nextTileIndex];
    }
    
    private void moveUp()
    {
        pathTiles.Add(currentTile);
        currentTileIndex = mapTiles.IndexOf(currentTile);
        nextTileIndex = currentTileIndex + mapWidth;
        currentTile = mapTiles[nextTileIndex];
    }

    private void moveLeft()
    {
        pathTiles.Add(currentTile);
        currentTileIndex = mapTiles.IndexOf(currentTile);
        nextTileIndex = currentTileIndex-1;
        currentTile = mapTiles[nextTileIndex];
    }
    
    private void moveRight()
    {
        pathTiles.Add(currentTile);
        currentTileIndex = mapTiles.IndexOf(currentTile);
        nextTileIndex = currentTileIndex + 1;
        currentTile = mapTiles[nextTileIndex];
    }

    private void generateMap()
    {
        for(int y = 0; y < mapHeight; y++)
        {
            for(int x = 0; x < mapWidth; x++)
            {
                GameObject newTile = Instantiate(MapTile);
                mapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x,y);
                
            }
        }

        GameObject startTile;
        GameObject endTile;

        startTile = mapTiles[mapWidth*12];
        endTile = mapTiles[mapWidth*mapHeight-5];

        currentTile = startTile;

        //Manual Path Generation
        
        //Move Right 7 tiles
        for(int i = 0; i < 7; i++)
        {
            moveRight();
        }

        //Move Down 5 tiles
        for(int i = 0; i < 5; i++)
        {
            moveDown();
        }

        for(int i = 0; i < 5; i ++) 
        {
            moveLeft();
        }
        
        for(int i = 0; i < 5; i++)
        {
            moveDown();
        }

        for(int i = 0; i < 16; i++)
        {
            moveRight();
        }

        for(int i =0; i < 3; i++)
        {
            moveUp();
        }

        for(int i = 0; i < 6; i++)
        {
            moveLeft();
        }

        for(int i = 0; i < 3; i++)
        {
            moveUp();
        }
        
        for(int i = 0; i < 5; i++)
        {
            moveRight();
        }

        for(int i =0; i < 3; i++)
        {
            moveUp();
        }
        
        for(int i = 0; i < 2; i++)
        {
            moveUp();
        }

        for(int i =0; i< 2; i++)
        {
            moveLeft();
        }

        for(int i =0; i < 1; i++)
        {
            moveUp();
        }
        

        pathTiles.Add(endTile);
        
        foreach(GameObject obj in pathTiles)
        {
            obj.GetComponent<SpriteRenderer>().color = pathColor;
        }
    }
}
