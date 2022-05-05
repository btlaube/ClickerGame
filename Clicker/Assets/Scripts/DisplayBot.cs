using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBot : MonoBehaviour
{
    
    public NewBot bot;

    public Text nameText;    
    public Text costText;
    public Text countText;

    void Start() {
        nameText.text = bot.name;
        countText.text = bot.count.ToString();
        costText.text = "$" + bot.cost.ToString();
    }

}
