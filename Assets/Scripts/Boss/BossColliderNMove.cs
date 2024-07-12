using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColliderNMove : MonoBehaviour
{
    public Food Fd;
    public ShotPoint SP;

    public GameObject hammer;
    public GameObject food;
    public GameObject Number;
    public GameObject ODSIJF;
    public GameObject FD;
    public Collider2D[] move;
    public Sprite[] SPRITE;
    private SpriteRenderer SR;

    private int random;
    
    public bool right_D; //������ ���
    public bool left_D;  //���� ���
    public bool right_T; //������ ��ô
    public bool left_T;  //���� ��ô


    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Invoke("Switch", 3f);
    }

    public void Switch()
    {
        random = Random.Range(0, 4);
        
        switch (random)
        {
            case 0:
                right_D = true;
                StartCoroutine(HHAAMMMEERR());
                StartCoroutine(Change1());
                break;
            case 1:
                left_D = true;
                StartCoroutine(HHAAMMMEERR());
                StartCoroutine(Change1_1());
                break;
            case 2:
                right_T = true;
                StartCoroutine(FFOOODDR());
                break;
            case 3:
                left_T = true;
                StartCoroutine(FFOOODDL());
                break;
        }


    }

    public IEnumerator Change1() //������ ������
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        ODSIJF.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (right_D)
        {
            for (int i = 0; i < 5; i++)
            {
                move[0].enabled = true;
                move[1].enabled = false;
                SR.sprite = SPRITE[0];
                yield return new WaitForSeconds(0.5f);
                move[0].enabled = false;
                move[1].enabled = true;
                SR.sprite = SPRITE[1];
                yield return new WaitForSeconds(0.5f);

            }
            right_D = false;
        }    
        Switch();
    }


    public IEnumerator Change1_1() //���� ������
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        ODSIJF.transform.rotation = Quaternion.Euler(0, 180, 0);
        if (left_D)
        {
            for (int i = 0; i < 5; i++)
            {
                move[0].enabled = true;
                move[1].enabled = false;
                SR.sprite = SPRITE[0];
                yield return new WaitForSeconds(0.5f);
                move[0].enabled = false;
                move[1].enabled = true;
                SR.sprite = SPRITE[1];
                yield return new WaitForSeconds(0.5f);

            }
            left_D = false;
        }
        Switch();
    }
    
    public IEnumerator Change2() //������ ���� ������
    {
        SP.patten = 0;
        SP.ShotOk1 = true;
        StartCoroutine(SP.PointChange());
        print("������");
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (right_T)
        {
            FD.SetActive(true);
            StartCoroutine(Fd.Throw());
            StartCoroutine(Fd.TThrow());
            move[2].enabled = true;
            move[0].enabled = false;
            move[1].enabled = false;
            SR.sprite = SPRITE[2];
            yield return new WaitForSeconds(10f);
            move[0].enabled = true;
            move[2].enabled = false;
            SR.sprite = SPRITE[0];
            FD.SetActive(false);
            right_T = false;
        }
        SP.patten = 10;
        SP.ShotOk1 = false;
        Switch();
    }
    public IEnumerator Change2_1() //���� ���� ������
    {
        SP.patten = 0;
        SP.ShotOk1 = true;
        StartCoroutine(SP.PointChange());
        print("����");
        transform.rotation = Quaternion.Euler(0, 180, 0);
        if (left_T)
        {
            FD.SetActive(true);
            StartCoroutine(Fd.Throw());
            StartCoroutine(Fd.TTThrow());
            move[2].enabled = true;
            move[0].enabled = false;
            move[1].enabled = false;
            SR.sprite = SPRITE[2];
            yield return new WaitForSeconds(10f);
            move[0].enabled = true;
            move[2].enabled = false;
            SR.sprite = SPRITE[0];
            FD.SetActive(false);
            left_T = false;
        }
        SP.patten = 10;
        SP.ShotOk1 = false;
        Switch();
    }






    private IEnumerator HHAAMMMEERR()
    {
        for(int i = 0; i < 2; i++)
        {
            hammer.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            hammer.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        Number.SetActive(true);
    }

    private IEnumerator FFOOODDR()
    {
        for (int i = 0; i < 2; i++)
        {
            food.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            food.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(Change2());
    }

    private IEnumerator FFOOODDL()
    {
        for (int i = 0; i < 2; i++)
        {
            food.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            food.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(Change2_1());
    }
}
