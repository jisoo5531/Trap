using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�ǰ� ����Ʈ")]
    [SerializeField] GameObject go_RicochetEffect;
  
    [Header("�Ѿ� ������")]
    [SerializeField] int damage;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)  // �ٸ� �ö��̴��� �浹�ϴ� ���� ȣ��Ǵ� �Լ�
    {
        // other - �浹�� ��ü
        // other.contacts[0] - �浹�� ��ü�� ���˸�
        ContactPoint contactPoint = other.contacts[0];

        //Quaternion.LookRotation - Ư�� ������ �ٶ󺸰� �ϴ� �޼ҵ�
        var clone = Instantiate(go_RicochetEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));

        if (other.transform.CompareTag("Mine"))
        {
            other.transform.GetComponent<Mine>().Damaged(damage);
        }
        
        Destroy(clone, 0.5f);   // �Ѿ��� ���� �ʰԲ�
        Destroy(gameObject);
    }
}
