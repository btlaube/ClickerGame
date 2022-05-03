using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bot : MonoBehaviour
{
    private int count;
    private float cost = 10f;
    private Image thisBot;

    public Player player;
    public float time = 1f;
    public float amount;

    public Text costText;
    public Text countText;

    public Sprite lit;
    public Sprite shaded;

    //public bool unlocked = false;
    enum State {UNDISCOVERED, AVAILABLE, PURCHASED, UNAFFORDABLE};
    State currentState;

    void Start() {
        thisBot = this.GetComponent<Image>();
        currentState = State.AVAILABLE;
        this.costText.text = "$" + this.cost.ToString();
        //InvokeRepeating("Add", time, time);
    }

    void Update() {
        /*
        if(currentState == State.UNDISCOVERED) {

        }
        */
        if (player.GetMoney() < this.cost) {
            currentState = State.UNAFFORDABLE;
            thisBot.sprite = shaded;
        }
        else {
            if(count > 0) {
                currentState = State.PURCHASED;            
            }
            else {
                currentState = State.AVAILABLE;  
            }
            thisBot.sprite = lit;
        }
        /*
        else {
            currentState = State.AVAILABLE;
            thisBot.sprite = lit;
        }
        */
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
