using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerMove PM;

    /// <summary>
    /// �� �Լ��� �̿��ؼ� �÷��̾��� ü���� ��´�
    /// </summary>
    /// <param name="Hit">�� �Լ��� ����� �̿��Ͽ� ���� ���� ������ ��</param>
    /// <returns></returns>
    public IEnumerator Hit(int Hit) 
    {
        if (!PM.invincibility)
        {
            PM.playerHP -= Hit;
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
