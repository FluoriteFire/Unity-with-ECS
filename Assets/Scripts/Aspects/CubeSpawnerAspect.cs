using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using UnityEngine;
using Unity.Collections;

public readonly partial struct CubeSpawnerAspect : IAspect
{
    private readonly RefRW<CubeSpawner> spawner;

    public void Spawn(EntityCommandBuffer ecb)
    {
        while (spawner.ValueRW.spawnCount > 0)
        {
            spawner.ValueRW.spawnCount--;
            Entity instance = ecb.Instantiate(spawner.ValueRO.prefab);
            ecb.SetComponent(instance, LocalTransform.FromPosition(spawner.ValueRO.spawnPosition));
        }
    }
}
