using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Amount Upgrade")]
public class AmountUpgrade : Upgrade  {
    public override void Buy() {
        //player.runtimeMoney -= bot.runtimeCost;
        this.bot.runtimeAmount *= 2f;
    }
}