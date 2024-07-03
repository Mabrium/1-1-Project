using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public GameObject DeadEffect;
    public GameObject muzzle_flash;

    private SpriteRenderer SR;
    private Rigidbody2D Rd;

    public bool invincibility = false;  //무적 확인
    private int speed = 3;              //움직이는 속도
    private int moveSpeed = 3;          //움직일 속도
    private int dashSpeed = 30;         //움직일 속도
    public int playerHP = 30;            //플레이어 체력

    public float fadeDuration = 3.0f;
    private float currentAlpha = 0f;
    private float fadeTimer = 0f;
    public float SkillCoolTime;         //몰?루
    private float LastSkillTime = 0.5f; //대시 쿨타임

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

    private void MoveSpace() //스페이스 눌렀을때 무적되는거
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
    
    private void Move() //움직임
    {
        
        float Xinput = Input.GetAxis("Horizontal");
        float Yinput = Input.GetAxis("Vertical");

        Rd.velocity = new Vector2(Xinput * speed, Yinput * speed);
    }

    //===============================================================================================================================

    private IEnumerator Dash() //속도를 대시속도까지 올렸다가 다시 내려주는거
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(0.05f);
        speed = moveSpeed;
    }

    private IEnumerator InvincibilitySpace() //스페이스 눌렀을때 무적을 실행시켜주는거
    {
        StartCoroutine(Dash());
        invincibility = true;
        yield return new WaitForSeconds(0.3f);
        invincibility = false;
    }

    //===============================================================================================================================

    public void Dead() //죽음
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
        // 스프라이트 렌더러의 색상을 설정하여 알파값 변경
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
