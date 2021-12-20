using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{

    public Player player;
    public float time = 1f;
    public int amount = 1;

    //public bool unlocked = false;

    void Start() {
        InvokeRepeating("Add", time, time);
    }

    void Add() {
        player.AddMoney(amount);
    }
    
}
