using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "New Upgrade/Amount Upgrade")]
public class NewAmountUpgrade : NewUpgrade  {
    public override void Buy() {
        //player.runtimeMoney -= bot.runtimeCost;
        this.bot.runtimeAmount *= 2f;
    }
}