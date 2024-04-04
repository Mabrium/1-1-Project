using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public SceneMove SM;

    private SpriteRenderer Sr;
    private Rigidbody2D Rd;
    public bool invincibility = false; //���� Ȯ��
    private int speed = 3; //�����̴� �ӵ�
    private int moveSpeed = 3; //������ �ӵ�
    private int dashSpeed = 40; //������ �ӵ�
    public int playerHP = 5; //�÷��̾� ü��
    private int HitColor = 255; //�ǰ� �޾����� �÷��̾��� ����� ����

    public float SkillCoolTime; //��?��
    private float LastSkillTime = 0.5f; //��� ��Ÿ��
    
    private void Awake()
    {
        Rd = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        speed = moveSpeed;
        LastSkillTime = Time.time;

        invincibility = false;
        if(playerHP <= 0)
        {
            invincibility = true;
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

        Rd.velocity = new Vector2(Xinput * speed, Yinput * speed);
    }
    

    private void Dead()
    {
        StartCoroutine(DeadSceneChange());

    }
    public IEnumerator DeadSceneChange()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Map");
    }

    private IEnumerator Dash()
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(0.04f);
        speed = moveSpeed;
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
        if (!invincibility)
        {
            playerHP -= 1;
            if(playerHP <= 0)
            {
                invincibility = true;
                Dead();
            }
            else
            {
                StartCoroutine(ChangePlayerColor());
                invincibility = true;
                Sr.color = new Color(HitColor, HitColor, HitColor);
                yield return new WaitForSeconds(2.0f);
                invincibility = false;
            }

        }
    }
    
    private IEnumerator ChangePlayerColor()
    {
        while (HitColor < 255)
        {
            HitColor++;
            yield return Time.deltaTime;
        }
        while (HitColor > 0)
        {
            HitColor--;
            yield return Time.deltaTime;
        }
    }
}
