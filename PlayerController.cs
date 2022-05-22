using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static bool canMove = true;

    [Header("�ӵ� ���� ����")]
    [SerializeField] float moveSpeed;
    [SerializeField] float JetPackSpeed;

    Rigidbody myRigid;

    public bool IsJet { get; private set; }

    [Header("��ƼŬ �ý���(�ν���)")]
    [SerializeField] ParticleSystem ps_LeftEngine;
    [SerializeField] ParticleSystem ps_RightEngine;

    AudioSource audioSource;

    JetEngineFuelManager theFuel;

    // Start is called before the first frame update
    void Start()
    {
        IsJet = false;
        myRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        theFuel = FindObjectOfType<JetEngineFuelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TryMove();
        TryJet();
    }

    void TryMove()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && canMove)
        {
            // DŰ = 1, A = -1   return

            Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
            myRigid.AddForce(moveDir * moveSpeed);
        }
    }
    void TryJet()
    {
        // space�� ������ ��
        if (Input.GetKey(KeyCode.Space) && theFuel.IsFuel && canMove)
        {
            if (!IsJet)                  // space�� ������ �ѹ��� ����ǰԲ�
            {                            // IsJet�� false�̹Ƿ� 
                ps_LeftEngine.Play();
                ps_RightEngine.Play();
                //audioSource.Play();

                IsJet = true;
            }
       
            myRigid.AddForce(Vector3.up * JetPackSpeed);
        }
        else
        {
            if (IsJet)
            {
                ps_LeftEngine.Stop();
                ps_RightEngine.Stop();
                //audioSource.Stop();
                IsJet = false;
            }
            myRigid.AddForce(Vector3.down * JetPackSpeed);
        }
    }
}
