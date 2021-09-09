using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Stocks : ScriptableObject
{
    public int id;
    public string stocksN;
    public int buyMoney;
    public Sprite image;
    public Stocks(int _id,string _stockN,int _buyM)
    {
        id = _id;
        stocksN = _stockN;
        buyMoney = _buyM;
    }
}
