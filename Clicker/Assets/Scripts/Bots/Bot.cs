using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


public enum State {UNDISCOVERED, AVAILABLE, UNAVAILABLE};

[CreateAssetMenu(fileName = "New Bot", menuName = "Bot")]
public class Bot : ScriptableObject, ISerializationCallbackReceiver
{
    public new string name;
    public float discoverAmount;

    public Upgrade costUpgrade;
    public Upgrade amountUpgrade;

    public float initialAmount;
    public float initialCost;
    public State initialState = State.UNDISCOVERED;
    public int initialCount = 0;

    //public float initialCostUpgradePrice;
    //public float initialAmoutUpgradePrice;

    public float runtimeAmount;
    //[System.NonSerialized]
    public float runtimeCost;
    //[System.NonSerialized]
    public State runtimeState;
    //[System.NonSerialized]
    public int runtimeCount;
    //public float runtimeCostUpgradePrice;
    //public float runtimeAmountUpgradePrice;

    public void TestSetState(State state) {
        this.runtimeState = state;
    }

    public void OnAfterDeserialize() {
        runtimeAmount = initialAmount;
        runtimeCost = initialCost;
        runtimeCount = initialCount;
        runtimeState = initialState;
        //runtimeCostUpgradePrice = initialCostUpgradePrice;
        //runtimeAmountUpgradePrice = initialAmoutUpgradePrice;
    }

    public void OnBeforeSerialize() { }


}
