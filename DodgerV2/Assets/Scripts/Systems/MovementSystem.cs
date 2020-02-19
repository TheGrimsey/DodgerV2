using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

/*
 * MovementSystem.
 * Handles moving all entities with a MovementComponent.
 */
public class MovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        //For every entity with a MovementComponent.
        Entities.WithAllReadOnly(typeof(MovementComponent)).ForEach((ref Translation translation, ref Rotation rotation, ref MovementComponent movementComponent) =>
        {
            //Calculate movementDirection
            float3 movementDirection = math.mul(rotation.Value, movementComponent.RelativeMovementDirection);

            //Calculate movement delta (how much we should move this frame).
            float3 movementDelta = movementDirection * movementComponent.MovementSpeed * deltaTime;

            //Add movement delta onto our position.
            translation.Value += movementDelta;
        });
    }
}
