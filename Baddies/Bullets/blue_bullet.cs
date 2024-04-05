using Godot;
using System;

public partial class blue_bullet : Sprite2D
{
	public Node capi;
	
	public float speed = 1.0f;
	public float maxSpeed = 45.0f;
	public Vector2 position;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		position = Position;
		capi = GetNode("Capi");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (speed <= maxSpeed) {
			speed *= 1.25f;
		}
		else {
			speed = maxSpeed;
		}
		
		position.X -= speed;
		Position = position;
	}
	
	private void _on_area_2d_body_entered(CharacterBody2D capi)
	{
		// Replace with function body.
		GD.Print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
	}
}
