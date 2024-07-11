using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public UiDown UD;
    public PlayerMove PM;
    public CameraSS CS;

    /// <summary>
    /// �� �Լ��� �̿��ؼ� �÷��̾��� ü���� ��´�
    /// </summary>
    /// <param name="Hit">�� �Լ��� ����� �̿��Ͽ� ���� ���� ������ ��</param>
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
        print("����1");
        PM.invincibility = true;
        yield return new WaitForSeconds(2.0f);
        print("����2");
        PM.invincibility = false;
    }
}
