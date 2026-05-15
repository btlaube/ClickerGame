using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Cost Upgrade")]
public class CostUpgrade : Upgrade  {
    public override void Buy() {
        this.bot.UpgradePurchased();
        this.bot.runtimeCost *= 0.5f;
        base.Buy();
        this.bot.runtimeCostUpgradeLevel += 1;
    }

    public override void IncrementUpgrade() {
        base.IncrementUpgrade();
        this.runtimeCost *= 2.0f;
        this.runtimeDiscoverCount = ((this.bot.runtimeCount + 5) / 5) * 5;
    }
}