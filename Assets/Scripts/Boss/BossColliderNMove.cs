using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColliderNMove : MonoBehaviour
{
    public Collider2D[] move;


    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private IEnumerator Change()
    {
        yield return new WaitForSeconds(3f);
    }


}
