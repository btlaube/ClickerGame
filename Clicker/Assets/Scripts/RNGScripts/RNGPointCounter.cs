using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNGPointCounter : MonoBehaviour
{

    private int streak = 0;
    private int randNum;
    private int nextNum;
    private int points = 0;
    private int numClicks = 0;

    public Text text1;
    public Text text2;
    public Text text3;
    public Text generatedText;
    public Text pointsText;
    public Text clicksText;

    public SpriteRenderer bbq;
    public SpriteRenderer bacon;
    public SpriteRenderer burger;
    public SpriteRenderer generated;

    public Sprite bbqSprite;
    public Sprite baconSprite;
    public Sprite burgerSprite;

    // Start is called before the first frame update
    void Start()
    {
        text1.text = "_";
        text2.text = "_";
        text3.text = "_";
        generatedText.text = "";
        pointsText.text = "$" + points.ToString();
        clicksText.text = "Clicks: " + numClicks.ToString();
        bbq.enabled = false;
        bacon.enabled = false;
        burger.enabled = false;
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            numClicks++;
            clicksText.text = "Clicks: " + numClicks.ToString();
            randNum = Random.Range(1, 4);
            generatedText.text = randNum.ToString();

            if(randNum == 1) {
                generated.sprite = bbqSprite;
            }
            else if(randNum == 2) {
                generated.sprite = baconSprite;
            }
            else if(randNum == 3) {
                generated.sprite = burgerSprite;
            }

            
            if(streak == 0) {
                nextNum = 1;
                bbq.enabled = true;
                //StartCoroutine(showObject("bbq"));
            }
            else if(streak == 1) {
                nextNum = 2;
                bacon.enabled = true;
                //StartCoroutine(showObject("bacon"));
            }
            else if(streak == 2) {
                nextNum = 3;
                burger.enabled = true;
                //StartCoroutine(showObject("burger"));
            }
            else if(streak == 3) {
                nextNum = 1;
            }

            if(randNum == nextNum) {
                streak++;
                Debug.Log("you got a " + randNum);
                if (randNum == 1) {
                    text1.text = "1";
                }
                if (randNum == 2) {
                    text2.text = "2";
                }
                if (randNum == 3) {
                    text3.text = "3";
                    Debug.Log("YAYY");
                    text1.text = "Y";
                    text2.text = "A";
                    text3.text = "Y";
                    points++;
                    pointsText.text = "$" + points.ToString();
                }
            }
            else {
                streak = 0;
                nextNum = 1;
                Debug.Log("reset");
                text1.text = "_";
                text2.text = "_";
                text3.text = "_";
                bbq.enabled = false;
                bacon.enabled = false;
                burger.enabled = false;
            }
        }
    }

/*
    IEnumerator showObject(string objectName) {        
        if(objectName == "bbq") {
            bbq.enabled = true;
            yield return new WaitForSeconds(1);
            bbq.enabled = false;
        }
        else if(objectName == "bacon") {
            bacon.enabled = true;
            yield return new WaitForSeconds(1);
            bacon.enabled = false;
        }
        else if(objectName == "burger") {
            burger.enabled = true;
            yield return new WaitForSeconds(1);
            burger.enabled = false;
        }
    }
*/
}
