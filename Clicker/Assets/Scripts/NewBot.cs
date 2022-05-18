using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "New Bot", menuName = "New Bot")]
public class NewBot : ScriptableObject, ISerializationCallbackReceiver
{
    public float discoverAmount;
    //public List<NewUpgrade> upgrades = new List<NewUpgrade>();

    public float initialAmount;
    public float initialCost;
    public State initialState = State.UNDISCOVERED;
    public int initialCount = 0;

    public float runtimeAmount;
    public float runtimeCost;
    public State runtimeState;
    public int runtimeCount;

    public void TestSetState(State state) {
        this.runtimeState = state;
    }

    public void OnAfterDeserialize() {
        runtimeAmount = initialAmount;
        runtimeCost = initialCost;
        runtimeCount = initialCount;
        runtimeState = initialState;
    }

    public void OnBeforeSerialize() { }
}