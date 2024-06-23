using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    private Vector3 MouseV2; 
    private Camera MainCamera;
    public Transform BulletTransform;
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseV2 = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = MouseV2 - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ - 180);
        
        
    }
}
