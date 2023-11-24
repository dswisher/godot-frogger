using Godot;
using System;

public partial class Frog : Area2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var velocity = Vector2.Zero;
        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (Input.IsActionPressed("move_up"))
        {
            velocity.Y -= 1;
            animatedSprite2D.Animation = "up";
        }
        else if (Input.IsActionPressed("move_down"))
        {
            velocity.Y += 1;
            animatedSprite2D.Animation = "down";
        }
        else if (Input.IsActionPressed("move_left"))
        {
            velocity.X -= 1;
            animatedSprite2D.Animation = "left";
        }
        else if (Input.IsActionPressed("move_right"))
        {
            velocity.X += 1;
            animatedSprite2D.Animation = "right";
        }

        // TODO - how to move grid-by-grid?
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * 16;
            animatedSprite2D.Play();
        }
        else
        {
            animatedSprite2D.Stop();
        }

        Position += velocity * (float)delta;
    }


    public void Start(Vector2 position)
    {
        Position = position;
        Show();
    }
}
