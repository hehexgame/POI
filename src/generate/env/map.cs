using Godot;
namespace Generation {
    public delegate void MapGenerated();
    public class Map {
        readonly private Noise noise;
        public event MapGenerated OnMapGenerated;

        readonly private PackedScene baseTile = ResourceLoader.Load<PackedScene>(
            "res://objects/tiles/sea.tscn"
        );
        readonly private Vector2 tileSize;
        public Map() {
            Tiles.Base instance = baseTile.Instantiate<Tiles.Base>();
            tileSize = instance.GetSize();
            // tileSize = new(1.0f,1.0f);
            // @todo init PerlinNoise
        }
        ~Map() {
            noise?.Free();
        }
        public void Generate(Node3D root, Vector2 size)  {
            float cos30Rad = Godot.Mathf.Cos(Godot.Mathf.DegToRad(30));
            float halfTieSize = tileSize.Y/2;
            for (short x = 0; x < size.X; x++) {
                Vector2 pos = Vector2.Zero;
                pos.X = x * tileSize.X;
                pos.Y = x % 2 == 0 ? 0 : halfTieSize;

                GD.Print(pos);
                for (short z = 0; z < size.Y; z++) {
                    Node3D tile = GenerateNodeAt();
                    root.AddChild(tile);
                    tile.GlobalTranslate(new(pos.X, 0, pos.Y));
                    pos.Y += tileSize.Y;
                }
            }
            OnMapGenerated();
        }
        private Node3D GenerateNodeAt() {
            // @todo based on noise choose node
            return baseTile.Instantiate<Node3D>();
        }
    }
}