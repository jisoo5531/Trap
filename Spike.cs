using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] float force;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log(damage + "�� �÷��̾�� �������ϴ�");
            other.transform.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5f);
            other.transform.GetComponent<StatusManager>().DecreaseHP(damage);
        }
    }
}
