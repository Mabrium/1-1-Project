using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public GameObject DeadEffect;
    public GameObject muzzle_flash;

    private SpriteRenderer SR;
    private Rigidbody2D Rd;

    public bool invincibility = false;  //���� Ȯ��
    private int speed = 3;              //�����̴� �ӵ�
    private int moveSpeed = 3;          //������ �ӵ�
    private int dashSpeed = 30;         //������ �ӵ�
    public int playerHP = 30;            //�÷��̾� ü��

    public float fadeDuration = 3.0f;
    private float currentAlpha = 0f;
    private float fadeTimer = 0f;
    public float SkillCoolTime;         //��?��
    private float LastSkillTime = 0.5f; //��� ��Ÿ��

    public bool DeadMoving;
    //===============================================================================================================================
    private void Awake()
    {
        
        SR = GetComponent<SpriteRenderer>();
        Rd = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        speed = moveSpeed;
        LastSkillTime = Time.time;
        StartCoroutine(Starting());
        invincibility = false;

    }
    private void Update()
    {
        if (!DeadMoving)
        {
            Move();
            MoveSpace();
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
        yield return new WaitForSeconds(0.05f);
        speed = moveSpeed;
    }

    private IEnumerator InvincibilitySpace() //�����̽� �������� ������ ��������ִ°�
    {
        StartCoroutine(Dash());
        invincibility = true;
        yield return new WaitForSeconds(0.3f);
        invincibility = false;
    }

    //===============================================================================================================================

    public void Dead() //����
    {
        SR.color = Color.clear;
        muzzle_flash.SetActive(false);
        DeadEffect.SetActive(true);
        Rd.constraints = RigidbodyConstraints2D.FreezePosition;
        DeadMoving = true;
    }


    //===============================================================================================================================

    private IEnumerator Starting()
    {
        DeadMoving = true;
        yield return new WaitForSeconds(3f);
        DeadMoving = false;
    }


    void SetSpriteAlpha(float alpha)
    {
        // ��������Ʈ �������� ������ �����Ͽ� ���İ� ����
        Color color = SR.color;
        color.a = alpha;
        SR.color = color;
    }

    private void Alpha()
    {
        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            currentAlpha = Mathf.Lerp(0.0f, 1.0f, fadeTimer / fadeDuration);
            SetSpriteAlpha(currentAlpha);
        }
    }
}
