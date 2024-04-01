using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D Rd;
    public bool invincibility = false; //���� Ȯ��
    private int Speed = 3; //�����̴� �ӵ�
    private int MoveSpeed = 3; //������ �ӵ�
    private int DashSpeed = 40; //������ �ӵ�
    public int PlayerHP = 5; //�÷��̾� ü��

    public float SkillCoolTime; //��?��
    private float LastSkillTime = 0.5f; //��� ��Ÿ��
    
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

    private IEnumerator Dash()
    {
        Speed = DashSpeed;
        yield return new WaitForSeconds(0.04f);
        Speed = MoveSpeed;
    }

    private IEnumerator InvincibilitySpace()
    {
        StartCoroutine(Dash());
        invincibility = true;
        yield return new WaitForSeconds(0.2f);
        invincibility = false;
    }

    public void CollHit()
    {
        StartCoroutine(Hit());
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
