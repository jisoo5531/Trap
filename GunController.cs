using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("현재 장착된 총")]
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
        // Instantiate - 프리팹을 특정 위치에 특정한 방향으로 생성
        var clone = Instantiate(currentGun.go_Bullet_Prefab, currentGun.ps_MuzzleFlash.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentGun.speed);
    }
    void LockOnMouse()
    {
        Vector3 cameraPos = Camera.main.transform.position;     // 메인 카메라 위치값 저장

        // 마우스 2D 좌표를 3D 월드 좌표로 치환
        Vector3 mousePos = Camera.main.ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraPos.x));   // z좌표에 카메라의 x좌표가 들어간 이유는
                                                                                        // 내 유니티에서 플레이어와 카메라의 거리는
                                                                                        // 카메라의 x축만큼 떨어져 있기 때문
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);   // 총구가 위아래로만 마우스 따라 움직일 수 있게끔
        transform.LookAt(target);
    }
}
