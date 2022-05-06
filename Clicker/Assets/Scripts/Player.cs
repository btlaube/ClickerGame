using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float money = 0f;
    public float moneyRate;

    public Text moneyText;
    public Text rateText;

    void Start() {
        initializePlayer();
    }

    public void initializePlayer(){
        if (!PlayerPrefs.HasKey("money")) {
            PlayerPrefs.SetFloat("money", 0f);
            PlayerPrefs.Save();
            money = 0;
            moneyText.text = PrintMoney(money);
        }
        else {
            money = PlayerPrefs.GetFloat("money");
            moneyText.text = PrintMoney(money);
        }
    }

    public float GetMoney() {
        return this.money;
    }

    public void AddMoney(float amount) {
        money += amount;
        moneyText.text = PrintMoney(money);
    }

    public void SpendMoney(float amount) {
        money -= amount;
        moneyText.text = PrintMoney(money);
    }

    public void Save() {
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.Save();
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("money");
        money = 0;
        moneyText.text = PrintMoney(money);
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

    void Update() {
        this.rateText.text = PrintMoney(this.moneyRate) + " per second";
    }

}
