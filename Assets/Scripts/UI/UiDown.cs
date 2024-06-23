using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class UiDown : MonoBehaviour
{
    public PlayerMove PM;
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(PM.playerHP == 0)
        {
            UIdown();
        }
    }
    public void UIdown()
    {
        animator.SetBool("UiDown", true);
    }
}
