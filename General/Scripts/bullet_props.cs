using Godot;
using System;

[GlobalClass]
public partial class bullet_props : Resource
{
	[Export] public int Damage { get; set;}
	[Export] public float InitialSpeed { get; set;}
	[Export] public float SpeedMultiplier { get; set;}
	[Export] public int MaxSpeed { get; set;}
	[Export] public float TimeUntilMaxSpeed { get; set;}
	[Export] public int AmountPerCycle { get; set;}
	
	public string BulletStats()
	{
		Damage = 0;
		InitialSpeed = 0;
		SpeedMultiplier = 0.0f;
		MaxSpeed = 0;
		TimeUntilMaxSpeed = 0.0f;
		AmountPerCycle = 0;
		
		return "All done!";
	}
}
