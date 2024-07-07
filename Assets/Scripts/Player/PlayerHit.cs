using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerMove PM;
    public CameraSS CS;

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
