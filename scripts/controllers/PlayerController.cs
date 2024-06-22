using Godot;

public class PlayerController : IMovementController
{
    private Player player;
    private bool isTopDownMode = false; //to be replaced by a mode controller

	private static float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public PlayerController(){
        player = Player.Instance;
    }

    public bool isGrounded(){
        if(isTopDownMode){
            return true;
        }
        else{
            return player.IsOnFloor();
        }
    }

    public Vector2 move(double delta){
        Vector2 moveDirection = new Vector2(0, 0);

        Vector2 inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        if(isTopDownMode){
            moveDirection = inputVector * player.MoveSpeed;
        }
        else{
            //handle jump and gravity
            if(Input.IsActionJustPressed("ui_accept") && isGrounded()){
                moveDirection.Y = player.JumpVelocity;
            }
            else if(!isGrounded()){
                moveDirection.Y = player.Velocity.Y + (gravity * (float)delta);
            }
            
            moveDirection.X = inputVector.X * player.MoveSpeed;
        }

        return moveDirection;
    }
}
