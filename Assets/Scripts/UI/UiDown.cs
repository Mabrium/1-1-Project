using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class UiDown : MonoBehaviour
{
    public PlayerMove PM;
    public BossHP BH;
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update() //�÷��̾ �׾��ٸ� UIâ ������
    {
        if(PM.playerHP <= 0)
        {
            LossUIdown();
        }
        if(BH.BossHp <= 0)
        {
            WinUIdown();
        }
    }
    public void LossUIdown()
    {
        animator.SetBool("LossUiDown", true);
    }

    public void WinUIdown()
    {
        animator.SetBool("WinUiDown", true);
    }
}
