using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "New Upgrade/Cost Upgrade")]
public class NewCostUpgrade : NewUpgrade  {
    public override void Buy() {
        //player.runtimeMoney -= bot.runtimeCost;
        this.bot.runtimeCost *= 0.5f;
    }
}