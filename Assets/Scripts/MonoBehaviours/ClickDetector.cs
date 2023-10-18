using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Collections;

public class ClickDetector : MonoBehaviour
{
    public int spawn_count = 1;
    private EntityManager entityManager;

    int i = 0;
    int j = 0;
    void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        var entities = entityManager.CreateEntityQuery(typeof(CubeSpawner)).ToEntityArray(Allocator.Temp);
        foreach (var entity in entities)
        {
            var spawner = entityManager.GetComponentData<CubeSpawner>(entity);

            spawner.spawnCount = spawn_count;
            spawner.spawnPosition = new float3(0,0,0);
            entityManager.SetComponentData(entity, spawner);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var entities = entityManager.CreateEntityQuery(typeof(CubeSpawner)).ToEntityArray(Allocator.Temp);
            foreach (var entity in entities)
            {
                var spawner = entityManager.GetComponentData<CubeSpawner>(entity);

                spawner.spawnCount = spawn_count;
                spawner.spawnPosition = new float3(i * 10,0,j * 10);
                entityManager.SetComponentData(entity, spawner);
                ++i;
                if(i>=5)
                {
                    i = 0;
                    ++j;
                }
            }
        }
    }
}