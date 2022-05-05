using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarAmount
{
    
    public float dollarAmount;

    public DollarAmount() {
        this.dollarAmount = 0f;
    }

    public string Print() {
        return "$" + this.dollarAmount.ToString();
    }

}
