using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public GameObject ObjectPool;
    public int BossHp = 100;
    public bool BossDie = false;

    void Start()
    {
        
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

    private void BossDead()
    {
        if(BossDie)
        {
            ObjectPool.active = false;
        }

    }
}
