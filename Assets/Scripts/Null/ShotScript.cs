using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public Rigidbody2D Srd;
    [SerializeField] PlayerMove PMove;

    private void Awake()
    {
        Srd = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PMove.CollHit();
        }
    }
}
