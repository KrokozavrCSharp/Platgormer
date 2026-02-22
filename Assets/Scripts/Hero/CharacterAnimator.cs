using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{    
    private readonly int _isRun = Animator.StringToHash("IsRun");
    private readonly int _isIdle = Animator.StringToHash("IsIdle");
    private readonly int _isJump = Animator.StringToHash("IsJump");
    private readonly int _isAttack = Animator.StringToHash("IsAttack");
    private readonly int _isWalked = Animator.StringToHash("IsWalked");

    private Animator _animation;

    private void Awake()
    {
        _animation=GetComponent<Animator>();
    }

    public void PlayRun(bool isRun)
    {
        _animation.SetBool(_isRun, isRun);
    }

    public void PlayIdle(bool isIdle)
    {
        _animation.SetBool(_isIdle, isIdle);
    }

    public void PlayJump(bool isJump)
    {
        _animation.SetBool(_isJump, isJump);
    }

    public void PlayAttack(bool isAttack)
    {
        _animation.SetBool(_isAttack, isAttack);
    }

    public void PlayWalked(bool isWalked)
    {
        _animation.SetBool(_isWalked, isWalked);
    }
    

}
