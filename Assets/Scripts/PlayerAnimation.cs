using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isRunning)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    public void SetDieAnimation(bool condition)
    {
        animator.SetBool("Die", condition);
    }

    public void SetReachedAnimation(bool condition)
    {
        animator.SetBool("IsReached", condition);
    }
}
