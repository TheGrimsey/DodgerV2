using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
[GenerateAuthoringComponent]
public struct MovementComponent : IComponentData
{
    public float MovementSpeed;
    public float3 RelativeMovementDirection;
}
