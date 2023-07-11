using Unity.Entities;

public class SphereBaker : Baker<SphereAuthor>
{
    public override void Bake(SphereAuthor authoring)
    {
        Entity sphere = GetEntity(TestConstants.TransformUsage);
        Entity capsule = GetEntity(authoring.CapsulePrefab, TestConstants.TransformUsage);
        AddComponent(sphere, new Sphere { CapsulePrefab = capsule });
    }
}