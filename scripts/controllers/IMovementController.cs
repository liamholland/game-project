using Godot;

public interface IMovementController {
    Vector2 move();

    bool isGrounded();
}