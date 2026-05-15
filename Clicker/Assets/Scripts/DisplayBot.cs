using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayBot : MonoBehaviour
{

    public GameObject upgradeButton;
    public GameObject content;

    public CanvasGroup canvas;
    public Button button;
    
    public Bot bot;
    public Player player;

    public TMP_Text nameText;
    public TMP_Text costText;
    public TMP_Text rateText;
    public TMP_Text countText;
    public TMP_Text costLevelText;
    public TMP_Text rateLevelText;

    void Start() {
        player.runtimeRate += bot.runtimeAmount * bot.runtimeCount;
        nameText.text = bot.name;
        // countText.text = bot.runtimeCount.ToString();
        // rateText.text = PrintRate(bot.runtimeAmount);
        // costText.text = "x" + PrintMoney(bot.runtimeCost);
        UpdateDisplay();
    }

    void Update() {
        // costText.text = PrintMoney(bot.runtimeCost);
        switch(bot.runtimeState) {
            case State.UNDISCOVERED:
                canvas.alpha = 0;
                button.interactable = false;
                break;
            case State.AVAILABLE:
                canvas.alpha = 1;
                button.interactable = true;
                break;
            case State.UNAVAILABLE:
                canvas.alpha = 1;
                button.interactable = false;
                break;
        }
        if(bot.runtimeState != State.UNDISCOVERED) {            
            if(player.runtimeMoney < bot.runtimeCost) {
                bot.runtimeState = State.UNAVAILABLE;
            }
            else {
                bot.runtimeState = State.AVAILABLE;
            }
        }
        else {
            if(player.runtimeMoney >= bot.discoverAmount) {
                bot.runtimeState = State.AVAILABLE;
            }
        }
        // Update display if an upgrade was purchased
        if (bot.updateDisplay) {
            UpdateDisplay();
            bot.updateDisplay = false;
        }
    }

    public void Buy() {
        player.runtimeMoney -= bot.runtimeCost;
        bot.runtimeCount++;
        bot.runtimeCost *= 1.2f;
        UpdateDisplay();
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


    public string PrintRate(double money)
    {
        if (money < 1000)
            return "$" + money.ToString("F2") + "/s";

        int tier = 0;

        while (money >= 1000 && tier < moneySuffixes.Length - 1)
        {
            money /= 1000;
            tier++;
        }

        return $"${money:0.##}{moneySuffixes[tier]}";
    }

    public void UpdateDisplay() {
        costText.text = PrintMoney(bot.runtimeCost);
        rateText.text = PrintRate(bot.runtimeAmount);
        countText.text = "x" + bot.runtimeCount.ToString();
        costLevelText.text = "Lvl. " + bot.runtimeCostUpgradeLevel.ToString();
        rateLevelText.text = "Lvl. " + bot.runtimeRateUpgradeLevel.ToString();
    }

}