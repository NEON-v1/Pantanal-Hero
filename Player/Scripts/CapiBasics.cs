using Godot;
using System;

public partial class CapiBasics : CharacterBody2D
{
	[Export] public AnimationPlayer animPlayer;
	
	public float moveSpeed;
	
	//Max jump height (in pixels)
	public float jumpVelocity;
	public float gravity;
	public bool isFalling = false;
	
	public float dir;
	public float currDir;
	
	public int jumpCount;
	public int maxJumps;
	
	public Vector2 velocity;
	
	[Export] public Resource Stats;
	[Export] public Timer dashTimer;
	
	public CollisionShape2D hitbox;
	
	public bool isDashing;
	
	public override void _Ready()
	{
		if (Stats is stats_test botStats)
		{
			moveSpeed = botStats.Speed;
			jumpVelocity = botStats.JumpVelocity;
			gravity = botStats.Gravity;
			maxJumps = botStats.MaxJumps;
		}
		
		hitbox = GetNode<CollisionShape2D>("/root/Node2D/Capi/HitBox");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		
		dir = Input.GetAxis("left", "right");
		
		if (dir == -1 || dir == 1) {
			velocity.X = dir * moveSpeed;
		}
		else if (dir == 0) {
			velocity.X = 0;
			
			animPlayer.Play("idle_test");
		}
		
		jumpSystem();
		
		if (Input.IsActionJustPressed("dash")) {
			dashTimer.Start(0.5f);
			isDashing = true;
		}
		
		if (isDashing) {
			// EXTRA: become a little transparent ( play with shader )
			
			currDir = dir;
			velocity.X = 3 * currDir * moveSpeed;
			
			hitbox.SetDeferred("Disabled", true);
			
			if (dashTimer.TimeLeft == 0) {
				hitbox.SetDeferred("Disabled", false);
				isDashing = false;
			}
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
	
	
	/*
		Functions ahead:
		
		 - jump System  ( Self explanatory )
	*/
	
	
	public void jumpSystem () {
		
		if (IsOnFloor()) {
			isFalling = false;
			jumpCount = 0;
		}
		
		if (Input.IsActionJustPressed("jump") && jumpCount < maxJumps) {
			isFalling = false;
			velocity.Y = -jumpVelocity;
			jumpCount++;
		}
		
		if (Input.IsActionJustReleased("jump") && velocity.Y <= 0) {
			isFalling = true;
		}
		
		if (!isFalling) {
			velocity.Y += gravity;
		}
		else {
			velocity.Y += 3 * gravity;
		}
		
		GD.Print(velocity.Y);
	}
}
