using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StatusManager : MonoBehaviour
{
    [SerializeField] int maxHP;     // �ִ� ü��
    int currentHP;                  // ���� ü��

    [SerializeField] Text[] txt_HPArray;

    bool isInvincibleMode = false;      // ���� ������������

    // ������ ����
    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;

    [SerializeField] MeshRenderer mesh_PlayerGraphics;

    private void Start()
    {
        currentHP = maxHP;
        UpdateHPStatus();
    }
    public void DecreaseHP(int _num)
    {
        if (!isInvincibleMode)
        {
            currentHP -= _num;
            UpdateHPStatus();
            if (currentHP <= 0)
                PlayerDead();
            //SoundManager.instance.PlaySE("Hurt");
            StartCoroutine(BlinkCoroutine());
        }
        
    }

    public void IncreaseHP(int _num)
    {
        if (currentHP == maxHP)
            return;
        currentHP += _num;
        if (currentHP > maxHP)
            currentHP = maxHP;
        UpdateHPStatus();
    }

    // coroutine - ������ ���� ó�� ���. ��� ��� ���� ����
    IEnumerator BlinkCoroutine() {                      // ��ֹ��� ����� �� ������ ����

        isInvincibleMode = true;
        for (int i = 0; i < blinkCount * 2; ++i)
        {
            mesh_PlayerGraphics.enabled = !mesh_PlayerGraphics.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
        isInvincibleMode = false;
    }

    void UpdateHPStatus()
    {
        for(int i = 0; i < txt_HPArray.Length; ++i)
        {
            if (i < currentHP)
                txt_HPArray[i].gameObject.SetActive(true);
            else
                txt_HPArray[i].gameObject.SetActive(false);
        }
    }

    void PlayerDead()
    {
        SceneManager.LoadScene("Title");
    }
}
