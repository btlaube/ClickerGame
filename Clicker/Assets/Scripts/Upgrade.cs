using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


public enum UpgradeState {UNDISCOVERED, AVAILABLE, UNAVAILABLE, PURCHASED};

public abstract class Upgrade : ScriptableObject, ISerializationCallbackReceiver
{

    public GameObject playerDisplay;
    public GameObject botDisplay;

    public Bot bot;
    public float discoverCount;

    public float initialCost;
    public UpgradeState initialState;

    public float runtimeCost;
    public UpgradeState runtimeState;

    public void OnAfterDeserialize() {
        runtimeCost = initialCost;
        runtimeState = initialState;
    }

    public void OnBeforeSerialize() { }
    public abstract void Buy();
}