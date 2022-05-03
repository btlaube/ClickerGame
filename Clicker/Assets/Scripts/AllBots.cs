using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllBots : MonoBehaviour
{
    //List<BotClass> bots = new List<BotClass>();
    //ArrayList bots = new ArrayList(); 
    private static float time = 1f;
    //List<(BotClass, ArrayList)> tupleList = new List<(BotClass, ArrayList)>();
    List<(BotClass, GameObject)> tupleList = new List<(BotClass, GameObject)>();

    public Player player;
    //public List<Text> costs = new List<Text>();
    //public List<Text> counts = new List<Text>();
    //public List<CanvasGroup> canvases = new List<CanvasGroup>();
    //public List<Image> images = new List<Image>();
    public List<GameObject> bots = new List<GameObject>();
    public Sprite lit;
    public Sprite shaded;

    void Start() {
        InvokeRepeating("Add", time, time);
        /*
        bots.Add(new BotClass() { name = "Bot01", cost = 10f, amount = 0.1f, discoverAmount = 0f, count = 0, state = 0});
        bots.Add(new BotClass() { name = "Bot02", cost = 100f, amount = 1f, discoverAmount = 50f, count = 0,  state = 0});
        bots.Add(new BotClass() { name = "Bot03", cost = 1000f, amount = 10f, discoverAmount = 500f, count = 0,  state = 0});
        bots.Add(new BotClass() { name = "Bot04", cost = 10000f, amount = 100f, discoverAmount = 5000f, count = 0,  state = 0});
        bots.Add(new BotClass() { name = "Bot05", cost = 100000f, amount = 1000f, discoverAmount = 50000f, count = 0,  state = 0});
        */
        /*
        tupleList.Add((new BotClass(name: "Bot01", cost: 10f, amount: 0.1f, discoverAmount: 0f, count: 0, state: 0), new ArrayList() {this.costs[0], this.counts[0], this.canvases[0], this.images[0]}));
        tupleList.Add((new BotClass(name: "Bot02", cost: 100f, amount: 1f, discoverAmount: 50f, count: 0, state: 0), new ArrayList() {this.costs[1], this.counts[1], this.canvases[1], this.images[1]}));
        tupleList.Add((new BotClass(name: "Bot03", cost: 1000f, amount: 10f, discoverAmount: 500f, count: 0, state: 0), new ArrayList() {this.costs[2], this.counts[2], this.canvases[2], this.images[2]}));
        tupleList.Add((new BotClass(name: "Bot04", cost: 10000f, amount: 100f, discoverAmount: 5000f, count: 0, state: 0), new ArrayList() {this.costs[3], this.counts[3], this.canvases[3], this.images[3]}));
        tupleList.Add((new BotClass(name: "Bot05", cost: 100000f, amount: 1000f, discoverAmount: 50000f, count: 0, state: 0), new ArrayList() {this.costs[4], this.counts[4], this.canvases[4], this.images[4]}));
        */
        tupleList.Add((new BotClass(name: "Bot01", cost: 10f, amount: 0.1f, discoverAmount: 0f, count: 0, state: 0), bots[0]));
        tupleList.Add((new BotClass(name: "Bot02", cost: 100f, amount: 1f, discoverAmount: 50f, count: 0, state: 0), bots[1]));
        tupleList.Add((new BotClass(name: "Bot03", cost: 1000f, amount: 10f, discoverAmount: 500f, count: 0, state: 0), bots[2]));
        tupleList.Add((new BotClass(name: "Bot04", cost: 10000f, amount: 100f, discoverAmount: 5000f, count: 0, state: 0), bots[3]));
        tupleList.Add((new BotClass(name: "Bot05", cost: 100000f, amount: 1000f, discoverAmount: 50000f, count: 0, state: 0), bots[4]));
        foreach ((BotClass, GameObject) item in tupleList) {
            (BotClass, GameObject) tuple = item;
            tuple.Item1.SetState(0);   
            tuple.Item2.transform.GetChild(1).GetComponent<Text>().text = "$" + tuple.Item1.GetCost().ToString();
            tuple.Item2.transform.GetChild(2).GetComponent<Text>().text = tuple.Item1.GetCount().ToString();
            tuple.Item2.GetComponent<CanvasGroup>().alpha = 0;
        }
        
    }

    void Update() {
        foreach ((BotClass, GameObject) item in tupleList) {
            (BotClass, GameObject) tuple = item;
            if(player.GetMoney() >= tuple.Item1.GetDiscoverAmount()) {
                tuple.Item2.GetComponent<CanvasGroup>().alpha = 1;
                tuple.Item1.SetState(1);
            }        
            if (player.GetMoney() < tuple.Item1.GetCost()) {
                tuple.Item1.SetState(3);
                tuple.Item2.GetComponent<Image>().sprite = shaded;
            }
            else {
                if(tuple.Item1.GetCount() > 0) {
                    tuple.Item1.SetState(2);           
                }
                else {
                    tuple.Item1.SetState(1); 
                }
                tuple.Item2.GetComponent<Image>().sprite = lit;
            }
        }
    }

    void Add() {
        float totalBotAmount = 0;
        foreach ((BotClass, GameObject) item in tupleList) {
            (BotClass, GameObject) tuple = item;
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
        (BotClass, GameObject) tuple = tupleList.Find(tuple => tuple.Item1.GetName() == botName);
        if(tuple.Item1.GetState() == 1) {
            Charge(tuple.Item1.GetCost());
            //InvokeRepeating("Add", time, time);
            tuple.Item1.SetCount(1);
            tuple.Item2.transform.GetChild(2).GetComponent<Text>().text = tuple.Item1.GetCount().ToString();
            tuple.Item1.SetState(2);
        }
        else if(tuple.Item1.GetState() == 2) {
            Charge(tuple.Item1.GetCost());
            tuple.Item1.SetCount(tuple.Item1.GetCount()+1);
            tuple.Item2.transform.GetChild(2).GetComponent<Text>().text = tuple.Item1.GetCount().ToString();
            //currentState = State.PURCHASED;
        }
    }
}
