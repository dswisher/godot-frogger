using System;
using System.Collections.Generic;
using Godot;

namespace Frogger.scenes.frog
{
    public partial class Frog : Area2D
    {
        private const int TileSize = 16;

        private readonly List<MoveEntry> moves = new ();
        private bool moving;

        public Frog()
        {
            moves.Add(new MoveEntry("move_up", Vector2.Up));
            moves.Add(new MoveEntry("move_down", Vector2.Down));
            moves.Add(new MoveEntry("move_left", Vector2.Left));
            moves.Add(new MoveEntry("move_right", Vector2.Right));
        }

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
        }


        public override void _UnhandledInput(InputEvent inputEvent)
        {
            if (moving)
            {
                return;
            }

            var moveDelta = Vector2.Zero;
            var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
            var moved = false;
            foreach (var item in moves)
            {
                if (inputEvent.IsActionPressed(item.Name))
                {
                    moveDelta = item.Direction * TileSize;

                    animatedSprite2D.Animation = item.Name;

                    moved = true;
                }
            }

            if (moved)
            {
                animatedSprite2D.Play();
                moving = true;
                var tween = GetTree().CreateTween();
                tween.TweenProperty(this, "position", Position + moveDelta, 0.2f).SetTrans(Tween.TransitionType.Sine);
                tween.Finished += () => TweenDone(animatedSprite2D);
                tween.Play();
            }
        }


        public void Start(Vector2 position)
        {
            Position = position;
            Show();
        }


        private void TweenDone(AnimatedSprite2D sprite)
        {
            moving = false;
            sprite.Stop();
        }


        private class MoveEntry
        {
            public MoveEntry(string name, Vector2 direction)
            {
                Name = name;
                Direction = direction;
            }

            public String Name { get; }
            public Vector2 Direction { get; }
        }
    }
}
