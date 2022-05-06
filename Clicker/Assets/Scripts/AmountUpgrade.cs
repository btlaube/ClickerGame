using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class AmountUpgrade : Upgrade  {
    public override void Buy() {
        Debug.Log("Called");
        this.bot.amount *= 2f;
        this.runtimeState = UpgradeState.PURCHASED;
    }
}