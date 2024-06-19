using Godot;

public class PlayerTopDownMovementController : IMovementController
{

    public float Speed => _speed;

    private float _speed;

    public PlayerTopDownMovementController(float moveSpeed){
        _speed = moveSpeed;
    }

    public Vector2 move()
    {
        return Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down") * _speed;
    }

    public bool isGrounded()
    {
        return true;
    }
}