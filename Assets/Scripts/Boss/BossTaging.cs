using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTaging : MonoBehaviour
{
    public BossHP BH;
    public Rigidbody2D Brd;
    public PlayerHit PH;

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
            StartCoroutine(PH.Hit());
        }
        if (collision.CompareTag("Shotting"))
        {
            BH.Damage();
        }
    }

    void Update()
    {
        
    }


}
