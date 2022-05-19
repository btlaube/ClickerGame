using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBot : MonoBehaviour
{

    public GameObject upgradeButton;
    public GameObject content;

    public CanvasGroup canvas;
    public Button button;
    
    public Bot bot;
    public Player player;

    public Text nameText;    
    public Text costText;
    public Text countText;

    void Start() {
        player.runtimeRate += bot.runtimeAmount * bot.runtimeCount;
        nameText.text = bot.name;
        countText.text = bot.runtimeCount.ToString();
        costText.text = PrintMoney(bot.runtimeCost);
    }

    void Update() {
        costText.text = PrintMoney(bot.runtimeCost);
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
    }

    public void Buy() {
        player.runtimeMoney -= bot.runtimeCost;
        bot.runtimeCount++;
        bot.runtimeCost *= 1.2f;
        countText.text = bot.runtimeCount.ToString();
        costText.text = PrintMoney(bot.runtimeCost);
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

    public void UpdateDisplay() {
        countText.text = bot.runtimeCount.ToString();
        costText.text = PrintMoney(bot.runtimeCost);
    }

}