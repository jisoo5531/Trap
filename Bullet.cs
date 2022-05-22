using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("피격 이펙트")]
    [SerializeField] GameObject go_RicochetEffect;
  
    [Header("총알 데미지")]
    [SerializeField] int damage;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)  // 다른 컬라이더와 충돌하는 순간 호출되는 함수
    {
        // other - 충돌한 객체
        // other.contacts[0] - 충돌한 객체의 접촉면
        ContactPoint contactPoint = other.contacts[0];

        //Quaternion.LookRotation - 특정 방향을 바라보게 하는 메소드
        var clone = Instantiate(go_RicochetEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));

        if (other.transform.CompareTag("Mine"))
        {
            other.transform.GetComponent<Mine>().Damaged(damage);
        }
        
        Destroy(clone, 0.5f);   // 총알이 남지 않게끔
        Destroy(gameObject);
    }
}
