using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


// public enum UpgradeState {UNDISCOVERED, AVAILABLE, UNAVAILABLE, PURCHASED};

public abstract class Upgrade : ScriptableObject, ISerializationCallbackReceiver
{

    public GameObject playerDisplay;
    public GameObject botDisplay;
    public Player player;

    public string description;

    public Bot bot;

    public float initialDiscoverCount;
    public float initialCost;
    // public UpgradeState initialState;
    public int initialLevel;

    public float runtimeDiscoverCount;
    public float runtimeCost;
    // public UpgradeState runtimeState;
    public int runtimeLevel;

    public void OnAfterDeserialize() {
        runtimeDiscoverCount = initialDiscoverCount;
        runtimeCost = initialCost;
        // runtimeState = initialState;
        runtimeLevel = initialLevel;
    }

    public void OnBeforeSerialize() { }

    public virtual void Buy() {
        // this.bot.UpgradePurchased();
        // this.player.runtimeMoney -= this.runtimeCost;
        // this.runtimeState = UpgradeState.UNDISCOVERED;
        // this.runtimeLevel++;
    }

    public virtual void IncrementUpgrade()
    {
        this.runtimeLevel++;
    }
}