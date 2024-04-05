using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	[Export] public AnimationPlayer animPlayer;
	
	public float moveSpeed;
	
	//Max jump height (in pixels)
	public float jumpVelocity;
	public float gravity;
	public bool isFalling = false;
	
	public float dir;
	public int jumpCount;
	public int maxJumps;
	
	[Export] public Resource Stats;
	
	public override void _Ready()
	{
		if (Stats is stats_test botStats)
		{
			moveSpeed = botStats.Speed;
			jumpVelocity = botStats.JumpVelocity;
			gravity = botStats.Gravity;
			maxJumps = botStats.MaxJumps;
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
		}
		
		if (Input.IsActionJustPressed("jump") && jumpCount < maxJumps) {
			isFalling = false;
			velocity.Y = -jumpVelocity;
			jumpCount++;
		}
		
		if (!isFalling) {
			velocity.Y += gravity;
		}
		
		if (Input.IsActionJustReleased("jump") && velocity.Y <= 0) {
			isFalling = true;
		}
		
		if (isFalling) {
			velocity.Y += 3 * gravity;
		}
		GD.Print(velocity.Y);
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
