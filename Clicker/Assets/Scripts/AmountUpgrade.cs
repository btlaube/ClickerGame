using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Amount Upgrade")]
public class AmountUpgrade : Upgrade  {
    public override void Buy() {
        this.bot.UpgradePurchased();
        this.bot.runtimeAmount *= 2f;
        base.Buy();
        this.bot.runtimeRateUpgradeLevel += 1;
    }

    public override void IncrementUpgrade() {
        base.IncrementUpgrade();
        this.runtimeCost *= 2.0f;
        this.runtimeDiscoverCount = ((this.bot.runtimeCount + 5) / 5) * 5;
    }
}