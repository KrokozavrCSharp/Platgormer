using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{    
    private readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    private readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    private readonly int IsJump = Animator.StringToHash(nameof(IsJump));
    private readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    private readonly int IsAttacked = Animator.StringToHash(nameof(IsAttacked));
    private readonly int IsWalked = Animator.StringToHash(nameof(IsWalked));

    private Animator _animation;

    private void Awake()
    {
        _animation=GetComponent<Animator>();
    }

    public void PlayRun(bool isRun)
    {
        _animation.SetBool(IsRun, isRun);
    }

    public void PlayIdle(bool isIdle)
    {
        _animation.SetBool(IsIdle, isIdle);
    }

    public void PlayJump(bool isJump)
    {
        _animation.SetBool(IsJump, isJump);
    }

    public void PlayAttack(bool isAttack)
    {
        _animation.SetBool(IsAttack, isAttack);
    }

    public void PlayWalked(bool isWalked)
    {
        _animation.SetBool(IsWalked, isWalked);
    }
    

}
