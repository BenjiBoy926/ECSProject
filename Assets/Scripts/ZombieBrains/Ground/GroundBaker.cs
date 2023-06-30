using Unity.Entities;

namespace ZombieBrains
{
    public class GroundBaker : Baker<GroundAuthor>
    {
        public override void Bake(GroundAuthor authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Renderable);
            AddComponent(entity, new Ground(authoring.Surface));
        }
    }
}