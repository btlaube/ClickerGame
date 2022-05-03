using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float money = 0f;

    public Text moneyText;

    void Start() {
        initializePlayer();
    }

    public void initializePlayer(){
        if (!PlayerPrefs.HasKey("money")) {
            PlayerPrefs.SetFloat("money", 0f);
            PlayerPrefs.Save();
            money = 0;
            moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
        }
        else {
            money = PlayerPrefs.GetFloat("money");
            moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
        }
    }

    public float GetMoney() {
        return this.money;
    }

    public void AddMoney(float amount) {
        money += amount;
        moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

    public void SpendMoney(float amount) {
        money -= amount;
        moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

    public void Save() {
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.Save();
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("money");
        money = 0;
        moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

}
