using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
{

    public GameObject upgradeButtonPrefab;
    public GameObject amountUpgradeButton;
    public GameObject costUpgradeButton;
    public GameObject clickUpgradeButton;
    public Sprite amountUpgradeSprite;
    public Sprite costUpgradeSprite;
    public Sprite clickUpgradeSprite;
    
    //public GameObject playerDisplay;
    public Player player;
    public GameObject content;

    public List<AmountUpgrade> amountUpgrades = new List<AmountUpgrade>();
    public List<CostUpgrade> costUpgrades = new List<CostUpgrade>();
    public List<ClickUpgrade> clickUpgrades = new List<ClickUpgrade>();

    public void Update() {
        foreach(ClickUpgrade clickUpgrade in clickUpgrades) {
            if(player.runtimeMoney >= clickUpgrade.runtimeDiscoverCount) {
                GameObject myUpgrade = (GameObject)Instantiate(upgradeButtonPrefab, transform.position, Quaternion.identity, content.transform);
                myUpgrade.GetComponent<DisplayUpgrade>().upgrade = clickUpgrade;
                myUpgrade.GetComponent<DisplayUpgrade>().player = player;
                myUpgrade.transform.Find("Icon").GetComponent<Image>().sprite = clickUpgradeSprite;
            }
        }
    }

    public void BotBaught() {
        foreach(AmountUpgrade amountUpgrade in amountUpgrades) {
            if(amountUpgrade.bot.runtimeCount >= amountUpgrade.runtimeDiscoverCount) {
                GameObject myUpgrade = (GameObject)Instantiate(upgradeButtonPrefab, transform.position, Quaternion.identity, content.transform);
                myUpgrade.GetComponent<DisplayUpgrade>().upgrade = amountUpgrade;
                myUpgrade.GetComponent<DisplayUpgrade>().player = player;
                myUpgrade.transform.Find("Icon").GetComponent<Image>().sprite = amountUpgradeSprite;
            }
        }
        foreach(CostUpgrade costUpgrade in costUpgrades) {
            if(costUpgrade.bot.runtimeCount >= costUpgrade.runtimeDiscoverCount) {
                GameObject myUpgrade = (GameObject)Instantiate(upgradeButtonPrefab, transform.position, Quaternion.identity, content.transform);
                myUpgrade.GetComponent<DisplayUpgrade>().upgrade = costUpgrade;
                myUpgrade.GetComponent<DisplayUpgrade>().player = player;
                myUpgrade.transform.Find("Icon").GetComponent<Image>().sprite = costUpgradeSprite;
            }
        }
    }

}
