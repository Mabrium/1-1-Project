using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int BossHp = 1000;
    public bool BossDie;

    void Start()
    {
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

    private void BossDead()
    {
        if (BossDie)
        {
            this.gameObject.SetActive(false);

        }

    }

    private void EndUIDown()
    {
        
    }
}
