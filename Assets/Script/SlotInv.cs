using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInv : MonoBehaviour
{
    [SerializeField]
    public Solt[] slots;
    
    public List<Stocks> stocks = new List<Stocks>();
    [SerializeField]
    private Transform bag;
    public int idNuber = 1;
    public int errorId = 0;
    public int ide = 0;
    private GameM gameM;
    public RandomM radom;
    public List<int> stocksMoney = new List<int>();
    public bool add=false;
    
    // Start is called before the first frame update
    private void OnValidate()
    {
        slots = bag.GetComponentsInChildren<Solt>();
        gameM = FindObjectOfType<GameM>();
        radom = FindObjectOfType<RandomM>();
        
    }
    private void Awake()
    {
        Freshlot();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadInv()
    {
        Debug.Log(" " + idNuber);
        Debug.Log(" " + gameM.slotsIdNm);
        
        idNuber = gameM.slotsIdNm;  
        for (int i = 0; i < gameM.stInv.Count; i++)
        {

            stocks.Add(gameM.stInv[i]);
            slots[i].stocks = gameM.stInv[i];
            
        }
        for(int i = 0; i < gameM.slotsMoney.Count; i++)
        {
            stocksMoney.Add( gameM.slotsMoney[i]);
        }






    }
    public void BuyStocks(Stocks stock)
    {
        if (idNuber < stock.id)
        {
            
            Debug.Log("그전 주식을 사세요");
            return;
        }
        if (stock.buyMoney > gameM.money)
        {
            Debug.Log("돈이 부족합니다.");
            return;
        }
        if (stocks.Count < slots.Length)
        {
            Debug.Log("0");
            Debug.Log("Le: " + stocks.Count);
            Debug.Log("IDN: " + stocks);
            for (int i = 0; i < stocks.Count; i++)
            {
                Debug.Log("게임일자 " + gameM.day);
              
                if (stocks[i].id == stock.id)
                {
                    errorId = 3;
                    /*peaking.InvetoryError(_item, errorId);*/
                    Debug.Log("중복된 아이템입니다");
                    return;
                }
                if (stocks[i].buyMoney > gameM.money)
                {
                    Debug.Log("돈이 부족합니다.");
                }


            }
            if (ide > 0)
            {
                ide--;
            }
           
            idNuber++;
            gameM.money -= stock.buyMoney;
            stocksMoney.Add(stock.buyMoney);
          
            
            stocks.Add(stock);
            gameM.stInv.Add(stock);
            gameM.slotsIdNm = idNuber;
          
            Freshlot();
            add = true;

        }
        else
        {
            Debug.Log("가득찼습니다");
        }
    }
    public void SellSlots(Stocks stock)
    {
        
        Debug.Log("클릭");
      
        for(int i = 0; i < stocks.Count; i++)
        {
          
            Debug.Log("stockId "+stocks[i].id);
            if (stock.id == stocks[i].id)
            {
                Debug.Log("아이I: "+i);
                Debug.Log("Sloat " +stocks[i].id);
                gameM.money += stock.buyMoney;
                stocks.Remove(stocks[i]);
                gameM.stInv.Remove(gameM.stInv[i]);
                gameM.slotsMoney.Remove(stocksMoney[i]);
                slots[ide].stocks = null;
                radom.textGb[ide].SetActive(false);
                ide++;
                stock.buyMoney = stocksMoney[ide-1];
                idNuber--;
              
            }
        }
    }
    public void Remove()
    {
        
    }
    public void Freshlot()
    {

        int i = 0;
        for (; i < stocks.Count && i < slots.Length; i++)
        {
            slots[i].stocks = stocks[i];
            slots[i].stockId = stocks[i].id;
            Debug.Log(" " + slots[i].itemId);


        }

        for (; i < slots.Length; i++)
        {
            slots[i].stocks = null;
        }
    }
}

