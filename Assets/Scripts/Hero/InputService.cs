using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Movement = "Horizontal";
    private const string Jump = "Jump";

    public bool IsWalkPressed()
    {
        return Input.GetButton(Movement);
    }

    public float GetMovement()
    {
        return Input.GetAxisRaw(Movement);
    }

    public bool IsJumpPressed()
    {
        return Input.GetButton(Jump);
    }

    public bool IsAttacked()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}