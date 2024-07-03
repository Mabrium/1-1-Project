using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTaging : MonoBehaviour
{
    public BossHP BH;
    public PlayerHit PH;

    
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(PH.Hit());
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shotting"))
        {
            BH.Damage();
        }
    }
    void Update()
    {
        
    }


}
