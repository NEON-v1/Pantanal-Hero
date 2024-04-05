using Godot;
using System;

public partial class Blue_Bullet_Spawner : Sprite2D
{
	public PackedScene blueBullet = GD.Load<PackedScene>("res://Baddies/Bullets/blue_bullet.tscn");
	public float time = 0.0f;
	public Node inst;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		time += (float)delta;
		
		if (time >= 2) {
			inst = blueBullet.Instantiate();
			this.AddChild(inst);
			GD.Print("Bullet Instantiated!!!");
			time = 0.0f;
		}
	}
}
