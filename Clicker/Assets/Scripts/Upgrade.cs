using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum UpgradeState {UNDISCOVERED, AVAILABLE, PURCHASED}

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public abstract class Upgrade : ScriptableObject
{
    
    public new string name;
    public Bot bot;
    public float cost;
    public State state;

    public abstract void OnActivated();

}

public class Bot01_Amount_Upgrade_1 : Upgrade  {
    public override void OnActivated() {

    }
}
