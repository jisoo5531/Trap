using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("���� ������ ��")]
    [SerializeField] Gun currentGun;

    float currentFireRate;

    [SerializeField] Text txt_CurrentGunBullet;

    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = 0;
        BulletUISetting();
    }
    public void BulletUISetting()
    {
        txt_CurrentGunBullet.text = "x " + currentGun.bulletCount;
    }
    // Update is called once per frame
    void Update()
    {
        FireRateCalc();
        TryFire();
        LockOnMouse();
    }
    void FireRateCalc()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime;
        }
    }
    void TryFire()
    {
        if (Input.GetButton("Fire1") && currentGun.bulletCount > 0)
        {
            if(currentFireRate <= 0)
            {
                currentFireRate = currentGun.fireRate;
                Fire();
            }
            
        }
    }
    void Fire()
    {
        currentGun.bulletCount--;
        BulletUISetting();
        currentGun.animator.SetTrigger("GunFire");
        currentGun.ps_MuzzleFlash.Play();
        // Instantiate - �������� Ư�� ��ġ�� Ư���� �������� ����
        var clone = Instantiate(currentGun.go_Bullet_Prefab, currentGun.ps_MuzzleFlash.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentGun.speed);
    }
    void LockOnMouse()
    {
        Vector3 cameraPos = Camera.main.transform.position;     // ���� ī�޶� ��ġ�� ����

        // ���콺 2D ��ǥ�� 3D ���� ��ǥ�� ġȯ
        Vector3 mousePos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPos.x));   // z��ǥ�� ī�޶��� x��ǥ�� �� ������
                                                                                        // �� ����Ƽ���� �÷��̾�� ī�޶��� �Ÿ���
                                                                                        // ī�޶��� x�ุŭ ������ �ֱ� ����
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);   // �ѱ��� ���Ʒ��θ� ���콺 ���� ������ �� �ְԲ�
        transform.LookAt(target);
    }
}
