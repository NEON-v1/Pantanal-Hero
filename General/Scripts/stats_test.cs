using Godot;
using System;

[GlobalClass]
public partial class stats_test : Resource
{
	[Export] public int Health { get; set; }
	[Export] public int Speed { get; set; }
	[Export] public int MaxJumps { get; set; }
	[Export] public float JumpVelocity { get; set; }
	[Export] public float Gravity { get; set; }
	
	public string BotStats()
	{
		Health = 0;
		Speed = 0;
		MaxJumps = 0;
		JumpVelocity = 0.0f;
		Gravity = 0.0f;
		
		return "All done!";
	}
}
