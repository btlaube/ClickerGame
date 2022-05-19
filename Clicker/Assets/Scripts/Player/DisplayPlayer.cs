using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayer : MonoBehaviour
{
    private static float time = 0.1f;
    public Player player;
    public List<Bot> bots;

    public Text moneyText;
    public Text rateText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Add", time, time);
        LoadBots();
    }

    void Add() {
        Player.runtimeMoney += Player.runtimeRate;
        this.moneyText.text = PrintMoney(Player.runtimeMoney);
    }

    public void LoadBots() {
        Player.runtimeRate = 0f;
        foreach(Bot bot in bots) {
            Player.runtimeRate += (bot.runtimeAmount * bot.runtimeCount);
        }
        this.rateText.text = PrintMoney(Player.runtimeRate);
    }

    public void OnClick() {
        Player.runtimeMoney += player.runtimeClickValue;
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

}
