using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotHandler : MonoBehaviour
{
    private static float time = 0.1f;
    List<(Bot, GameObject)> tupleList = new List<(Bot, GameObject)>();

    public Player player;
    public List<GameObject> bots = new List<GameObject>();
    public Sprite lit;
    public Sprite shaded;

    void Start() {
        InvokeRepeating("Add", time, time);
        tupleList.Add((new Bot(name: "Bot01", cost: 10f, amount: 1.44f, discoverAmount: 0f), bots[0]));
        tupleList.Add((new Bot(name: "Bot02", cost: 100f, amount: 15.43f, discoverAmount: 0f), bots[1]));
        tupleList.Add((new Bot(name: "Bot03", cost: 1100f, amount: 134.67f, discoverAmount: 100f), bots[2]));
        tupleList.Add((new Bot(name: "Bot04", cost: 12000f, amount: 456.87f, discoverAmount: 1100f), bots[3]));
        tupleList.Add((new Bot(name: "Bot05", cost: 130000f, amount: 1234.56f, discoverAmount: 12000f), bots[4]));
        foreach ((Bot, GameObject) item in tupleList) {
            (Bot, GameObject) tuple = item;
            tuple.Item1.SetState(0);   
            tuple.Item2.transform.GetChild(1).GetComponent<Text>().text = "$" + tuple.Item1.GetCost().ToString();
            tuple.Item2.transform.GetChild(2).GetComponent<Text>().text = tuple.Item1.GetCount().ToString();
            tuple.Item2.GetComponent<CanvasGroup>().alpha = 0;
        }
        
    }

    void Update() {
        foreach ((Bot, GameObject) item in tupleList) {
            (Bot, GameObject) tuple = item;
            if(player.GetMoney() >= tuple.Item1.GetDiscoverAmount()) {
                tuple.Item2.GetComponent<CanvasGroup>().alpha = 1;
                tuple.Item1.SetState(1);
            }        
            if (player.GetMoney() < tuple.Item1.GetCost()) {
                tuple.Item1.SetState(3);
                tuple.Item2.GetComponent<Button>().interactable = false;
            }
            else {
                if(tuple.Item1.GetCount() > 0) {
                    tuple.Item1.SetState(2);           
                }
                else {
                    tuple.Item1.SetState(1); 
                }
                tuple.Item2.GetComponent<Button>().interactable = true;
            }
        }
    }

    void Add() {
        float totalBotAmount = 0;
        foreach ((Bot, GameObject) item in tupleList) {
            (Bot, GameObject) tuple = item;
            if(tuple.Item1.GetCount() > 0) {
                totalBotAmount += (tuple.Item1.GetAmount() * tuple.Item1.GetCount());
            }            
        }
        player.AddMoney(totalBotAmount);
    }

   void Charge(float cost) {
        player.SpendMoney(cost);
    }

    public void OnClick(string botName) {
        (Bot, GameObject) tuple = tupleList.Find(tuple => tuple.Item1.GetName() == botName);
        if(tuple.Item1.GetState() == 1) {
            Charge(tuple.Item1.GetCost());
            tuple.Item1.SetCost(tuple.Item1.GetCost()*1.2f);
            tuple.Item2.transform.GetChild(1).GetComponent<Text>().text = "$" + tuple.Item1.GetCost().ToString();
            tuple.Item1.SetCount(1);
            tuple.Item2.transform.GetChild(2).GetComponent<Text>().text = tuple.Item1.GetCount().ToString();
            tuple.Item1.SetState(2);
        }
        else if(tuple.Item1.GetState() == 2) {
            Charge(tuple.Item1.GetCost());
            tuple.Item1.SetCost(tuple.Item1.GetCost()*1.2f);
            tuple.Item2.transform.GetChild(1).GetComponent<Text>().text = "$" + tuple.Item1.GetCost().ToString();
            tuple.Item1.SetCount(tuple.Item1.GetCount()+1);
            tuple.Item2.transform.GetChild(2).GetComponent<Text>().text = tuple.Item1.GetCount().ToString();
        }
    }
}
