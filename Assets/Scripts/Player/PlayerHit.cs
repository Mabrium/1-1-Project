using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerMove PM;

    
    public IEnumerator Hit() 
    {
        if (!PM.invincibility)
        {
            PM.playerHP -= 1;
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
