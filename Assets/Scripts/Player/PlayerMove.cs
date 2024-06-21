using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public PlayerHit PH;

    private Rigidbody2D Rd;
    private SpriteRenderer SR;

    public bool invincibility = false; //무적 확인

    private int speed = 3;              //움직이는 속도
    private int moveSpeed = 3;          //움직일 속도
    private int dashSpeed = 30;         //움직일 속도
    public int playerHP = 5;            //플레이어 체력

    public float SkillCoolTime;         //몰?루
    private float Alpha = 0;            //이미지 알파값
    private float LastSkillTime = 0.5f; //대시 쿨타임
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
        yield return new WaitForSeconds(0.04f);
        speed = moveSpeed;
    }

    private IEnumerator InvincibilitySpace() //스페이스 눌렀을때 무적을 실행시켜주는거
    {
        StartCoroutine(Dash());
        invincibility = true;
        yield return new WaitForSeconds(0.2f);
        invincibility = false;
    }

    //===============================================================================================================================

    public void CollHit() //맞았을때
    {
        StartCoroutine(PH.Hit());
    }
    public void Dead() //죽음
    {
        //StartCoroutine(DeadSceneChange());
    }
    public IEnumerator DeadSceneChange() //죽어서 씬 바뀜
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Map");
    }

    //===============================================================================================================================
}
