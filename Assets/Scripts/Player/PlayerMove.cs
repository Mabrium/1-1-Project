using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D Rd;
    public bool invincibility = false;
    private int MoveSpeed = 3;
    public int PlayerHP = 5;
    private int CullTime = 1;
    
    private void Awake()
    {
        Rd = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        invincibility = false;
        if(PlayerHP <= 0)
        {
            Dead();
        }
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
        float Xinput = Input.GetAxis("Horizontal");
        float Yinput = Input.GetAxis("Vertical");

        Rd.velocity = new Vector2(Xinput * MoveSpeed, Yinput * MoveSpeed);
    }
    
    private IEnumerator CullTimeCheck()
    {
        if(CullTime >= 0)
        {

            yield return new WaitForSeconds(1.0f);
        }
    }

    private void Dead()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.CompareTag("HitObject"))
        {
            StartCoroutine(Hit());
        }
    }

    private IEnumerator InvincibilitySpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            invincibility = true;
            yield return new WaitForSeconds(0.2f);
            invincibility = false;
        }
    }

    private IEnumerator Hit()
    {
        PlayerHP -= 1;
        if(PlayerHP <= 0)
        {
            Dead();
        }
        else
        {
            invincibility = true;
            yield return new WaitForSeconds(2.0f);
            invincibility = false;
        }
    }
}
