using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("���� �÷��̾� ����")]
    [SerializeField] Transform tf_player;

    [Header("���� ���ǵ� ����")]
    [Range(0, 1)] [SerializeField] float chaseSpeed;

    float camNormalXpos;
    [SerializeField]
    [Header("�ν��� �� ������ x �Ÿ�")]
    float camJetXPos;
    float camCurrentXPos;

    PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = tf_player.GetComponent<PlayerController>();
        camNormalXpos = transform.position.x;
        camCurrentXPos = camNormalXpos;
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.IsJet)
        {
            camCurrentXPos = camJetXPos;
        }
        else
        {
            camCurrentXPos = camNormalXpos;
        }
        Vector3 movePos = Vector3.Lerp(transform.position, tf_player.position, chaseSpeed);
        float cameraPosX = Mathf.Lerp(transform.position.x, camCurrentXPos, chaseSpeed);
        transform.position = new Vector3(cameraPosX, movePos.y, movePos.z);
    }
}
