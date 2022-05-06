using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject, ISerializationCallbackReceiver
{

    public float initialMoney = 0f;
    public float initialRate = 0f;

    public float runtimeMoney;
    public float runtimeRate;

    public void OnAfterDeserialize() {
        runtimeMoney = initialMoney;
        runtimeRate = initialRate;
    }

    public void OnBeforeSerialize() { }
}
