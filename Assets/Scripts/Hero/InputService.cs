using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Movement = "Horizontal";
    private const string Jump = "Jump";

    private bool _isWalkPressed;
    private bool _isJumpPressed;
    private bool _isAttackPressed;

    public bool IsWalkPressed => _isWalkPressed;
    public bool IsJumpPressed => _isJumpPressed;
    public bool IsAttackPressed => _isAttackPressed;

    private void Update()
    {
        _isWalkPressed= IsWalk();
        _isJumpPressed = IsJumped();
        _isAttackPressed=IsAttacked();
    }

    public bool IsWalk()
    {
        return Input.GetButton(Movement);
    }

    public float GetMovement()
    {
        return Input.GetAxisRaw(Movement);
    }

    public bool IsJumped()
    {
        return Input.GetButton(Jump);
    }

    public bool IsAttacked()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}