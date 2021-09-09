using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
public class Data_M : MonoBehaviour
{
    public GameM gameM;
    private  List<item> itemDb=new List<item>();
    private List<int> gameStat = new List<int>();
    private List<Stocks> stockDb = new List<Stocks>();
    private List<int> moneys = new List<int>();
    public int key;
    
   


    public static Data_M instance;

  
    // Start is called before the first frame update
    void Start()
    {
        gameM = FindObjectOfType<GameM>();
    }

    public void Save()
    {

        gameStat.Clear();
        itemDb.Clear();
        stockDb.Clear();
        moneys.Clear();
        for (int i = 0; i < gameM.invetory.Count; i++)
        {

            itemDb.Add(new item(gameM.invetory[i].itemName, gameM.invetory[i].id, gameM.invetory[i].buyDays, gameM.invetory[i].upScore, gameM.invetory[i].buyMoney));


            Debug.Log(" " + itemDb[i]);
        }

       
        JsonData item = JsonMapper.ToJson(itemDb);
        Debug.Log(item);
        File.WriteAllText(Application.dataPath + "/Resources/ItemData.json", item.ToString());

        for (int i = 0; i <= 3; i++)
        {
            if (i == 0)
            {
                gameStat.Add(gameM.day);
            }
            else if (i == 1)
            {
                gameStat.Add(gameM.subScb);

            }
            else if (i == 2)
            {
                gameStat.Add(gameM.money);
            }
            else if (i == 3)
            {
                gameStat.Add(gameM.keyT);
            }
            else if (i == 4)
            {
                gameStat.Add(gameM.keys);
            }
            else
            {
                Debug.Log("json버그");
            }

        }
        JsonData stat = JsonMapper.ToJson(gameStat);
        File.WriteAllText(Application.dataPath + "/Resources/stat.json", stat.ToString());
        for (int i = 0; i < gameM.stInv.Count; i++)
        {
            stockDb.Add(new Stocks(gameM.stInv[i].id, gameM.stInv[i].stocksN, gameM.stInv[i].buyMoney));
            Debug.Log("주식: " + stockDb[i]);
        }
        JsonData stockJs = JsonMapper.ToJson(stockDb);
        File.WriteAllText(Application.dataPath + "/Resources/stock.json", stockJs.ToString());
        for(int i = 0; i <gameM.slotsMoney.Count; i++)
        {
            moneys.Add(gameM.slotsMoney[i]);
        }
        JsonData moneyJs = JsonMapper.ToJson(moneys);
        File.WriteAllText(Application.dataPath + "/Resources/money.json", moneyJs.ToString());
    }
    public void Load()
    {
        gameM.slotsMoney.Clear();
        gameM.invetory.Clear();
        gameM.stInv.Clear();
        string JsonStr = File.ReadAllText(Application.dataPath + "/Resources/ItemData.json");
        JsonData itemD = JsonMapper.ToObject(JsonStr);
        string JsonStat = File.ReadAllText(Application.dataPath + "/Resources/stat.json");
        JsonData StatD = JsonMapper.ToObject(JsonStat);
        string JsonSt = File.ReadAllText(Application.dataPath + "/Resources/stock.json");
        JsonData stocks = JsonMapper.ToObject(JsonSt);
        string JsonMoney = File.ReadAllText(Application.dataPath + "/Resources/money.json");
        JsonData moneys = JsonMapper.ToObject(JsonMoney);

        itemDb.Clear();
        for (int i = 0; i < itemD.Count; i++)
        {
            gameM.invetory.Add(new item(itemD[i]["itemName"].ToString(), (int)itemD[i]["id"], (int)itemD[i]["buyDays"], (double)itemD[i]["upScore"], (int)itemD[i]["buyMoney"]));
            gameM.invetory[i].itemImage = Resources.Load("Steam_id" + gameM.invetory[i].id, typeof(Sprite)) as Sprite;
            Debug.Log(" " + gameM.invetory[i].id);
            //gameM.invetory[i].id = itemDb[i].id;
            //gameM.invetory[i].itemName = itemDb[i].itemName;
            //gameM.invetory[i].upScore = itemDb[i].upScore;
            //gameM.invetory[i].buyMoney = itemDb[i].buyMoney;
            //gameM.invetory[i].buyDays = itemDb[i].buyDays;
            Debug.Log(" " + gameM.invetory[i]);


        }
        for (int i = 0; i < stocks.Count; i++)
        {
            gameM.stInv.Add(new Stocks((int)stocks[i]["id"], stocks[i]["stocksN"].ToString(), (int)stocks[i]["buyMoney"]));
            gameM.stInv[i].image = Resources.Load("Stocks_id" + gameM.stInv[i].id, typeof(Sprite)) as Sprite;
        }
        for (int i = 0; i < StatD.Count; i++)
        {
            if (i == 0)
            {
                Debug.Log("날");
                gameM.day = ((int)StatD[i]);
            }
            else if (i == 1)
            {
                Debug.Log("구독");
                gameM.subScb = ((int)StatD[i]);
            }
            else if (i == 2)
            {
                Debug.Log("돈");
                gameM.money = ((int)StatD[i]);
            }
            else if (i == 3)
            {
                gameM.keyT = ((int)StatD[i]);
            }
            else if (i == 4)
            {
                gameM.keys = ((int)StatD[i]);
            }
            else
            {
                Debug.Log("json불러오기실패");
            }
        }
        for (int i = 0; i < moneys.Count; i++)
        {
            Debug.Log("머니머니 " + ((int)moneys[i]));
            gameM.slotsMoney.Add(((int)moneys[i]));

        }
        gameM.idNumber = gameM.invetory.Count + 1;
        gameM.slotsIdNm = gameM.stInv.Count + 1;



    }
    public void LoadImgae()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
