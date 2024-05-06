using Godot;
using System;

public partial class blueBullet : Sprite2D
{
	[Export] public Resource bBullet;
	[Export] public Node capi;
	
	public float speed;
	public int maxSpeed;
	public Vector2 position;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		capi = GetNode("/root/Node2D/Capi");
		position = Position;
		
		if (bBullet is bullet_props BulletStats)
		{
			speed = BulletStats.InitialSpeed;
			maxSpeed = BulletStats.MaxSpeed;
		}
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
	
	private void _on_area_2d_body_entered(Node capi)
	{
		// Replace with function body.
		GD.Print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
	}
}
