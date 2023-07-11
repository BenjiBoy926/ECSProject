using Unity.Entities;

namespace ZombieBrains
{
    public class BrainBaker : Baker<BrainAuthor>
    {
        public override void Bake(BrainAuthor authoring)
        {
            Entity brainEntity = GetEntity(TransformUsageFlags.Renderable);
            AddComponent(brainEntity, new Brain(
                authoring.transform.position,
                authoring.Radius));
        }
    }   
}