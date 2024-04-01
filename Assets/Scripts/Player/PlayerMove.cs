using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D Rd;
    public bool invincibility = false; //무적 확인
    private int Speed = 3; //움직이는 속도
    private int MoveSpeed = 3; //움직일 속도
    private int DashSpeed = 20; //움직일 속도
    public int PlayerHP = 5; //플레이어 체력

    public float SkillCoolTime; //대시 쿨타임
    private float LastSkillTime = 0.5f; //몰?루 규민이에게 물어보셈
    
    private void Awake()
    {
        Rd = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Speed = MoveSpeed;
        LastSkillTime = Time.time;

        invincibility = false;
        if(PlayerHP <= 0)
        {
            Dead();
        }
    }
    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveSpace();
        }
    }
    private void MoveSpace()
    {
        if((Time.time - LastSkillTime) > SkillCoolTime)
        {

            LastSkillTime = Time.time;
            StartCoroutine(InvincibilitySpace());
        }
    }
    
    private void Move()
    {
        
        float Xinput = Input.GetAxis("Horizontal");
        float Yinput = Input.GetAxis("Vertical");

        Rd.velocity = new Vector2(Xinput * Speed, Yinput * Speed);
    }
    

    private void Dead()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("HitObject"))
        {
            StartCoroutine(Hit());
        }
        
    }

    private IEnumerator Dash()
    {
        Speed = DashSpeed;
        yield return new WaitForSeconds(0.07f);
        Speed = MoveSpeed;
    }

    private IEnumerator InvincibilitySpace()
    {
        StartCoroutine(Dash());
        invincibility = true;
        yield return new WaitForSeconds(0.1f);
        invincibility = false;
    }

    private IEnumerator Hit()
    {
        PlayerHP -= 1;
        if(PlayerHP <= 0)
        {
            invincibility = true;
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
