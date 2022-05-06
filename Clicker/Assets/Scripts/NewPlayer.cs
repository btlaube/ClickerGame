using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class NewPlayer : ScriptableObject, ISerializationCallbackReceiver
{

    public float initialMoney;
    public float initialMoneyRate;

    public float runtimeMoney;
    public float runtimeMoneyRate;

    public void OnAfterDeserialize() {
        initialMoney = runtimeMoney;
        initialMoneyRate = runtimeMoneyRate;
    }

    public void OnBeforeSerialize() { }

    public void StartAdding() {
        //InvokeRepeating("Add", 1f, 1f);
    }

    void Add() {
        this.runtimeMoney += this.runtimeMoneyRate;
    }

}
