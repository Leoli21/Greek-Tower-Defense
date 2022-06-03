using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3Generation : MonoBehaviour
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

        startTile = mapTiles[mapWidth*15];
        endTile = mapTiles[mapWidth*2];

        currentTile = startTile;

        //Manual Path Generation
        
        //Move Right 5 tiles
        for(int i = 0; i < 5; i++)
        {
            moveRight();
        }

        //move down 3
        for(int i = 0; i<3; i++)
        {
            moveDown();
        }

        //left 3
        for(int i =0; i < 3; i++)
        {
            moveLeft();
        }

        //down 3
        for(int i = 0; i < 3; i++)
        {
            moveDown();
        }

        //right 5
        for(int i = 0; i < 5; i++)
        {
            moveRight();
        }

        //up 5
        for(int i = 0; i < 5; i++)
        {
            moveUp();
        }

        //right 3
        for(int i = 0; i < 3; i++)
        {
            moveRight();
        }

        //down 5
        for(int i = 0; i < 5; i++)
        {
            moveDown();
        }

        //right 3
        for(int i = 0; i < 3; i++)
        {
            moveRight();
        }

        //up 6
        for(int i = 0; i < 6; i++)
        {
            moveUp();
        }

        //right 3
        for(int i = 0; i < 3; i++)
        {
            moveRight();
        }

        //down 10
        for(int i = 0; i < 10; i++)
        {
            moveDown();
        }

        //left 3
        for(int i = 0; i < 3; i++)
        {
            moveLeft();
        }

        //up 2
        for(int i = 0; i < 2; i++)
        {
            moveUp();
        }

        //left 4
        for(int i = 0; i < 4; i++)
        {
            moveLeft();
        }

        //down 4
        for(int i = 0; i < 4; i++)
        {
            moveDown();
        }
        
        //right 7
        for(int i = 0; i < 7; i++)
        {
            moveRight();
        }

        //down 2
        for(int i = 0; i < 2; i++)
        {
            moveDown();
        }

        //left 11
        for(int i = 0; i < 11; i++)
        {
            moveLeft();
        }
        //up 5
        for(int i = 0; i < 5; i++)
        {
            moveUp();
        }
        //left 3
        for(int i = 0; i < 3; i++)
        {
            moveLeft();
        }
        //down 4
        for(int i = 0; i < 4; i++)
        {
            moveDown();
        }

        //left 2 to end
        for(int i = 0; i < 2; i++)
        {
            moveLeft();
        }
        pathTiles.Add(endTile);
        
        foreach(GameObject obj in pathTiles)
        {
            obj.GetComponent<SpriteRenderer>().color = pathColor;
        }
    }
}
