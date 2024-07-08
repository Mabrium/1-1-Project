using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int BossHp = 100;
    public UiDown UD;
    void Start()
    {
        BossHp = 100;
    }

    

    public IEnumerator Damage()
    {
        BossHp += -1;
        if( BossHp <= 0 )
        {
            gameObject.SetActive(false);
            StartCoroutine(UD.WinUIdown());
            yield return new WaitForSeconds(2f);
            Time.timeScale = 0;
        }
    }


}
