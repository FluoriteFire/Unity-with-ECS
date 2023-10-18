using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using UnityEngine;
using Unity.Collections;

public partial struct CubeSpawnerISystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.TempJob);
        new CubeSpawnerJob { ecb = ecb }.Run();
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}

public partial struct CubeSpawnerJob : IJobEntity
{
    public EntityCommandBuffer ecb;
    public void Execute(CubeSpawnerAspect aspect)
    {
        aspect.Spawn(ecb);
    }
}