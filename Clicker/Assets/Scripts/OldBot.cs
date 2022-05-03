using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldBot : MonoBehaviour
{

    private static float time = 1f;
    private int count = 0;
    private Image thisBotImage;

    public float cost;
    public float amount;
    public float discoverAmount;

    public Player player;
    public Text costText;
    public Text countText;
    public Sprite lit;
    public Sprite shaded;

    public CanvasGroup thisBot;

    //public bool unlocked = false;
    enum State {UNDISCOVERED, AVAILABLE, PURCHASED, UNAFFORDABLE};
    State currentState;

    void Start() {
        currentState = State.UNDISCOVERED;
        thisBotImage = this.GetComponent<Image>();
        this.costText.text = "$" + this.cost.ToString();
        this.countText.text = count.ToString();
        thisBot.alpha = 0;
    }

    void Update() {
        if(player.GetMoney() >= discoverAmount) {
            thisBot.alpha = 1;
            currentState = State.AVAILABLE;
        }        
        if (player.GetMoney() < this.cost) {
            currentState = State.UNAFFORDABLE;
            thisBotImage.sprite = shaded;
        }
        else {
            if(count > 0) {
                currentState = State.PURCHASED;
            }
            else {
                currentState = State.AVAILABLE;
            }
            thisBotImage.sprite = lit;
        }
    }

    void Add() {
        player.AddMoney(amount * count);
    }

    void Charge() {
        player.SpendMoney(cost);
    }
    
    public void OnClick() {
        if(currentState == State.AVAILABLE) {
            Charge();
            InvokeRepeating("Add", time, time);
            count = 1;
            this.countText.text = this.count.ToString();
            currentState = State.PURCHASED;
        }
        else if(currentState == State.PURCHASED) {
            Charge();
            count++;
            this.countText.text = this.count.ToString();
            currentState = State.PURCHASED;
        }
    }

}
