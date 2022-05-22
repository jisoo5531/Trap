using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("���� ��� ����")]
    [SerializeField] protected Transform tf_Player;

    [Header("���� �ӵ� ����")] [Range(0, 1)]
    [SerializeField] protected float speed;

    protected Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = tf_Player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, tf_Player.position - currentPos, speed);
    }
}
