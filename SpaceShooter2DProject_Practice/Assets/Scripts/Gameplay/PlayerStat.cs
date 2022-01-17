using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeInformation
{
    public int Upgrade_ID;
    public string Upgrade_Name;
    public string Upgrade_Description;

    public UpgradeInformation(int id, string name, string desc)
    {
        Upgrade_ID = id;
        Upgrade_Name = name;
        Upgrade_Description = desc;
    }
}

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    public int playerEXP = 0;
    public int nextEXPToLevelUp = 5;

    public FiringType currentFiringType = FiringType.Normal;
    public int normalFireTypeLevel = 0;
    public int normalSpreadTypeLevel = 0;
    public int normalStraightTypeLevel = 0;

    public int firingDamageUpgradeLevel = 0;
    public int firingMoveSpeedUpgradeLevel = 0;
    public int firingRateUpgradeLevel = 0;
    public int firingSizeUpgradeLevel = 0;

    [SerializeField] GameObject Panel_PlayerUpgrade;
    [SerializeField] Text[] Text_UpgradeName;
    [SerializeField] Text[] Text_UpgradeDescription;

    List<UpgradeInformation> Upgrade_EffectType;
    List<UpgradeInformation> Upgrade_StatType;

    UpgradeInformation upgradeChoice1;
    UpgradeInformation upgradeChoice2;
    UpgradeInformation upgradeChoice3;

    void Setup_UpgradeItem()
    {
        UpgradeInformation upgrade0 = new UpgradeInformation(0, "Normal Firing", 
        "Change Spaceship firing type to Normal.\n\n If Spaceship already using Normal firing type, it will INCREASE Damage and Size instead.");
        UpgradeInformation upgrade1 = new UpgradeInformation(1, "Spread Firing", 
        "Change Spaceship firing type to Spread.\n\n If Spaceship already using Spread firing type, it will INCREASE amount of bullet instead.");
        UpgradeInformation upgrade2 = new UpgradeInformation(2, "Straight Firing", 
        "Change Spaceship firing type to Straight.\n\n If Spaceship already using Straight firing type, it will INCREASE amount of bullet instead.");

        Upgrade_EffectType = new List<UpgradeInformation>();

        Upgrade_EffectType.Add(upgrade0);
        Upgrade_EffectType.Add(upgrade1);
        Upgrade_EffectType.Add(upgrade2);

        UpgradeInformation upgrade3 = new UpgradeInformation(3, "Increase Bullet Damage", "Increase bullet damage");
        UpgradeInformation upgrade4 = new UpgradeInformation(4, "Increase Bullet Speed", "Increase bullet speed");
        UpgradeInformation upgrade5 = new UpgradeInformation(5, "Increase Fire Rate", "Increase fire rate");
        UpgradeInformation upgrade6 = new UpgradeInformation(6, "Increase Bullet Size", "Increase bullet size");

        Upgrade_StatType = new List<UpgradeInformation>();

        Upgrade_StatType.Add(upgrade3);
        Upgrade_StatType.Add(upgrade4);
        Upgrade_StatType.Add(upgrade5);
        Upgrade_StatType.Add(upgrade6);
    }

    private void Awake() 
    {
        instance = this;
        Setup_UpgradeItem();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerMaxHealth = playerHealth;
        Panel_PlayerUpgrade.SetActive(false);

    }

    public void Update_PlayerHealth(int amount)
    {
        PlayerStat.instance.playerHealth += amount;

        if(PlayerStat.instance.playerHealth > playerMaxHealth)
        {
            PlayerStat.instance.playerHealth = playerMaxHealth;
        }

        if(PlayerStat.instance.playerHealth <= 0)
        {
            PlayerStat.instance.playerHealth = 0;
            SceneManager.LoadScene("Gameplay_Scene");
            //game end
        }
    }

    public void Update_PlayerEXP(int ExpAmount)
    {
        playerEXP += ExpAmount;

        if(playerEXP >= nextEXPToLevelUp)
        {
            playerEXP = playerEXP - nextEXPToLevelUp;
            nextEXPToLevelUp += 5;
            
            Enable_UpgradePanel();
        }

    }

    void Enable_UpgradePanel()
    {
        int randomUpgradeToChoice1 = Random.Range(0, Upgrade_EffectType.Count);
        int randomUpgradeToChoice2 = Random.Range(0, Upgrade_StatType.Count);
        int randomUpgradeToChoice3 = Random.Range(0, Upgrade_StatType.Count);

        upgradeChoice1 = Upgrade_EffectType[randomUpgradeToChoice1];
        upgradeChoice2 = Upgrade_StatType[randomUpgradeToChoice2];
        upgradeChoice3 = Upgrade_StatType[randomUpgradeToChoice3];

        Text_UpgradeName[0].text = upgradeChoice1.Upgrade_Name;
        Text_UpgradeDescription[0].text = upgradeChoice1.Upgrade_Description;
        Text_UpgradeName[1].text = upgradeChoice2.Upgrade_Name;
        Text_UpgradeDescription[1].text = upgradeChoice2.Upgrade_Description;
        Text_UpgradeName[2].text = upgradeChoice3.Upgrade_Name;
        Text_UpgradeDescription[2].text = upgradeChoice3.Upgrade_Description;

        Panel_PlayerUpgrade.SetActive(true);
        Time.timeScale = 0;
    }

    void Disable_upgradePanel()
    {
        Panel_PlayerUpgrade.SetActive(false);
        Time.timeScale = 1;
    }

    public void Upgrade_RecoverHP()
    {
        Update_PlayerHealth(50);
        Disable_upgradePanel();
    }

    public void Upgrade_Choice1()
    {
        Apply_UpgradeToPlayer(upgradeChoice1);
        Disable_upgradePanel();
    }

    public void Upgrade_Choice2()
    {
        Apply_UpgradeToPlayer(upgradeChoice2);
        Disable_upgradePanel();
    }

    public void Upgrade_Choice3()
    {
        Apply_UpgradeToPlayer(upgradeChoice3);
        Disable_upgradePanel();
    }

    void Apply_UpgradeToPlayer(UpgradeInformation upgradeInfo)
    {
        if(upgradeInfo.Upgrade_ID == 0)
        {
            currentFiringType = FiringType.Normal;
        }
        else if(upgradeInfo.Upgrade_ID == 1)
        {
            currentFiringType = FiringType.Spread3;
        }
        else if(upgradeInfo.Upgrade_ID == 2)
        {
            currentFiringType = FiringType.Straight3;
        }
        else if(upgradeInfo.Upgrade_ID == 3)
        {
            firingDamageUpgradeLevel += 1;
        }
        else if(upgradeInfo.Upgrade_ID == 4)
        {
            firingMoveSpeedUpgradeLevel += 1;
        }
        else if(upgradeInfo.Upgrade_ID == 5)
        {
            firingRateUpgradeLevel += 1;
        }
        else if(upgradeInfo.Upgrade_ID == 6)
        {
            firingSizeUpgradeLevel += 1;
        }
    }
}
