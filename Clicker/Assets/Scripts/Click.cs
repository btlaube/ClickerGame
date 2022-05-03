using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{

    private float moneyNum = 0f;
    public Text money;

    void Start() {
        money.text = "$" + (Mathf.Round(moneyNum * 100.0f) * 0.01f).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonUp(0)) {
        //    moneyNum += 1f;
        //    money.text = "$" + moneyNum.ToString();
        //}
    }

    public void AddMoney(float amount) {
        moneyNum += amount;
        money.text = "$" + (Mathf.Round(moneyNum * 100.0f) * 0.01f).ToString();
    }

}
