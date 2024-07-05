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
    private void Update() //플레이어가 죽었다면 UI창 내리기
    {
        if(PM.playerHP <= 0)
        {
            StartCoroutine(LossUIdown());
        }
        if(BH.BossHp <= 0)
        {
            StartCoroutine(WinUIdown());
        }
    }
    public IEnumerator LossUIdown()
    {
        animator.SetBool("LossUiDown", true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }

    public IEnumerator WinUIdown()
    {
        animator.SetBool("WinUiDown", true);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }
}
