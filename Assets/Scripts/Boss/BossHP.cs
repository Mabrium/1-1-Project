using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int BossHp = 20;
    public bool BossDie; //죽었니? 살았니?

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

    private void BossDead() //보스가 죽었을시 안 보이게 하기
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
