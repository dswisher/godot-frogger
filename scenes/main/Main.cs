using Godot;

namespace Frogger.scenes.main
{
    public partial class Main : Node
    {
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            NewGame();
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
        }


        public void NewGame()
        {
            var frog = GetNode<frog.Frog>("Frog");
            var startPosition = GetNode<Marker2D>("StartPosition");
            frog.Start(startPosition.Position);
        }
    }
}
