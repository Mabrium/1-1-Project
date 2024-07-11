using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Prefab;
    //public GameObject[] ShootingObject;
    [SerializeField] private float shootForce = 10f; // 발사 속도 조절
    [SerializeField] private float projectileLifetime = 2f;

    

    private void OnEnable()
    {
        StartCoroutine(ShootInDirections());
    }
    //private void Shooting()
    //{
    //    int Num = 5;
    //    for (int index = 0; index < Num; index++)
    //    {
    //        ShootingObject = new GameObject[5];
    //    }
    //    Generate();
    //}

    //private void Generate()
    //{
    //    for (int index = 0; index < ShootingObject.Length; index++)
    //    {
    //        ShootingObject[index] = Instantiate(Prefab);
    //        ShootingObject[index].SetActive(false);
    //    }
    //}

    private IEnumerator ShootInDirections()
    {
        // 현재 오브젝트의 위치와 각도
        Vector3 spawnPosition = transform.position;
        float spawnRotation = transform.eulerAngles.z; // 현재 오브젝트의 Z축 회전 각도

        // 5등분한 각도를 계산
        float angleIncrement = 360f / 5;

        // 각 방향으로 발사
        for (int i = 0; i < 5; i++)
        {
            // 각도 계산
            float angle = spawnRotation + i * angleIncrement;

            // 각도를 라디안으로 변환
            float angleRad = angle * Mathf.Deg2Rad;

            // 발사 방향 계산
            Vector2 shootDirection = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

            // 프로젝타일 생성
            GameObject projectile = Instantiate(Prefab, spawnPosition, Quaternion.identity);

            // 발사 방향과 속도 설정
            
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
            }
            Destroy(projectile, projectileLifetime);
        }
        yield return null;
        gameObject.SetActive(false);

    }
}
