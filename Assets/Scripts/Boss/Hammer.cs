using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public PlayerHit PH;
    public Number number;
    private int Atk;
    public Rigidbody2D R2D;
    float random1;
    float random2;
    int speed = 700;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (number.random == 0) { Atk = 1; }
        else if (number.random == 1) { Atk = 2; }
        else if (number.random == 2) { Atk = 4; }
        else if (number.random == 3) { Atk = 7; }
        else if (number.random == 4) { Atk = 10; }
        else if (number.random == 5) { Atk = 15; }
        else if (number.random == 6) { Atk = 20; }
        else if (number.random == 7) { Atk = 25; }
        else if (number.random == 8) { Atk = 999; }
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PH.Hit(Atk));
            print(Atk);
        }
    }

    public void On()
    {
        Move();
        StartCoroutine(Destroy());
    }
    private void Move()
    {
        random1 = Random.Range(-1, 2);
        random2 = Random.Range(-1, 2);
        while (random1 == 0)
            random1 = Random.Range(-1, 2);
        while(random2 == 0)
            random2 = Random.Range(-1, 2);

        Vector2 dir = new Vector2(random1, random2).normalized;

        R2D.AddForce(dir * speed);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5.0f);

        gameObject.transform.position = Vector2.zero;
        gameObject.SetActive(false);
    }
}
