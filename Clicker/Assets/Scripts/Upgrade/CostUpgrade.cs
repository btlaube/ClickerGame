using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Cost Upgrade")]
public class CostUpgrade : Upgrade  {
    public override void Buy() {
        //player.runtimeMoney -= bot.runtimeCost;
        this.bot.runtimeCost *= 0.5f;
    }
}