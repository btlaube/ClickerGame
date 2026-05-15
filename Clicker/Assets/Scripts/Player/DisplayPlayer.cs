using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayPlayer : MonoBehaviour
{
    private static float time = 0.1f;
    public Player player;
    public List<Bot> bots;

    public Text moneyText;
    public Text rateText;
    public TMP_Text clickText;

    public GameObject bombPrefab;
    public GameObject bigBombPrefab;

    private float stachedMoney;
    private float stachedChange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Add", 0, time);
        // InvokeRepeating("SpawnBomb", 0, time * 10);
        // UpdatePlayer();
    }

    // void Update()
    // {
    //     SpawnBomb();
    // }

    void Add() {
        player.runtimeMoney += player.runtimeRate * time;
        UpdatePlayer();
        // this.moneyText.text = PrintMoney(player.runtimeMoney);
    }

    public void LoadBots() {
        player.runtimeRate = 0f;
        foreach(Bot bot in bots) {
            player.runtimeRate += (bot.runtimeAmount * bot.runtimeCount);
        }
    }

    public void OnClick() {
        player.runtimeMoney += player.runtimeClickValue;
        UpdatePlayer();
    }

    private static readonly string[] moneySuffixes =
    {
        "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No"
    };

    public string PrintMoney(double money)
    {
        if (money < 1000)
            return "$" + money.ToString("F2");

        int tier = 0;

        while (money >= 1000 && tier < moneySuffixes.Length - 1)
        {
            money /= 1000;
            tier++;
        }

        return $"${money:0.##}{moneySuffixes[tier]}";
    }

    public string PrintRate(float rate) {
        if (rate < 1000)
            return "$" + rate.ToString("F2");

        int tier = 0;

        while (rate >= 1000 && tier < moneySuffixes.Length - 1)
        {
            rate /= 1000;
            tier++;
        }

        return $"${rate:0.##}{moneySuffixes[tier]}";
    }

    public void UpdatePlayer() {
        LoadBots();
        // Add();
        UpdateMoneyDisplay();
        UpdateRateDisplay();
        UpdateClickValueDisplay();
        SpawnBomb();
    }

    public void UpdateMoneyDisplay() {
        moneyText.text = PrintMoney(player.runtimeMoney);
    }

    public void UpdateRateDisplay() {
        rateText.text = PrintRate(player.runtimeRate);
    }

    public void UpdateClickValueDisplay() {
        clickText.text = "+ $" + PrintMoney(player.runtimeClickValue);
    }

    
    [SerializeField] private int numTiers = 12;

    // Value growth
    [SerializeField] private long baseValue = 1;
    [SerializeField] private int valueMultiplier = 10;

    // Scale growth
    [SerializeField] private float baseScale = 0.1f;
    [SerializeField] private float scaleMultiplier = 1.25f;

    public void SpawnBomb()
    {
        float diff = player.runtimeMoney - stachedMoney;
        long bombsRemaining = (long)Mathf.Floor(diff);

        float minX = -9.8f, maxX = 0f;
        float minY = 5f, maxY = 6f;

        // Precompute highest tier values
        long tierValue = baseValue;
        float tierScale = baseScale;

        for (int i = 1; i < numTiers; i++)
        {
            tierValue *= valueMultiplier;
            tierScale *= scaleMultiplier;
        }

        // Spawn from largest tier → smallest
        for (int tier = numTiers - 1; tier >= 0; tier--)
        {
            long count = bombsRemaining / tierValue;
            bombsRemaining %= tierValue;

            for (long i = 0; i < count; i++)
            {
                Vector2 spawnPos = new Vector2(
                    Random.Range(minX, maxX),
                    Random.Range(minY, maxY)
                );

                GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);
                bomb.transform.localScale = Vector3.one * tierScale;
            }

            tierValue /= valueMultiplier;
            tierScale /= scaleMultiplier;
        }

        float remainder = diff - Mathf.Floor(diff);
        stachedMoney = player.runtimeMoney - remainder;
    }

}
