using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] private float moveSpeed;

	private static IMovementController topDownMovementController;

    public override void _EnterTree()
    {
		if(topDownMovementController == null){
        	topDownMovementController = new PlayerTopDownMovementController(moveSpeed);
		}
    }

    public override void _PhysicsProcess(double delta)
	{
		Velocity = topDownMovementController.move();
		MoveAndSlide();
	}
}
