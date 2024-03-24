using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool invincibility = false;
    private int PlayerMoveSpeed = 2;
    private int PlayerHP = 5;

    void Start()
    {
        invincibility = false;
        if(PlayerHP <= 0)
        {
            Dead();
        }
    }


    void Update()
    {
        PlayMove();
    }

    private void PlayMove()
    {
        
        
    }
    private void Dead()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
