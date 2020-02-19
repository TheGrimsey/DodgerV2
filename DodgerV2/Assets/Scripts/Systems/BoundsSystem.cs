using Unity.Entities;
using Unity.Transforms;

/*
 * Handles marking entities out of bounds for destruction.
 */
public class BoundsSystem : ComponentSystem
{
    /*
     * "Playspace" bounds. Outside these cordinates Entities will be marked for deletion.
     */
    float LowestX = -15;
    float HighestX = 15;

    float HighestY = 25;
    float LowestY = -12f;

    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref Translation translation) =>
        {
            //Check if we are outisde the playspace.
            if (IsOutsidePlaySpace(translation))
            {
                //Mark this for delete if we were.
                PostUpdateCommands.AddComponent(entity, typeof(DestroyComponent));
            }
        });
    }

    //Check if a position is outside the playspace.
    private bool IsOutsidePlaySpace(Translation translation)
    {
        return translation.Value.x <= LowestX || translation.Value.x > HighestX || translation.Value.y < LowestY || translation.Value.y > HighestY;
    }
}