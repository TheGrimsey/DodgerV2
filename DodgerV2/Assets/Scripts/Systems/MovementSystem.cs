using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class MovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        //Cache this.
        var deltaTime = Time.DeltaTime;

        //For every entity with a MovementComponent.
        Entities.ForEach((ref Translation translation, ref MovementComponent movementComponent) =>
        {
            //Calculate movement delta
            Vector3 deltaPositionVec3 = movementComponent.MovementSpeed * movementComponent.RelativeMovementDirection * deltaTime;

            float3 deltaPositionf3 = new float3(deltaPositionVec3.x, deltaPositionVec3.y, deltaPositionVec3.z);

            translation.Value += deltaPositionf3;

        });

    }
}
