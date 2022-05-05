using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBot : MonoBehaviour
{

    private static float time = 0.1f;
    private CanvasGroup canvas;
    private Button button;
    
    public NewBot bot;
    public Player player;

    public Text nameText;    
    public Text costText;
    public Text countText;

    void Awake() {
        canvas = this.GetComponent<CanvasGroup>();
        button = this.GetComponent<Button>();
    }

    void Start() {
        InvokeRepeating("Add", time, time);
        nameText.text = bot.name;
        countText.text = bot.RuntimeCount.ToString();
        costText.text = "$" + bot.RuntimeCost.ToString();
    }

    void Update() {
        switch(bot.RuntimeState) {
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
        if(bot.RuntimeState != State.UNDISCOVERED) {
            if(player.money < bot.RuntimeCost) {
                bot.RuntimeState = State.UNAVAILABLE;
            }
            else {
                bot.RuntimeState = State.AVAILABLE;
            }
        }
        else {
            if(player.money >= bot.discoverAmount) {
                bot.RuntimeState = State.AVAILABLE;
            }
        }
    }

    public void Buy() {
        player.SpendMoney(bot.RuntimeCost);
        bot.RuntimeCount++;
        bot.RuntimeCost *= 1.2f;  
        countText.text = bot.RuntimeCount.ToString();
        costText.text = "$" + bot.RuntimeCost.ToString();
    }

    void Add() {
        player.AddMoney(bot.RuntimeCount * bot.amount);
    }

}
