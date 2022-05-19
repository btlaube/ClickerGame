using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUpgrade : MonoBehaviour
{
    public CanvasGroup canvas;
    public Button button;

    public Player player;

    public Upgrade upgrade;
    public GameObject playerDisplay;
    public Bot bot;
    
    void Awake() {
        playerDisplay = GameObject.Find("Player");
    }


    void Update() {
        switch(upgrade.runtimeState) {
            case UpgradeState.UNDISCOVERED:
                canvas.alpha = 0;
                button.interactable = false;
                break;
            case UpgradeState.AVAILABLE:
                canvas.alpha = 1;
                button.interactable = true;
                break;
            case UpgradeState.UNAVAILABLE:
                canvas.alpha = 1;
                button.interactable = false;
                break;
            case UpgradeState.PURCHASED:
                Destroy(gameObject);
                break;
        }
        if(upgrade.runtimeState != UpgradeState.UNDISCOVERED && upgrade.runtimeState != UpgradeState.PURCHASED) {
            if(player.runtimeMoney < upgrade.runtimeCost) {
                upgrade.runtimeState = UpgradeState.UNAVAILABLE;
            }
            else {
                upgrade.runtimeState = UpgradeState.AVAILABLE;
            }
        }
        else if (upgrade.runtimeState != UpgradeState.PURCHASED) {
            if(upgrade.bot.runtimeCount >= upgrade.discoverCount) {
                upgrade.runtimeState = UpgradeState.AVAILABLE;
            }
        }
    }

    public void Buy() {
        player.runtimeMoney -= upgrade.runtimeCost;        
        //bot.UpdateDisplay();
        this.upgrade.Buy();
        playerDisplay.GetComponent<DisplayPlayer>().LoadBots();
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

}