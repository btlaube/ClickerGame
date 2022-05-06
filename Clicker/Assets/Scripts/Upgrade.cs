using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public enum UpgradeState {UNDISCOVERED, AVAILABLE, UNAVAILABLE, PURCHASED}


public abstract class Upgrade : ScriptableObject, ISerializationCallbackReceiver
{
    
    public Bot bot;
    public Player player;
    public new string name;
    public string description;
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

    public void UpdateState() {
        if(this.runtimeState != UpgradeState.UNDISCOVERED && this.runtimeState != UpgradeState.PURCHASED) {
            if(player.money < this.runtimeCost) {
                this.runtimeState = UpgradeState.UNAVAILABLE;
            }
            else {
                this.runtimeState = UpgradeState.AVAILABLE;
            }
        }
        else if (this.runtimeState != UpgradeState.PURCHASED) {
            if(this.bot.runtimeCount >= this.discoverCount) {
                this.runtimeState = UpgradeState.AVAILABLE;
            }
        }
    }

}


