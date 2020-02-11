using System;
using Unity.Entities;
using UnityEngine;

[Serializable]
[GenerateAuthoringComponent]
public struct MovementComponent : IComponentData
{
    public float MovementSpeed;
    public Vector2 RelativeMovementDirection;
}
