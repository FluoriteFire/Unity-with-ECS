using UnityEngine;
using Unity.Entities;
using Unity.Collections;

public class SpeedManager : MonoBehaviour
{
    public float global_speed;

    void Update()
    {
        var entities = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(Speed)).ToEntityArray(Allocator.Temp);
        foreach (var entity in entities)
        {
            var speed = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<Speed>(entity);
            speed.value = global_speed;
            World.DefaultGameObjectInjectionWorld.EntityManager.SetComponentData(entity, speed);
        }
    }
}