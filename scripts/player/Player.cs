using Godot;

public partial class Player : CharacterBody2D
{
	[Export] private float moveSpeed;
	[Export] private float jumpVelocity;

	public float MoveSpeed => moveSpeed;
	public float JumpVelocity => jumpVelocity * -1f;	// * -1 to make the input in the editor more intuitive

	private IMovementController controller;

    public override void _EnterTree()
    {
		if(controller == null){
			controller = PlayerController.builder()
							.player(this)
							.build();
		}
    }

    public override void _PhysicsProcess(double delta)
	{
		Velocity = controller.move(delta);
		MoveAndSlide();
	}
}
