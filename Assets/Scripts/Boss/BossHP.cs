using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int BossHp = 20;

    void Start()
    {
        BossHp = 20;

    }

    

    public IEnumerator Damage()
    {
        BossHp += -1;

        if( BossHp <= 0 )
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(2f);
            Time.timeScale = 0;
        }
    }


    private void EndUIDown()
    {
        
    }
}
