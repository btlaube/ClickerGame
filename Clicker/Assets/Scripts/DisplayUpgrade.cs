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
        
    }

    public string PrintMoney(float money) {
        return "$" + (Mathf.Round(money * 100.0f) * 0.01f).ToString();
    }
}
