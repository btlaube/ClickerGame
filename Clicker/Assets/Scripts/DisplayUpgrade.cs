using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUpgrade : MonoBehaviour
{

    private CanvasGroup canvas;
    private Button button;

    public Upgrade upgrade;
    public Player player;

    public Text nameText;    
    public Text costText;
    public Text descriptionText;

    void Awake() {
        canvas = this.GetComponent<CanvasGroup>();
        button = this.GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = upgrade.name;
        costText.text = PrintMoney(upgrade.runtimeCost);
        descriptionText.text = upgrade.description;
    }

    // Update is called once per frame
    void Update()
    {
        switch(upgrade.runtimeState) {
            case UpgradeState.UNDISCOVERED:
                canvas.alpha = 0;
                button.interactable = false;
                break;
            case UpgradeState.AVAILABLE:
                canvas.alpha = 1;
                button.interactable = true;
                break;
            case UpgradeState.UNAVAILABLE:
                canvas.alpha = 1;
                button.interactable = false;
                break;
            case UpgradeState.PURCHASED:
                //delete game object
                Debug.Log("Delete");
                canvas.alpha = 0;
                button.interactable = false;
                break;
        }
        if(upgrade.runtimeState != UpgradeState.UNDISCOVERED && upgrade.runtimeState != UpgradeState.PURCHASED) {
            if(player.money < upgrade.runtimeCost) {
                upgrade.runtimeState = UpgradeState.UNAVAILABLE;
            }
            else {
                upgrade.runtimeState = UpgradeState.AVAILABLE;
            }
        }
        else if (upgrade.runtimeState != UpgradeState.PURCHASED) {
            if(upgrade.bot.runtimeCount >= upgrade.discoverCount) {
                upgrade.runtimeState = UpgradeState.AVAILABLE;
            }
        }
    }

    public void Buy() {
        //upgrade.runtimeState = UpgradeState.PURCHASED;
        upgrade.Buy();        
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }
}
