using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBot : MonoBehaviour
{

    private static float time = 0.1f;
    private CanvasGroup canvas;
    private Button button;
    
    public Bot bot;
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
        player.moneyRate += bot.amount * bot.runtimeCount;
        bot.runtimeCount = 0;
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
            if(player.money < bot.runtimeCost) {
                bot.runtimeState = State.UNAVAILABLE;
            }
            else {
                bot.runtimeState = State.AVAILABLE;
            }
        }
        else {
            if(player.money >= bot.discoverAmount) {
                bot.runtimeState = State.AVAILABLE;
            }
        }
    }

    public void Buy() {
        player.SpendMoney(bot.runtimeCost);
        bot.runtimeCount++;
        bot.runtimeCost *= 1.2f;
        player.moneyRate += bot.amount;
        countText.text = bot.runtimeCount.ToString();
        costText.text = PrintMoney(bot.runtimeCost);
    }

    void Add() {
        player.AddMoney(bot.runtimeCount * bot.amount);
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

}
