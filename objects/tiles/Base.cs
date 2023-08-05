using Godot;

namespace Tiles {
    public partial class Base : Node3D {
        [Export]
        public MeshInstance3D HexagonMesh;
        public Vector2 GetSize() {
            Aabb bounds = HexagonMesh.GetAabb();
            return new(bounds.Size.X, bounds.Size.X);
        }
    }
}
