using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public abstract class Upgrade : ScriptableObject, ISerializationCallbackReceiver
{

    public Bot bot;
    public float discoverCount;

    public float initialCost;
    public State initialState;

    public float runtimeCost;
    public State runtimeState;

    public void OnAfterDeserialize() {
        runtimeCost = initialCost;
        runtimeState = initialState;
    }

    public void OnBeforeSerialize() { }
    public abstract void Buy();
}