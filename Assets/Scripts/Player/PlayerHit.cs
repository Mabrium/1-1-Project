using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerMove PM;
    public CameraSS CS;

    /// <summary>
    /// 이 함수를 이용해서 플레이어의 체력을 깎는다
    /// </summary>
    /// <param name="Hit">이 함수는 양수를 이용하여 깎을 값을 설정할 것</param>
    /// <returns></returns>
    public IEnumerator Hit(int Hit) 
    {
        if (!PM.invincibility)
        {
            PM.playerHP -= Hit;
            StartCoroutine(CS.Shake(0.5f, 0.3f));
            if (PM.playerHP <= 0)
            {
                PM.invincibility = true;
                PM.Dead();
            }
            else
            {
                PM.invincibility = true;
                yield return new WaitForSeconds(2.0f);
                PM.invincibility = false;
            }

        }
    }
}
