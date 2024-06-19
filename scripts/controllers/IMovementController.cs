using Godot;

public interface IMovementController {
    Vector2 move(double delta);

    bool isGrounded();
}