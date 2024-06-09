using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private SpriteRenderer Sr;
    public PlayerMove PM;
    public int playerHP = 5; //플레이어 체력
    private int HitColor = 255; //피격 받았을때 플레이어의 변경될 색상
    
    private void Awake()
    {
        Sr = GetComponent<SpriteRenderer>();
    }
    public IEnumerator Hit() //맞아서 체력 깎이고 색상 변하고 그런거
    {
        if (!PM.invincibility)
        {
            playerHP -= 1;
            if (playerHP <= 0)
            {
                PM.invincibility = true;
                PM.Dead();
            }
            else
            {
                StartCoroutine(ChangePlayerColor());
                PM.invincibility = true;
                Sr.color = new Color(HitColor, HitColor, HitColor);
                yield return new WaitForSeconds(2.0f);
                PM.invincibility = false;
            }

        }
    }

    private IEnumerator ChangePlayerColor()
    {
        if (HitColor < 255)
        {
            while (HitColor < 255)
            {
                HitColor++;
                yield return Time.deltaTime;
            }
        }
        else
        {
            while (HitColor > 0)
            {
                HitColor--;
                yield return Time.deltaTime;
            }
        }
    }
}
