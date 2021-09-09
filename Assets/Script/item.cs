using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int id;
    public int buyDays;
    public double upScore;
    public int buyMoney;

    public item(string Name,int Id, int BuyDays,double UpScore,int BuyMoney)
    {
        itemName = Name;
       
        id = Id;
        buyDays = BuyDays;
        upScore = UpScore;
        buyMoney = BuyMoney;
    }

   
    // Start is called before the first frame update
    
}
