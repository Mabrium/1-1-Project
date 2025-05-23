using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject ShootPosition;
    public PlayerMove PM;
    private bool MouseDown;

    private void Start()
    {
        MouseDown = false;
    }
    void Update()
    {
        
        if (!PM.DeadMoving)
        {
            if (!MouseDown)
            {
                if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Return))
                {
                    StartCoroutine(ShootProjectile());
                }
            }
            
        }
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // z축을 0으로 고정

        // 발사대 위치를 기준으로 마우스 방향 구하기
        Vector3 direction = (mousePosition - transform.position).normalized;

        // 마우스 방향으로 발사대가 바라보도록 회전 설정
        transform.right = direction;
        
    }
    IEnumerator ShootProjectile()
    {
        MouseDown = true;
        // 프리팹을 인스턴스화하여 발사
        GameObject projectile = Instantiate(projectilePrefab, ShootPosition.transform.position, ShootPosition.transform.rotation);

        // 발사 방향 설정 (발사대가 바라보는 방향)
        projectile.GetComponent<Rigidbody2D>().velocity = -transform.right * 10f; // 발사 속도 설정

        // 발사한 프리팹이 일정 시간 후에 자동으로 파괴되도록 설정
        Destroy(projectile, 2.0f);
        yield return new WaitForSeconds(0.3f);
        MouseDown = false;
    }
}
