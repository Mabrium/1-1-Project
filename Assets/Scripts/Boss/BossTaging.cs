using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTaging : MonoBehaviour
{
    public BossHP BH;
    public Rigidbody2D Brd;
    public PlayerMove PMove;

    private void Awake()
    {
        Brd = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PMove.CollHit();
        }
        if (collision.CompareTag("Shotting"))
        {
            BH.Damage();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
