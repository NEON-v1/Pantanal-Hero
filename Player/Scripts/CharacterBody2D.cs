using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	[Export] public AnimationPlayer animPlayer;
	
	public float moveSpeed = 300.0f;
	
	//Max jump height (in pixels)
	public float jumpVelocity = 600.0f;
	public bool isFalling = false;
	
	public float dir;
	public int jumpCount;
	public int maxJumps = 2;
	
	//The time it take to reach max jump height
	public float time;
	
	[Export] public Resource Stats;
	
	public override void _Ready()
	{
		
		if (Stats is stats_test botStats)
		{
			GD.Print(botStats.Health);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		dir = Input.GetAxis("left", "right");
		
		if (dir == -1 || dir == 1) {
			velocity.X = dir * moveSpeed;
		}
		else if (dir == 0) {
			velocity.X = 0;
			
			animPlayer.Play("idle_test");
		}
		
		if (IsOnFloor()) {
			isFalling = false;
			jumpCount = 0;
			time = 1;
		}
		
		if (Input.IsActionJustPressed("jump") && jumpCount < maxJumps) {
			isFalling = false;
			jumpCount++;
			time = 1;
		}
		
		if (Input.IsActionPressed("jump") && !isFalling) {
			velocity.Y = -jumpVelocity * time;
			time -= (float)delta;
			GD.Print(time);
		}
		
		if (Input.IsActionJustReleased("jump") || isFalling || time < 0) {
			isFalling = true;
			velocity.Y = jumpVelocity * time;
			time += (float)delta;
			GD.Print(time);
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
