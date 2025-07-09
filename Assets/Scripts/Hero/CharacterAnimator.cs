using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{    
    private readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    private readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    private readonly int IsJump = Animator.StringToHash(nameof(IsJump));

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
}
