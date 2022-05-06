using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayer : MonoBehaviour
{
    
    public NewPlayer player;

    public Text moneyText;
    public Text moneyRateText;

    void Start() {
        moneyText.text = PrintMoney(player.runtimeMoney);
        moneyRateText.text = PrintMoney(player.runtimeMoneyRate);
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

}
