using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomM : MonoBehaviour
{
    public GameM gameM;
    public List<int> radomSlots=new List<int>();
    public int radoms;
    public int money=10;
    public Text[] text;
    public Text scoreT;
    public float time;
    public GameObject[] textGb;
    public Text[] texts;
    public List<Stocks> menuStocks = new List<Stocks>();
    // Start is called before the first frame update
    void OnValidate()
    {
        gameM=FindObjectOfType<GameM>();
        text = GameObject.Find("Canvas").transform.Find("Tbx").GetComponentsInChildren<Text>();
        texts = GameObject.Find("Canvas").transform.Find("ShopM").GetComponentsInChildren<Text>();



    }
    private void Start()
    {
        money = 10;
        RandomStocks();
        scoreT = GameObject.Find("Canvas").transform.Find("ScoreT").GetComponent<Text>();
        
        for (int i = 0; i < textGb.Length; i++)
        {
            textGb[i].SetActive(false);
        }
        for (int i = 0; i < menuStocks.Count; i++)
        {
            texts[i].text = "" + menuStocks[i].stocksN + "\n" + menuStocks[i].buyMoney + "원";
        }

    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        scoreT.text = "돈: " + gameM.money;
        if (gameM.slotIv.add == true)
        {
            time = 0;
            gameM.slotIv.add = false;
        }
        if (time > 10)
        {
            RandomStocks();
            for (int i = 0; i < menuStocks.Count; i++)
            {
                texts[i].text = "" + menuStocks[i].stocksN + "\n" + menuStocks[i].buyMoney + "원";
            }
            gameM.day+=5;
            time = 0;
            
        }
    }
    public void RandomStocks()
    {
        radomSlots.Clear();
        gameM.slotsMoney.Clear();
        for(int i = 0; i < gameM.stInv.Count; i++)
        {
            money = 10;
            radoms = Random.Range(0, 100);
            Debug.Log("money" + money);
            Debug.Log("slots" + gameM.slotIv.stocks[i].buyMoney);
            radomSlots.Add(money = Radoms(radoms, gameM.slotIv.stocksMoney[i]));
            gameM.slotsMoney.Add(menuStocks[i].buyMoney);
            Debug.Log("Random:"+radomSlots[i]);
            gameM.slotIv.stocks[i].buyMoney += radomSlots[i];
            textGb[i].SetActive(true);
            if (gameM.slotIv.stocks[i].buyMoney <= 0)
            {
                gameM.slotIv.stocks[i].buyMoney = 1;
            }
            text[i].text =" "+money;
            Debug.Log("인베토리 돈:"+gameM.slotIv.stocks[i].buyMoney);
        }
    }
    public int Radoms(int radom,int money)
    {
        Debug.Log("Radom:"+radom);
        int radommoney=0;
        if (radom == 0)
        {
            radommoney += money * 10;
        }
        else if (radom > 0 && radom <= 10)
        {
            radommoney += money * 3;
        }
        else if (radom > 10 && radom <= 30)
        {
            radommoney += money * 1;
        }
        else if (radom > 30 && radom <= 50)
        {
            radommoney += money * 0;
        }
        else if (radom > 50 && radom <= 60)
        {
            radommoney += money * -1;
        }
        else if(radom>60&&radom<=90)
        {
            radommoney += money * -2;
        }
        else if (radom > 90 && radom < 99)
        {
            radommoney += money * -5;
        }
        else if (radom == 99)
        {
            radommoney += money * -10;
        }
        Debug.Log("랜덤돈" + radommoney);
        return radommoney;
    }
}
