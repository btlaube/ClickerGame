using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public enum State {UNDISCOVERED, AVAILABLE, UNAVAILABLE};

[CreateAssetMenu(fileName = "New Bot", menuName = "Bot")]
public class Bot : ScriptableObject, ISerializationCallbackReceiver
{

    //public List<Upgrade> upgrades = new List<Upgrade>();

    public new string name;
    public float discoverAmount;

    public float initialAmount;
    public float initialCost;
    public State initialState = State.UNDISCOVERED;
    public int initialCount = 0;

    public float runtimeAmount;
    public float runtimeCost;
    public State runtimeState;
    public int runtimeCount;

    public bool updateDisplay = false;
    public int initialTimesUpgraded = 1;
    public int runtimeTimesUpgraded;

    public int initialCostUpgradeLevel = 1;
    public int runtimeCostUpgradeLevel;
    public int initialRateUpgradeLevel = 1;
    public int runtimeRateUpgradeLevel;

    public void TestSetState(State state) {
        this.runtimeState = state;
    }

    public void OnAfterDeserialize() {
        runtimeAmount = initialAmount;
        runtimeCost = initialCost;
        runtimeCount = initialCount;
        runtimeState = initialState;
        runtimeTimesUpgraded = initialTimesUpgraded;
        runtimeCostUpgradeLevel = initialCostUpgradeLevel;
        runtimeRateUpgradeLevel = initialRateUpgradeLevel;
    }

    public void OnBeforeSerialize() { }

    public void UpgradePurchased() {
        updateDisplay = true;
    }
}