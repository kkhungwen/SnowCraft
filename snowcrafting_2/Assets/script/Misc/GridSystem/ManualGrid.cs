using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManualGrid<T> where T : new()
{
    private int width;
    private int height;
    private T[,] gridArray;
    private float cellSize;
    private Vector2 originPosition;

    public ManualGrid(int width, int hight, float cellSize, Vector2 orginPosition)
    {
        this.width = width;
        this.height = hight;
        gridArray = new T[width, hight];
        this.cellSize = cellSize;
        this.originPosition = orginPosition;
        

        bool showDebug = true;
        if (showDebug)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for(int y = 0; y < gridArray.GetLength(1); y++)
                {
                    T temp = new T();
                    gridArray[x, y] = temp;
                    Debug.DrawLine(GetWorldPosition(x, y)-new Vector2(cellSize*0.5f, cellSize * 0.5f), GetWorldPosition(x, y + 1) - new Vector2(cellSize * 0.5f, cellSize * 0.5f), Color.white, 1000f);
                    Debug.DrawLine(GetWorldPosition(x, y) - new Vector2(cellSize * 0.5f, cellSize * 0.5f), GetWorldPosition(x + 1, y) - new Vector2(cellSize * 0.5f, cellSize * 0.5f), Color.white, 1000f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, height) - new Vector2(cellSize * 0.5f, cellSize * 0.5f), GetWorldPosition(width, height) - new Vector2(cellSize * 0.5f, cellSize * 0.5f), Color.white, 1000f);
            Debug.DrawLine(GetWorldPosition(width, 0) - new Vector2(cellSize * 0.5f, cellSize * 0.5f), GetWorldPosition(width, height) - new Vector2(cellSize * 0.5f, cellSize * 0.5f), Color.white, 1000f);
        }
    }


    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector2 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, T value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
        }
    }

    public void SetValue(Vector2 worldPosition, T value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public T GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default;
        }
    }

    public T GetValue(Vector2 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }


    public const int sortingOrderDefault = 5000;
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}
