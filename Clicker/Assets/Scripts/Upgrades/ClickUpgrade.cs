using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/Click Upgrade")]
public class ClickUpgrade : Upgrade  {

    public Player player;

    public override void Buy() {
        this.player.runtimeClickValue *= 1.15f;
        this.runtimeState = UpgradeState.PURCHASED;
    }
}