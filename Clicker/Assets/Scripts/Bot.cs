using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum State {UNDISCOVERED, AVAILABLE, PURCHASED, UNAFFORDABLE};

[System.Serializable]
public class Bot
{
    public string name;
    public float cost;
    public float amount;
    public float discoverAmount;
    public int count;
    public State state;
    /*
    public Text costText;
    public Text countText;
    public CanvasGroup botCanvas;
    public Sprite lit;
    public Sprite shaded;
    */

    public Bot(string name, float cost, float amount, float discoverAmount) {
        this.name = name;
        this.cost = cost;
        this.amount = amount;
        this.discoverAmount = discoverAmount;
        this.count = 0;
        this.state = State.UNDISCOVERED;
    }

    public string GetName() {
        return this.name;
    }

    public float GetCost() {
        return this.cost;
    }

    public float GetAmount() {
        return this.amount;
    }

    public float GetDiscoverAmount() {
        return this.discoverAmount;
    }

    public int GetCount() {
        return this.count;
    }

    public int GetState() {
        return (int)this.state;
    }

    public void SetCost(float cost) {
        this.cost = cost;
    }

    public void SetCount(int count) {
        this.count = count;
    }

    public void SetState(int state) {
        this.state = (State)state;
    }

}
