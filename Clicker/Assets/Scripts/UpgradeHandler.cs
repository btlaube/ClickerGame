using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{

    public GameObject amountUpgradeButton;
    public GameObject costUpgradeButton;
    public GameObject content;

    //public List<Bot> bots = new List<Bot>();
    public List<AmountUpgrade> amountUpgrades = new List<AmountUpgrade>();
    public List<CostUpgrade> costUpgrades = new List<CostUpgrade>();


    public void BotBaught() {
        foreach(AmountUpgrade amountUpgrade in amountUpgrades) {
            if(amountUpgrade.bot.runtimeCount >= amountUpgrade.discoverCount) {
                GameObject myUpgrade = (GameObject)Instantiate(amountUpgradeButton, transform.position, Quaternion.identity, content.transform);
                myUpgrade.GetComponent<DisplayUpgrade>().upgrade = amountUpgrade;
            }
        }
        foreach(CostUpgrade costUpgrade in costUpgrades) {
            if(costUpgrade.bot.runtimeCount >= costUpgrade.discoverCount) {
                GameObject myUpgrade = (GameObject)Instantiate(costUpgradeButton, transform.position, Quaternion.identity, content.transform);
                myUpgrade.GetComponent<DisplayUpgrade>().upgrade = costUpgrade;
            }
        }
    }

}
