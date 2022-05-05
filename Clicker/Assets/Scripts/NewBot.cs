using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


public enum State {UNDISCOVERED, AVAILABLE, UNAVAILABLE};

[CreateAssetMenu(fileName = "New Bot", menuName = "Bot")]
public class NewBot : ScriptableObject, ISerializationCallbackReceiver
{
    public new string name;    
    public float amount;
    public float discoverAmount;

    public float initialCost;
    public State initialState = State.UNDISCOVERED;
    public int initialCount = 0;

    //[System.NonSerialized]
    public float RuntimeCost;
    //[System.NonSerialized]
    public State RuntimeState;
    //[System.NonSerialized]
    public int RuntimeCount;

    public void TestSetState(State state) {
        this.RuntimeState = state;
    }

    public void OnAfterDeserialize() {
        RuntimeCost = initialCost;
        RuntimeCount = initialCount;
        RuntimeState = initialState;
    }

    public void OnBeforeSerialize() { }


}
