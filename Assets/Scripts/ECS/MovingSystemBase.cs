using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Burst;

// public partial class MovingSystemBase : SystemBase
// {
//     protected override void OnUpdate()
//     {
//         var deltaTime = SystemAPI.Time.DeltaTime;
//         Entities.ForEach((ref LocalTransform transform, in Speed speed) =>
//         {
//             transform.Position += new float3(1, 0, 0) * speed.value * deltaTime;
//         }).ScheduleParallel(); // 这里可使用主线程的 .Run()，或单线程的 .Schedule()
//     }
// }
[BurstCompile]
public partial struct MovingISystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        new MoveJob { deltaTime = SystemAPI.Time.DeltaTime }.ScheduleParallel();
    }
}
[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    public void Execute(MovingAspect aspect)
    {
        aspect.Move(deltaTime);
    }
}