using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] Image playerHealthValueUI;
    [SerializeField] TMP_Text playerHealthValueText;

    [SerializeField] Image playerExpValueUI;
    [SerializeField] TMP_Text playerExpValueText;

    float targetHealthRatioToSet = 1.0f;
    float targetExpRatioToSet = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Update_PlayerHealthInterface();
        Update_PlayerEXPInterface();
    }

    void Update_PlayerHealthInterface()
    {
        float healthRatio = PlayerStat.instance.playerHealth * 1.0f / PlayerStat.instance.playerMaxHealth;
        //playerHealthValueUI.fillAmount = healthRatio;
        targetHealthRatioToSet = healthRatio;
        playerHealthValueText.text = PlayerStat.instance.playerHealth.ToString() + " / " + PlayerStat.instance.playerMaxHealth.ToString();

        float currentFillAmount = playerHealthValueUI.fillAmount;
        playerHealthValueUI.fillAmount = Mathf.Lerp(currentFillAmount, targetHealthRatioToSet, 0.05f);
    }

    void Update_PlayerEXPInterface()
    {
        playerExpValueText.text = PlayerStat.instance.playerEXP + " / " + PlayerStat.instance.nextEXPToLevelUp;
        targetExpRatioToSet = PlayerStat.instance.playerEXP * 1.0f / PlayerStat.instance.nextEXPToLevelUp;

        float currentFillAmount_Exp = playerExpValueUI.fillAmount;
        playerExpValueUI.fillAmount = Mathf.Lerp(currentFillAmount_Exp, targetExpRatioToSet, 0.05f);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyProperties enemyProperties = other.GetComponent<EnemyProperties>();
            if(enemyProperties != null)
            {
                PlayerStat.instance.Update_PlayerHealth(-50);
                enemyProperties.Update_EnemyHealth(-100);
            }
        }
    }
}
