using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string _Movement = "Horizontal";
    private const string _Jump = "Jump";
    private const string _Attack = "Fire2";

    private void Update()
    {
        IsWalkPressed();
        IsJumpPressed();
        IsAttacked();
    }

    public bool IsWalkPressed()
    {
        return Input.GetButton(_Movement);
    }

    public float GetMovement()
    {
        return Input.GetAxisRaw(_Movement);
    }

    public bool IsJumpPressed()
    {
        return Input.GetButton(_Jump);
    }

    public bool IsAttacked()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}