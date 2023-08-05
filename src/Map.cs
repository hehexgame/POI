using Godot;

public partial class Map : Node3D {
    [Export]
    public Vector2 size = new(6,6);
    [Export]
    public Node3D mapRoot;
    private Generation.Map mg;
    private Generation.Weather wg;
    public override void _Ready() {
        // MARK: -generate map
        mg = new();
        mg.OnMapGenerated += MapGenerated;
        mg.Generate(
            root: mapRoot,
            size: size
        );
        
        // MARK: -generate weather TBD 
        wg = new();
        wg.Generate();
        
        base._Ready();
    }
    private void MapGenerated() {
        GD.Print("Map generated");
    }
}
