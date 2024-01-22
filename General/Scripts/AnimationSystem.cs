using Godot;
using System;

public partial class AnimationSystem : Node
{
	private AnimatedSprite2D AnimatedSprite;
	public int currState = 5;
	
	public void Animate(int dir, NodePath path) {
		
		AnimatedSprite = GetNode<AnimatedSprite2D>(path + "/AnimatedSprite2D");
		
		if (currState != dir) {
			switch(dir) {
				case 0:  //Idle
					AnimatedSprite.Play("idle");
					currState = 0;
					GD.Print("Idling!!");
					break;
			}
		}
	}
}
