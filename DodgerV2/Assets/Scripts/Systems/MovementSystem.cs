using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class MovementSystem : ComponentSystem
{
    //Outside of these coordinates Entities are no longer within the "playspace"
    float LowestX = -15;
    float HighestX = 15;

    float HighestY = 25;
    float LowestY = -12f;

    protected override void OnUpdate()
    {
        //Cache this.
        float deltaTime = Time.DeltaTime;

        //For every entity with a MovementComponent.
        Entities.ForEach((Entity entity, ref Translation translation, ref Rotation rotation, ref MovementComponent movementComponent) =>
        {
            //Calculate movementDirection
            float3 movementDirection = math.mul(rotation.Value, movementComponent.RelativeMovementDirection);

            float3 deltaPosition = movementDirection * movementComponent.MovementSpeed * deltaTime;

            translation.Value += deltaPosition;

            //Check if we are still inside the playspace.
            if (IsOutsidePlaySpace(translation))
            {
                PostUpdateCommands.AddComponent(entity, typeof(DestroyComponent));
            }
        });

    }

    private bool IsOutsidePlaySpace(Translation translation)
    {
        return translation.Value.x <= LowestX || translation.Value.x > HighestX || translation.Value.y < LowestY || translation.Value.y > HighestY;
    }
}
