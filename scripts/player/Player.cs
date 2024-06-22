using Godot;

public partial class Player : CharacterBody2D
{
	[Export] private float moveSpeed;
	[Export] private float jumpVelocity;

	public float MoveSpeed => moveSpeed;
	public float JumpVelocity => jumpVelocity * -1f;	// * -1 to make the input in the editor more intuitive

	private IMovementController controller;
	

	public static Player Instance => _instance;
	private static Player _instance;

    public override void _EnterTree()
    {
		if(_instance == null){
			_instance = this;
		}

		if(controller == null){
			controller = new PlayerController();
		}
    }

    public override void _PhysicsProcess(double delta)
	{
		Velocity = controller.move(delta);
		MoveAndSlide();
	}
}
