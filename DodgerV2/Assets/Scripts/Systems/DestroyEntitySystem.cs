using Unity.Entities;
using UnityEngine;

/*
 * ComponentSystem for destroying Gameobjects associated with entity as well as the entity itself.
 */
public class DestroyEntitySystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Transform transform, ref DestroyComponent destroycomponent) =>
        {
            //Check so the transform isn't null then destroy the gameobject associated with it.
            if(transform != null)
            {
                GameObject.Destroy(transform.gameObject);
            }
            EntityManager.DestroyEntity(entity);
        });

    }
}
