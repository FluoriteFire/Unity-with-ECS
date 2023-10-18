using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;
    public Grid(int width, int height, float cellSize, Transform parent, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width,height];
        debugTextArray = new TextMesh[width,height];
        
        for(int x = 0; x < gridArray.GetLength(0); ++x)
        {
            for(int y = 0; y < gridArray.GetLength(1); ++y)
            {
                debugTextArray[x,y] = CreateWorldText(parent,gridArray[x,y].ToString(),GetWorldPostion(x,y) + new Vector3(cellSize,cellSize) * 0.5f,20,Color.white,TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPostion(x,0,y), GetWorldPostion(x,0,y+1),Color.white,100f);
                Debug.DrawLine(GetWorldPostion(x,0,y), GetWorldPostion(x+1,0,y),Color.white,100f);
            }
        }
        Debug.DrawLine(GetWorldPostion(0,0,height), GetWorldPostion(width,0,height),Color.white,100f);
        Debug.DrawLine(GetWorldPostion(width,0,0), GetWorldPostion(width,0,height),Color.white,100f);
    }

    private Vector3 GetWorldPostion(int x=0, int y=0, int z=0)
    {
        return new Vector3(x,y,z) * cellSize + originPosition;
    }
    
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition-originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition-originPosition).z / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            gridArray[x,y] = value;
            debugTextArray[x,y].text = gridArray[x,y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x,y;
        GetXY(worldPosition,out x,out y);
        SetValue(x,y,value);
    }
    
    public int GetValue(int x, int y)
    {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            return gridArray[x,y];
        }
        else 
        {
            return -1;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x,y;
        GetXY(worldPosition,out x,out y);
        return GetValue(x,y);
    }

    public static TextMesh CreateWorldText(Transform parent,string text, Vector3 localPosition,int fontSize,Color color,TextAnchor textAnchor)
    {
        GameObject gameObject = new GameObject("World_Text",typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent,false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.text = text;
        return textMesh;
    }
}


