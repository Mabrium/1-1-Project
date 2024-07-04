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

    void Update() //플레이어가 마우스 바라보는거 확인및 발사체 관리
    {
        MouseV2 = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = MouseV2 - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ - 180);
        
        
    }
}
