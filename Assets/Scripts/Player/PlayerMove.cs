using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public PlayerHit PH;

    private Rigidbody2D Rd;
    public bool invincibility = false; //���� Ȯ��
    private int speed = 3; //�����̴� �ӵ�
    private int moveSpeed = 3; //������ �ӵ�
    private int dashSpeed = 30; //������ �ӵ�
    public int playerHP = 5; //�÷��̾� ü��

    public float SkillCoolTime; //��?��
    private float LastSkillTime = 0.5f; //��� ��Ÿ��
    
    private void Awake()
    {
        Rd = GetComponent<Rigidbody2D>();
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
        MoveSpace();
        
    }
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
    public void CollHit() //�¾�����
    {
        StartCoroutine(PH.Hit());
    }
    public void Dead() //����
    {
        StartCoroutine(DeadSceneChange());
    }
    public IEnumerator DeadSceneChange() //�׾ �� �ٲ�
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Map");
    }
}
