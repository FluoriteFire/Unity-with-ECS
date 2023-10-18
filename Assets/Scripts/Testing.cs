using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Transform parent;
    private Grid grid; 
    private void Start()
    {
        grid = new Grid(4,2,10f,parent,new Vector3(0,0,0));
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPosition(),42);
        }
        if(Input.GetMouseButtonDown(1))
        {
            grid.GetValue(GetMouseWorldPosition());
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        // vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition + new Vector3(0,0,50));
        return worldPosition;
    }
}
