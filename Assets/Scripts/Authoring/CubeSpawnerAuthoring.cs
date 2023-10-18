using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CubeSpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
}

public struct CubeSpawner : IComponentData
{
    public Entity prefab;
    public int spawnCount;
    public float3 spawnPosition;
}

public class CubeSpawnerBaker : Baker<CubeSpawnerAuthoring>
{
    public override void Bake(CubeSpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new CubeSpawner
        {
            prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
            spawnCount = 0,
            spawnPosition = new float3(0, 0, 0)
        });
    }
}