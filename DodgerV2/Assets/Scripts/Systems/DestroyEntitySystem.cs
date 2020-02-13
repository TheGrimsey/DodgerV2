using Unity.Entities;
using UnityEngine;
public class DestroyEntitySystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, Transform transform, ref DestroyComponent destroycomponent) =>
        {
            if(transform != null)
            {
                GameObject.Destroy(transform.gameObject);
            }
            EntityManager.DestroyEntity(entity);
        });

    }
}
