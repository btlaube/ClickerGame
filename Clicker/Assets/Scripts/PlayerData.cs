using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    
    private float money = 0f;
    private List<Bot> bots = new List<Bot>();

    public PlayerData(Player player) {
        money = player.GetMoney();
        bots = player.GetBots();
    }

    public float GetMoney() {
        return this.money;
    }

    public List<Bot> GetBots() {
        return this.bots;
    }

}
