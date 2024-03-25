using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool invincibility = false;
    private float PlayerMoveSpeed = 2;
    private int PlayerHP = 5;

    private void Awake()
    {
        
    }
    void Start()
    {
        invincibility = false;
        if(PlayerHP <= 0)
        {
            Dead();
        }
    }
    private void FixedUpdate()
    {
        
    }

    private void Move()
    {

    }
    
    private void Dead()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
