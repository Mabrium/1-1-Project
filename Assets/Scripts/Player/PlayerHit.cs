using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public UiDown UD;
    public PlayerMove PM;
    public CameraSS CS;

    /// <summary>
    /// 이 함수를 이용해서 플레이어의 체력을 깎는다
    /// </summary>
    /// <param name="Hit">이 함수는 양수를 이용하여 깎을 값을 설정할 것</param>
    /// <returns></returns>
    public void Hit(int Hit) 
    {
        if (!PM.invincibility)
        {
            PM.playerHP -= Hit;
            StartCoroutine(CS.Shake(0.5f, 0.3f));
            if (PM.playerHP <= 0)
            {
                PM.playerHP = 0;
                PM.invincibility = true;
                StartCoroutine(UD.LossUIdown());
                PM.Dead();
                PM.invincibility = false;
            }
            else
            {
                StartCoroutine(fkk());
            }

        }
    }

    private IEnumerator fkk()
    {
        print("실행1");
        PM.invincibility = true;
        yield return new WaitForSeconds(2.0f);
        print("실행2");
        PM.invincibility = false;
    }
}
