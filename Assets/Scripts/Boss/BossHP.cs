using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int BossHp = 100;
    public UiDown UD;
    void Start()
    {
        //BossHp = 100;
    }

    

    public void Damage()
    {
        BossHp += -1;
        if( BossHp <= 0 )
        {
            StartCoroutine(UD.WinUIdown());
            gameObject.SetActive(false);
        }
    }


}
