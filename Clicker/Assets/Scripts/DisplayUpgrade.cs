using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum UpgradeState {UNDISCOVERED, AVAILABLE, UNAVAILABLE, PURCHASED};

public class DisplayUpgrade : MonoBehaviour
{
    public CanvasGroup canvas;
    public Button button;
    public TMP_Text upgradeDescription;
    public TMP_Text upgradeLevelText;

    public Player player;

    public Upgrade upgrade;
    public GameObject playerDisplay;
    public Bot thisBot;

    [SerializeField] private float thisCost;
    [SerializeField] private float thisDiscoverCount;

    public UpgradeState initialState;
    public UpgradeState runtimeState;
    
    public void OnAfterDeserialize() {
        runtimeState = initialState;
    }

    public void OnBeforeSerialize() { }

    void Awake() {
        playerDisplay = GameObject.Find("Player");
    }

    void Start() {
        thisBot = upgrade.bot;

        thisCost = upgrade.runtimeCost;
        thisDiscoverCount = upgrade.runtimeDiscoverCount;
        
        if (thisBot != null) 
        {
            upgradeDescription.text = "Upgrade " + thisBot.name + " " + "\nCost: " + PrintMoney(thisCost);
        }
        else
        {
            upgradeDescription.text = "Upgrade Click " + "\nCost: " + PrintMoney(thisCost);
        }
        upgradeLevelText.text = "Level: " + upgrade.runtimeLevel;

        upgrade.IncrementUpgrade();
    }

    void Update() {
        switch(runtimeState) {
            case UpgradeState.UNDISCOVERED:
                canvas.alpha = 0;
                button.interactable = false;
                break;
            case UpgradeState.AVAILABLE:
                canvas.alpha = 1;
                button.interactable = true;
                break;
            case UpgradeState.UNAVAILABLE:
                canvas.alpha = 0.5f;
                button.interactable = false;
                break;
            case UpgradeState.PURCHASED:
                Destroy(gameObject);
                break;
        }
        if(runtimeState != UpgradeState.UNDISCOVERED && runtimeState != UpgradeState.PURCHASED) {
            if(player.runtimeMoney < thisCost) {
                runtimeState = UpgradeState.UNAVAILABLE;
            }
            else {
                runtimeState = UpgradeState.AVAILABLE;
            }
        }
        else if (thisBot != null) {
            if (runtimeState != UpgradeState.PURCHASED) {
                if(thisBot.runtimeCount >= thisDiscoverCount) {
                    runtimeState = UpgradeState.AVAILABLE;
                }
            }
        }
        else {
            if (thisDiscoverCount <= player.runtimeMoney) {
                runtimeState = UpgradeState.AVAILABLE;
            }
        }
    }

    public void Buy() {
        Destroy(gameObject);
        player.runtimeMoney -= thisCost;        
        //bot.UpdateDisplay();
        this.upgrade.Buy();
        playerDisplay.GetComponent<DisplayPlayer>().UpdatePlayer();
    }

    private static readonly string[] moneySuffixes =
    {
        "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No"
    };

    public string PrintMoney(double money)
    {
        if (money < 1000)
            return "$" + money.ToString("F2");

        int tier = 0;

        while (money >= 1000 && tier < moneySuffixes.Length - 1)
        {
            money /= 1000;
            tier++;
        }

        return $"${money:0.##}{moneySuffixes[tier]}";
    }

}