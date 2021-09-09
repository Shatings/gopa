using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invetory : MonoBehaviour
{
    public List<item> items;
    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Solt[] slots;
    private GameM gameM;
    public int idNuber=1;
    public Speaking speaking;
    public int errorId;
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Solt>();
        gameM = FindObjectOfType<GameM>();
        speaking = FindObjectOfType<Speaking>();
    
    }
    private void Awake()
    {
      
        
           
        
        Freshlot();
    }
    public void Freshlot()
    {
        
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
            slots[i].itemId = items[i].id;
            Debug.Log(" " + slots[i].itemId);
          
            
        }
        
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }
    public void LoadInv()
    {
        idNuber = gameM.idNumber;
       for(int i = 0; i < gameM.invetory.Count; i++)
       {
           
            items.Add(gameM.invetory[i]);
            slots[i].item = gameM.invetory[i];
            gameM.OnNpcLoad(gameM.invetory[i]);
       }
       





    }
    public void Additem(item _item) {
        if (items.Count < slots.Length)
        {
            Debug.Log("0");
            Debug.Log("Le: "+items.Count);
            Debug.Log("IDN: " + idNuber);
            if (gameM.day < _item.buyDays)
            {
                errorId = 1;
                speaking.InvetoryError(_item,errorId);
                Debug.Log("방송일자가 부족합니다");
                return;
            }
            if(idNuber < _item.id)
            {
                errorId = 2;
                speaking.InvetoryError(_item, errorId);
                Debug.Log("그 전 스트리머를 사세요");
                return;
            }
            for (int i = 0; i < items.Count; i++)
            {
                Debug.Log("게임일자 "+gameM.day);
                Debug.Log("살수있는 일자 " + _item.buyDays);
                if (items[i].id == _item.id)
                {
                    errorId = 3;
                    speaking.InvetoryError(_item, errorId);
                    Debug.Log("중복된 아이템입니다");
                    return;
                }
                if (_item.buyMoney > gameM.money)
                {
                    errorId = 5;
                    speaking.InvetoryError(_item, errorId);
                    Debug.Log("돈이 부족합니다");
                    return;
                }
                
                
            }
            idNuber++;

            gameM.money -= _item.buyMoney;
            items.Add(_item);
            gameM.invetory.Add(_item);
            gameM.idNumber = idNuber;
            gameM.OnNpcLoad(_item);
            Freshlot();
          
        }
        else
        {
            Debug.Log("가득찼습니다");
        }
    }

}
