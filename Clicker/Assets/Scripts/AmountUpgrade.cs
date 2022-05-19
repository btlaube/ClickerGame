using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Amount Upgrade")]
public class AmountUpgrade : Upgrade  {
    public override void Buy() {
        this.bot.runtimeAmount *= 2f;
        this.runtimeState = UpgradeState.PURCHASED;
    }
}