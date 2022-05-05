using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bot", menuName = "Bot")]
public class NewBot : ScriptableObject
{
    public new string name;
    public float cost;
    public float amount;
    public float discoverAmount;
    public int count;
    public State state;
}
