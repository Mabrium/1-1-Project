using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public Rigidbody2D Srd;
    public PlayerHit PH;

    private void Awake()
    {
        Srd = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(PH.Hit(1));
        }
    }
}
