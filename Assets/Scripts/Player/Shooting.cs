using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject ShootPosition;
    public PlayerMove PM;
    private bool fojwsi;

    private void Start()
    {
        fojwsi = false;
    }
    void Update()
    {
        
        if (!PM.DeadMoving)
        {
            if (!fojwsi)
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

        // �÷��̾� ��ġ�� �������� ���콺 ���� ���ϱ�
        Vector3 direction = (mousePosition - transform.position).normalized;

        // ���콺 �������� �÷��̾ �ٶ󺸵��� ȸ�� ����
        transform.right = direction;

        // �߻� �Է� 
        
    }
    IEnumerator ShootProjectile()
    {
        fojwsi = true;
        // �������� �ν��Ͻ�ȭ�Ͽ� �߻�
        GameObject projectile = Instantiate(projectilePrefab, ShootPosition.transform.position, ShootPosition.transform.rotation);

        // �߻� ���� ���� (�÷��̾ �ٶ󺸴� ����)
        projectile.GetComponent<Rigidbody2D>().velocity = -transform.right * 10f; // �߻� �ӵ� ����

        // �߻��� �������� ���� �ð� �Ŀ� �ڵ����� �ı��ǵ��� ����
        Destroy(projectile, 2.0f);
        yield return new WaitForSeconds(0.3f);
        fojwsi = false;
    }
}
