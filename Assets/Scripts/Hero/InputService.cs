using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string _Movement = "Horizontal";
    private const string _Jump = "Jump";

    private  float _directionY=0;
    private float _directionX;

    private void Update()
    {
        IsWalkPressed();
        IsJumpPressed();
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
}