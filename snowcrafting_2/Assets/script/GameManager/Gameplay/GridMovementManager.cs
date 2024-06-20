using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementTile
{
    private bool isOccupied;
    public Enemy occupiedEnemy;
    public void SetOccupied(bool isOccupied)
    {
        this.isOccupied = isOccupied;
    }

    public bool GetOccupied()
    {
        return isOccupied;
    }

    public void SetOccupiedEnemy(Enemy enemy)
    {
        occupiedEnemy = enemy;
    }
}

public class GridMovementManager : SingletonMonoBehaviour<GridMovementManager>
{
    [System.Serializable]
    private class CharacterMovableTiles
    {
        public List<Vector2Int> movableTiles = new List<Vector2Int>();
    }

    [Header("GridSettings")]
    private ManualGrid<MovementTile> movementGrid;
    [SerializeField] private Vector2 orginPosition;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private CharacterMovableTiles[] charactersMovableTiles;


    protected override void Awake()
    {
        base.Awake();
        movementGrid = new ManualGrid<MovementTile>(width, height, cellSize, orginPosition);
        SetChraractersMovableTiles();
    }

    private void SetChraractersMovableTiles()
    {
        for(int x = 0; x < movementGrid.GetWidth(); x++)
        {
            for(int y1 = Settings.enemy1MovableTilesConstrainMinY; y1<= Settings.enemy1MovableTilesConstrainMaxY; y1++)
            {
                charactersMovableTiles[0].movableTiles.Add(new Vector2Int(x,y1));
            }
            for (int y2 = Settings.enemy2MovableTilesConstrainMinY; y2 <= Settings.enemy2MovableTilesConstrainMaxY; y2++)
            {
                charactersMovableTiles[1].movableTiles.Add(new Vector2Int(x, y2));
            }
            for (int y3 = Settings.enemy3MovableTilesConstrainMinY; y3 <= Settings.enemy3MovableTilesConstrainMaxY; y3++)
            {
                charactersMovableTiles[2].movableTiles.Add(new Vector2Int(x, y3));
            }
        }
    }

    public Vector2 GetPositionUpdateOccupiedTiles(Vector2Int tileXY)
    {
        SetOccupied(tileXY, true);
        return movementGrid.GetWorldPosition(tileXY.x, tileXY.y);
    }

    public Vector2 GetTargetPositionUpdateOccupiedTiles(Vector2 currentPosition,int characterIndex)
    {
        Vector2Int temp = GetRandomTileFromAvailableTiles(charactersMovableTiles[characterIndex].movableTiles);

        SetOccupied(temp, true);
        movementGrid.GetValue(currentPosition).SetOccupied(false);

        return movementGrid.GetWorldPosition(temp.x, temp.y);
    }

    private List<Vector2Int> GetAvailableTiles()
    {
        List<Vector2Int> availableTiles = new List<Vector2Int>();
        for (int x = 0; x < movementGrid.GetWidth(); x++)
        {
            for(int y = 0; y < movementGrid.GetHeight(); y++)
            {
                if(movementGrid.GetValue(x,y).GetOccupied() == false)
                {
                    Vector2Int temp = new Vector2Int(x, y);
                    availableTiles.Add(temp);
                }
            }
        }
        return availableTiles;
    }

    private List<Vector2Int> GetAvailableTiles(List<Vector2Int> movableTiles)
    {
        List<Vector2Int> availableTiles = new List<Vector2Int>();
        foreach(Vector2Int i in movableTiles)
        {
            if(movementGrid.GetValue(i.x, i.y).GetOccupied() == false)
            {
                availableTiles.Add(i);
            }
        }
        return availableTiles;
    }

    private Vector2Int GetRandomTileFromAvailableTiles(List<Vector2Int> movableTiles)
    {
        List<Vector2Int> availableTiles = GetAvailableTiles(movableTiles);

        int i = Random.Range(0,availableTiles.Count);
        return availableTiles[i];
    }

    private void SetOccupied(Vector2Int occupiedTile, bool isOccupied)
    {
        movementGrid.GetValue(occupiedTile.x, occupiedTile.y).SetOccupied(isOccupied);
    }

    public void SetOccupied(Vector2 occupiedTile, bool isOccupied)
    {
        movementGrid.GetValue(occupiedTile).SetOccupied(isOccupied);
    }
}
