using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public PlayerHit PH;

    private Rigidbody2D Rd;
    private SpriteRenderer SR;

    public bool invincibility = false; //���� Ȯ��

    private int speed = 3;              //�����̴� �ӵ�
    private int moveSpeed = 3;          //������ �ӵ�
    private int dashSpeed = 30;         //������ �ӵ�
    public int playerHP = 5;            //�÷��̾� ü��

    public float SkillCoolTime;         //��?��
    private float Alpha = 0;            //�̹��� ���İ�
    private float LastSkillTime = 0.5f; //��� ��Ÿ��
    //===============================================================================================================================
    private void Awake()
    {
        Rd = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        //SR.color = new Color(255, 255, 255, 0);
        ///StartCoroutine(Spawn());
        speed = moveSpeed;
        LastSkillTime = Time.time;

        invincibility = false;

    }
    private void Update()
    {
        Move();
        MoveSpace();
        
    }
    //===============================================================================================================================

    private IEnumerator Spawn()
    {
        SR.color = new Color(255, 255, 255, Alpha);
        if(Alpha < 255)
        {
            Alpha += 1/10;
            yield return new WaitForSeconds(Time.deltaTime/3);
        }
    }




    //===============================================================================================================================
    private void MoveSpace() //�����̽� �������� �����Ǵ°�
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ((Time.time - LastSkillTime) > SkillCoolTime)
            {

                LastSkillTime = Time.time;
                StartCoroutine(InvincibilitySpace());
            }
        }
    }
    
    private void Move() //������
    {
        
        float Xinput = Input.GetAxis("Horizontal");
        float Yinput = Input.GetAxis("Vertical");

        Rd.velocity = new Vector2(Xinput * speed, Yinput * speed);
    }

    //===============================================================================================================================

    private IEnumerator Dash() //�ӵ��� ��üӵ����� �÷ȴٰ� �ٽ� �����ִ°�
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(0.04f);
        speed = moveSpeed;
    }

    private IEnumerator InvincibilitySpace() //�����̽� �������� ������ ��������ִ°�
    {
        StartCoroutine(Dash());
        invincibility = true;
        yield return new WaitForSeconds(0.2f);
        invincibility = false;
    }

    //===============================================================================================================================

    public void CollHit() //�¾�����
    {
        StartCoroutine(PH.Hit());
    }
    public void Dead() //����
    {
        //StartCoroutine(DeadSceneChange());
    }
    public IEnumerator DeadSceneChange() //�׾ �� �ٲ�
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Map");
    }

    //===============================================================================================================================
}
