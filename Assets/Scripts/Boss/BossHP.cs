using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int BossHp = 20;
    public bool BossDie; //�׾���? ��Ҵ�?

    void Start()
    {
        BossHp = 20;
        BossDie = false;

    }

    void Update()
    {
        BossDead();
    }

    public void Damage()
    {
        BossHp += -1;

        if( BossHp <= 0)
        {
            BossDie = true;
        }
    }

    private void BossDead() //������ �׾����� �� ���̰� �ϱ�
    {
        if (BossDie)
        {
            gameObject.SetActive(false);
        }

    }

    private void EndUIDown()
    {
        
    }
}
