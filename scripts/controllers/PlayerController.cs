using Godot;

public class PlayerController : IMovementController
{
    public Player Player => _player;

    private Player _player;
    private bool isTopDownMode = false; //to be replaced by a mode controller

	private static float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    private PlayerController(Player player){
        _player = player;
    }

    public bool isGrounded(){
        if(isTopDownMode){
            return true;
        }
        else{
            return Player.IsOnFloor();
        }
    }

    public Vector2 move(double delta){
        Vector2 moveDirection = new Vector2(0, 0);

        Vector2 inputVector = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        if(isTopDownMode){
            moveDirection = inputVector * Player.MoveSpeed;
        }
        else{
            //handle jump and gravity
            if(Input.IsActionJustPressed("ui_accept") && isGrounded()){
                moveDirection.Y = Player.JumpVelocity;
            }
            else if(!isGrounded()){
                moveDirection.Y = Player.Velocity.Y + (gravity * (float)delta);
            }
            
            moveDirection.X = inputVector.X * Player.MoveSpeed;
        }

        return moveDirection;
    }

    public static Builder builder(){
        return new Builder();
    }

    public class Builder
    {
        private Player body;

        public Builder player(Player body){
            this.body = body;
            return this;
        }

        public PlayerController build(){
            return new PlayerController(body);
        }
    }
}
