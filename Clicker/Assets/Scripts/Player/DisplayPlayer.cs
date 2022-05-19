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
        player.runtimeMoney += player.runtimeRate;
        this.moneyText.text = PrintMoney(player.runtimeMoney);
    }

    public void LoadBots() {
        player.runtimeRate = 0f;
        foreach(Bot bot in bots) {
            player.runtimeRate += (bot.runtimeAmount * bot.runtimeCount);
        }
        this.rateText.text = PrintMoney(player.runtimeRate) + " per second";
    }

    public void OnClick() {
        player.runtimeMoney += player.runtimeClickValue;
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

}
