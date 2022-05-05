using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotHandler : MonoBehaviour
{
    private static float time = 0.1f;
    private List<(Bot, GameObject)> tupleList = new List<(Bot, GameObject)>();
    private List<Bot> bots;

    public Player player;
    public List<GameObject> botObjects = new List<GameObject>();
    public Sprite lit;
    public Sprite shaded;

    void Awake() {
        //UpdateBots();
        bots = player.GetBots();
    }

    void Start() {
        InvokeRepeating("Add", time, time);
        tupleList.Add((bots[0], botObjects[0]));
        tupleList.Add((bots[1], botObjects[1]));
        tupleList.Add((bots[2], botObjects[2]));
        tupleList.Add((bots[3], botObjects[3]));
        tupleList.Add((bots[4], botObjects[4]));
        //foreach ((Bot, GameObject) item in tupleList) {
        //    (Bot, GameObject) tuple = item;
        //    //tuple.Item1.SetState(0);   
        //    tuple.Item2.transform.GetChild(1).GetComponent<Text>().text = "$" + tuple.Item1.GetCost().ToString();
        //    tuple.Item2.transform.GetChild(2).GetComponent<Text>().text = tuple.Item1.GetCount().ToString();
        //    //tuple.Item2.GetComponent<CanvasGroup>().alpha = 0;
        //}
        
    }

    void Update() {
        UpdateBots();
        foreach ((Bot, GameObject) item in tupleList) {
            (Bot, GameObject) tuple = item;
            if(player.GetMoney() >= tuple.Item1.GetDiscoverAmount()) {
                tuple.Item2.GetComponent<CanvasGroup>().alpha = 1;
                tuple.Item1.SetState(1);
            }
            if(tuple.Item1.GetState() > 0) {
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

    public void LoadBots() {
        bots = player.GetBots();
        tupleList[0] = ((bots[0], botObjects[0]));
        tupleList[1] = ((bots[1], botObjects[1]));
        tupleList[2] = ((bots[2], botObjects[2]));
        tupleList[3] = ((bots[3], botObjects[3]));
        tupleList[4] = ((bots[4], botObjects[4]));
        foreach ((Bot, GameObject) item in tupleList) {
            (Bot, GameObject) tuple = item;
            tuple.Item2.transform.GetChild(1).GetComponent<Text>().text = "$" + tuple.Item1.GetCost().ToString();
            tuple.Item2.transform.GetChild(2).GetComponent<Text>().text = tuple.Item1.GetCount().ToString();
            if(tuple.Item1.GetState() > 0) {
                tuple.Item2.GetComponent<CanvasGroup>().alpha = 1;
            }
            else {
                tuple.Item2.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }

}
