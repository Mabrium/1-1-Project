using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColliderNMove : MonoBehaviour
{
    public Collider2D[] move;
    public Sprite[] SPRITE;
    private SpriteRenderer SR;

    private int random;
    
    public bool afwo;
    public bool fawo;
    public bool faef;


    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    

    public void Switch()
    {
        random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                afwo = true;
                StartCoroutine(Change1());
                break;
            case 1:
                fawo = true;
                StartCoroutine(Change1_1());
                break;
            case 2:
                faef = true;
                StartCoroutine(Change2());
                break;
        }
        
        
        
    }

    public IEnumerator Change1()
    {
        
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (afwo)
        {
            for (int i = 0; i < 3; i++)
            {
                move[0].enabled = true;
                move[1].enabled = false;
                SR.sprite = SPRITE[0];
                yield return new WaitForSeconds(1f);
                move[0].enabled = false;
                move[1].enabled = true;
                SR.sprite = SPRITE[1];
                yield return new WaitForSeconds(1f);

            }
            afwo = false;
        }    
        Switch();
    }


    public IEnumerator Change1_1()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        if (fawo)
        {
            for (int i = 0; i < 3; i++)
            {
                move[0].enabled = true;
                move[1].enabled = false;
                SR.sprite = SPRITE[0];
                yield return new WaitForSeconds(1f);
                move[0].enabled = false;
                move[1].enabled = true;
                SR.sprite = SPRITE[1];
                yield return new WaitForSeconds(1f);

            }
            fawo = false;
        }
        Switch();
    }
    
    public IEnumerator Change2()
    {
        if (faef)
        {
            move[2].enabled = true;
            move[0].enabled = false;
            move[1].enabled = false;
            SR.sprite = SPRITE[2];
            yield return new WaitForSeconds(5f);
            move[0].enabled = true;
            move[2].enabled = false;
            SR.sprite = SPRITE[0];
            faef = false;
        }
        Switch();
    }
}
