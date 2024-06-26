using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColliderNMove : MonoBehaviour
{
    public Collider2D[] move;
    public Sprite[] SPRITE;
    private SpriteRenderer SR;


    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(Change());
    }


    private IEnumerator Change()
    {
        move[0].enabled = true;
        move[1].enabled = false;
        SR.sprite = SPRITE[0];
        yield return new WaitForSeconds(1f);
        move[0].enabled = false;
        move[1].enabled = true;
        SR.sprite = SPRITE[1];
        yield return new WaitForSeconds(1f);
        yield return Change();
    }


}
