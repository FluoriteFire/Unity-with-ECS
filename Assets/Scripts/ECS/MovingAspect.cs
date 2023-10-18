using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct MovingAspect : IAspect
{
    private readonly Entity entity;
    private readonly RefRO<Speed> speed;
    private readonly RefRW<LocalTransform> transform;

    public void Move(float deltaTime)
    {
        transform.ValueRW.Position += new float3(1, 0, 0) * speed.ValueRO.value * deltaTime;
    }
}