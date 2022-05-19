using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

enum UpgradeState {UNDISCOVERED, AVAILABLE, PURCHASED}


public interface IUpgrade
{
    //string name { get; set; }
    //float initialCost{}
    //State initialState{}
    //float runtimeCost{}
    //State runtimeState{}
    //public new string name;
    //public Bot bot;
//
    //public float initialCost;
    //public State initialState;
//
    //public float runtimeCost;
    //public State runtimeState;
//
    

    void OnActivated();

}

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Bot01_Amount_Upgrade_1 : ScriptableObject, ISerializationCallbackReceiver, IUpgrade  {

    public void OnAfterDeserialize() {
        runtimeCost = initialCost;
        runtimeState = initialState;
    }

    public void OnBeforeSerialize() { }

    public void OnActivated() {

    }
}
