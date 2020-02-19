using System;
using Unity.Entities;

// This component marks an entity for destruction. It and it's gameobject will be destroyed on the next frame.
[Serializable]
public struct DestroyComponent : IComponentData
{

}
