using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


public enum State {UNDISCOVERED, AVAILABLE, UNAVAILABLE};

[CreateAssetMenu(fileName = "New Bot", menuName = "Bot")]
public class Bot : ScriptableObject, ISerializationCallbackReceiver
{
    public new string name;    
    public float amount;
    public float discoverAmount;

    public float initialCost;
    public State initialState = State.UNDISCOVERED;
    public int initialCount = 0;

    //[System.NonSerialized]
    public float runtimeCost;
    //[System.NonSerialized]
    public State runtimeState;
    //[System.NonSerialized]
    public int runtimeCount;

    public void TestSetState(State state) {
        this.runtimeState = state;
    }

    public void OnAfterDeserialize() {
        runtimeCost = initialCost;
        runtimeCount = initialCount;
        runtimeState = initialState;
    }

    public void OnBeforeSerialize() { }


}
