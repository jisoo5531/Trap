using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StatusManager : MonoBehaviour
{
    [SerializeField] int maxHP;     // 최대 체력
    int currentHP;                  // 현재 체력

    [SerializeField] Text[] txt_HPArray;

    bool isInvincibleMode = false;      // 현재 무적상태인지

    // 깜빡임 관련
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

    // coroutine - 일종의 병렬 처리 기법. 대기 기능 구현 가능
    IEnumerator BlinkCoroutine() {                      // 장애물에 닿았을 때 깜빡임 구현

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
