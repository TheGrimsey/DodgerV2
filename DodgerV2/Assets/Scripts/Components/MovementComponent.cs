using System;
using Unity.Entities;
using Unity.Mathematics;

/*
 * Holds data related to movement.
 * Used by MovementSystem
 */
[Serializable]
[GenerateAuthoringComponent]
public struct MovementComponent : IComponentData
{
    //Movement Speed.
    public float MovementSpeed;
    //Movement relative to local space for entity.
    public float3 RelativeMovementDirection;
}
