using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{

    public GameObject amountUpgradeButton;
    public GameObject costUpgradeButton;
    
    //public GameObject playerDisplay;
    public Player player;
    public GameObject content;

    public List<AmountUpgrade> amountUpgrades = new List<AmountUpgrade>();
    public List<CostUpgrade> costUpgrades = new List<CostUpgrade>();


    public void BotBaught() {
        foreach(AmountUpgrade amountUpgrade in amountUpgrades) {
            if(amountUpgrade.bot.runtimeCount >= amountUpgrade.discoverCount && amountUpgrade.runtimeState == UpgradeState.UNDISCOVERED) {
                GameObject myUpgrade = (GameObject)Instantiate(amountUpgradeButton, transform.position, Quaternion.identity, content.transform);
                myUpgrade.GetComponent<DisplayUpgrade>().upgrade = amountUpgrade;
                myUpgrade.GetComponent<DisplayUpgrade>().player = player;
            }
        }
        foreach(CostUpgrade costUpgrade in costUpgrades) {
            if(costUpgrade.bot.runtimeCount >= costUpgrade.discoverCount && costUpgrade.runtimeState == UpgradeState.UNDISCOVERED) {
                GameObject myUpgrade = (GameObject)Instantiate(costUpgradeButton, transform.position, Quaternion.identity, content.transform);
                myUpgrade.GetComponent<DisplayUpgrade>().upgrade = costUpgrade;
                myUpgrade.GetComponent<DisplayUpgrade>().player = player;
            }
        }
    }

}
