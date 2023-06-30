using Unity.Entities;

public class CubeBaker : Baker<CubeAuthor>
{
    public override void Bake(CubeAuthor authoring)
    {
        Entity cube = GetEntity(TestConstants.TransformUsage);
        Entity sphere = GetEntity(authoring.SpherePrefab, TestConstants.TransformUsage);
        AddComponent(cube, new Cube { SpherePrefab = sphere });
    }
}