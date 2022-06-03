using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
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

        startTile = mapTiles[mapWidth*3];
        endTile = mapTiles[mapWidth*6 -1];

        currentTile = startTile;

        //Right 5 Tiles
        for(int i = 0; i < 4; i++)
        {
            moveRight();
        }
        
        //Up 5 Tiles
        for(int i = 0; i < 4; i++)
        {
            moveUp();
        }

        //Right 4 Tiles
        for(int i = 0; i < 3; i++)
        {
            moveRight();
        }

        //Down 5 Tiles
        for(int i = 0; i < 5; i++)
        {
            moveDown();
        }

        //Right 5 Tiles
        for(int i = 0; i < 5; i++)
        {
            moveRight();
        }

        //Up 5 Tiles
        for(int i = 0; i < 5; i++)
        {
            moveUp();
        }

        //Right 3 Tiles
        for(int i = 0; i < 3; i++)
        {
            moveRight();
        }

        //Down 2 Tiles
        for(int i = 0; i < 2; i++)
        {
            moveDown();
        }
        
        //Right to End tile
        for(int i = 0; i < 4; i++)
        {
            moveRight();
        }
        pathTiles.Add(endTile);
        
        foreach(GameObject obj in pathTiles)
        {
            obj.GetComponent<SpriteRenderer>().color = pathColor;
        }
    }
}
