using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator animation;

    private void Awake()
    {
        animation=GetComponent<Animator>();
    }

    public void PlayRun(bool isRun)
    {
        animation.SetBool("IsRun", isRun);
    }

    public void PlayIdle(bool isRun)
    {
        animation.SetBool("IsRun", isRun);
    }

    public void PlayJump(bool isJump)
    {
        animation.SetBool("IsJump", isJump);
    }
}
