using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBot : MonoBehaviour
{

<<<<<<< Updated upstream:Clicker/Assets/Scripts/Bots/DisplayBot.cs
    //private static float time = 0.1f;
    private CanvasGroup canvas;
    private Button button;
=======
    public CanvasGroup canvas;
    public Button button;
>>>>>>> Stashed changes:Clicker/Assets/Scripts/Bot/DisplayBot.cs
    
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
<<<<<<< Updated upstream:Clicker/Assets/Scripts/Bots/DisplayBot.cs

}
=======

    public void UpdateDisplay() {
        countText.text = bot.runtimeCount.ToString();
        costText.text = PrintMoney(bot.runtimeCost);
    }

}
>>>>>>> Stashed changes:Clicker/Assets/Scripts/Bot/DisplayBot.cs
