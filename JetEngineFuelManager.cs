using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetEngineFuelManager : MonoBehaviour
{

    [SerializeField] float maxFuel;     // �ִ� ����
    float currentFuel;                  // ���� ����

    [SerializeField] float waitRechargeFuel;    // ������ ��� �ð�
    float currentWaitRechargeFuel;              // ���

    [SerializeField] float rechargeSpeed;       // ������ �ӵ�

    [SerializeField] Slider slider_JetEngine;
    [SerializeField] Text txt_JetEngine;

    public bool IsFuel { get; private set; }

    PlayerController thePC;

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maxFuel;
        slider_JetEngine.maxValue = maxFuel;
        slider_JetEngine.value = currentFuel;
        thePC = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        checkFuel();

        usedFuel();

        slider_JetEngine.value = currentFuel;
        txt_JetEngine.text = Mathf.Round(currentFuel / maxFuel * 100f).ToString() + "%";
        
    }

    void checkFuel()
    {
        if (currentFuel > 0)
            IsFuel = true;
        else
            IsFuel = false;
    }
    void usedFuel()
    {
        if (thePC.IsJet)
        {
            slider_JetEngine.gameObject.SetActive(true);
            currentFuel -= Time.deltaTime;
            currentWaitRechargeFuel = 0;
            if (currentFuel <= 0)
                currentFuel = 0;
        }
        else
        {
            FuelRecharge();
        }
    }
    void FuelRecharge()
    {
        if (currentFuel < maxFuel)
        {
            currentWaitRechargeFuel += Time.deltaTime;
            if (currentWaitRechargeFuel >= waitRechargeFuel)
            {
                currentFuel += rechargeSpeed * Time.deltaTime;
            }
        }
        else
        {
            slider_JetEngine.gameObject.SetActive(false);
        }
    }
}
