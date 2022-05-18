using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDisplayUpgrade : MonoBehaviour
{
    public CanvasGroup canvas;
    public Button button;

    public NewUpgrade upgrade;
    public Player player;
    
    void Update() {
        switch(upgrade.runtimeState) {
            case State.UNDISCOVERED:
                canvas.alpha = 0;
                button.interactable = false;
                break;
            case State.AVAILABLE:
                canvas.alpha = 1;
                button.interactable = true;
                break;
            case State.UNAVAILABLE:
                canvas.alpha = 1;
                button.interactable = false;
                break;
        }
        if(upgrade.runtimeState != State.UNDISCOVERED) {            
            if(player.runtimeMoney < upgrade.runtimeCost) {
                upgrade.runtimeState = State.UNAVAILABLE;
            }
            else {
                upgrade.runtimeState = State.AVAILABLE;
            }
        }
        else {
            if(upgrade.bot.runtimeCount >= upgrade.discoverCount) {
                upgrade.runtimeState = State.AVAILABLE;
            }
        }
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }

}