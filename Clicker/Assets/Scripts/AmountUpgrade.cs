using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class AmountUpgrade : Upgrade  {
    public override void OnActivated() {
        Debug.Log("Called");
    }
}