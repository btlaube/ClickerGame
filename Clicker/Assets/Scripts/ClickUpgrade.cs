using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Click Upgrade")]
public class ClickUpgrade : Upgrade  {
    public override void Buy() {
        this.player.runtimeClickValue *= 2.5f;
        base.Buy();
    }

    public override void IncrementUpgrade() {
        base.IncrementUpgrade();
        this.runtimeDiscoverCount *= 10f;
        this.runtimeCost = runtimeDiscoverCount;
    }
}