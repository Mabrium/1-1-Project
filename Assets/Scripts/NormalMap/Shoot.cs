using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Prefab;
    //public GameObject[] ShootingObject;
    [SerializeField] private float shootForce = 10f; // �߻� �ӵ� ����
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
        // ���� ������Ʈ�� ��ġ�� ����
        Vector3 spawnPosition = transform.position;
        float spawnRotation = transform.eulerAngles.z; // ���� ������Ʈ�� Z�� ȸ�� ����

        // 5����� ������ ���
        float angleIncrement = 360f / 5;

        // �� �������� �߻�
        for (int i = 0; i < 5; i++)
        {
            // ���� ���
            float angle = spawnRotation + i * angleIncrement;

            // ������ �������� ��ȯ
            float angleRad = angle * Mathf.Deg2Rad;

            // �߻� ���� ���
            Vector2 shootDirection = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

            // ������Ÿ�� ����
            GameObject projectile = Instantiate(Prefab, spawnPosition, Quaternion.identity);

            // �߻� ����� �ӵ� ����
            
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
