using Unity.Entities;

namespace ZombieBrains
{
    public class BrainBaker : Baker<BrainAuthor>
    {
        public override void Bake(BrainAuthor authoring)
        {
            Entity brainEntity = GetEntity(TransformUsageFlags.Renderable);
            AddComponent(brainEntity, new Brain(
                authoring.Radius,
                authoring.MaxHealth,
                authoring.transform.localScale));
            AddBuffer<BrainDamageBufferElement>(brainEntity);
        }
    }   
}