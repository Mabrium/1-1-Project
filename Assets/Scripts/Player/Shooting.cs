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
                if (Input.GetMouseButton(0))
                {
                    StartCoroutine(ShootProjectile());
                }
            }
            
        }
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // z���� 0���� ����

        // �߻�� ��ġ�� �������� ���콺 ���� ���ϱ�
        Vector3 direction = (mousePosition - transform.position).normalized;

        // ���콺 �������� �߻�밡 �ٶ󺸵��� ȸ�� ����
        transform.right = direction;
        
    }
    IEnumerator ShootProjectile()
    {
        MouseDown = true;
        // �������� �ν��Ͻ�ȭ�Ͽ� �߻�
        GameObject projectile = Instantiate(projectilePrefab, ShootPosition.transform.position, ShootPosition.transform.rotation);

        // �߻� ���� ���� (�߻�밡 �ٶ󺸴� ����)
        projectile.GetComponent<Rigidbody2D>().velocity = -transform.right * 10f; // �߻� �ӵ� ����

        // �߻��� �������� ���� �ð� �Ŀ� �ڵ����� �ı��ǵ��� ����
        Destroy(projectile, 2.0f);
        yield return new WaitForSeconds(0.3f);
        MouseDown = false;
    }
}
