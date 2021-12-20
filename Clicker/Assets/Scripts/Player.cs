using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int money = 0;
    public Text moneyText;

    void Start() {
        initializePlayer();
    }

    public void initializePlayer(){
        if (!PlayerPrefs.HasKey("money")) {
            PlayerPrefs.SetInt("money", 0);
            PlayerPrefs.Save();
            money = 0;
            moneyText.text = "$" + money.ToString();
        }
        else {
            money = PlayerPrefs.GetInt("money");
            moneyText.text = "$" + money.ToString();
        }
    }    

    public void AddMoney(int amount) {
        money += amount;
        moneyText.text = "$" + money.ToString();
    }

    public void Save() {
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("money");
        money = 0;
        moneyText.text = "$" + money.ToString();
    }

}
