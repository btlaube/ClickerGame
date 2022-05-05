using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float money = 0f;
    private List<Bot> bots = new List<Bot>();

    public Text moneyText;

    void Awake() {
        this.bots.Add(new Bot(name: "Bot01", cost: 10f, amount: 0.014f, discoverAmount: 0f));
        this.bots.Add(new Bot(name: "Bot02", cost: 100f, amount: 1.543f, discoverAmount: 0f));
        this.bots.Add(new Bot(name: "Bot03", cost: 1100f, amount: 13.467f, discoverAmount: 100f));
        this.bots.Add(new Bot(name: "Bot04", cost: 12000f, amount: 45.687f, discoverAmount: 1100f));
        this.bots.Add(new Bot(name: "Bot05", cost: 130000f, amount: 123.456f, discoverAmount: 12000f));
    }

    void Start() {
        //LoadPlayer();        
    }

    //public void LoadPlayer() {
    //    if (!PlayerPrefs.HasKey("money")) {
    //        PlayerPrefs.SetFloat("money", 0f);
    //        PlayerPrefs.Save();
    //        money = 0;
    //        moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    //    }
    //    else {
    //        money = PlayerPrefs.GetFloat("money");
    //        moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    //    }
    //}

    public float GetMoney() {
        return this.money;
    }

    public List<Bot> GetBots() {
        return this.bots;
    }

    public void AddMoney(float amount) {
        money += amount;
        moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

    public void SpendMoney(float amount) {
        money -= amount;
        moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

    //public void Save() {
    //    PlayerPrefs.SetFloat("money", money);
    //    PlayerPrefs.Save();
    //}

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();
        this.money = data.GetMoney();
        this.bots = data.GetBots();
        //BotHandler.UpdateBots();
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("money");
        money = 0;
        moneyText.text = "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

}
