using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public bool invincibility = false;
    public int PlayerMoveSpeed = 10;
    public int PlayerHP = 5;
    // Start is called before the first frame update
    void Start()
    {
        invincibility = false;
        if(PlayerHP <= 0)
        {
            Dead();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Dead()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
