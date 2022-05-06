using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

enum UpgradeState {UNDISCOVERED, AVAILABLE, PURCHASED}

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject, ISerializationCallbackReceiver
{
    
    public new string name;
    public string description;
    public Bot bot;

    public float initialCost;
    public State initialState;

    public float runtimeCost;
    public State runtimeState;

    public void OnAfterDeserialize() {
        runtimeCost = initialCost;
        runtimeState = initialState;
    }

    public void OnBeforeSerialize() { }

    //public abstract void OnActivated();

}

//public class Bot01_Amount_Upgrade_1 : Upgrade  {
//    public override void OnActivated() {
//
//    }
//}
