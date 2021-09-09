using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_M : MonoBehaviour
{

    public GameObject mainButton;
    public GameM gameM;
    public Invetory invetory;
    public Speaking speaking;
    void Start()
    {

        speaking = GameObject.Find("Canvas").transform.Find("Text").GetComponent<Speaking>();
        mainButton = GameObject.Find("Canvas").transform.Find("MainButton").gameObject;
        invetory = GameObject.Find("Canvas").transform.Find("Invetory").GetComponent<Invetory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpDay()
    {
        gameM = FindObjectOfType<GameM>();
        gameM.day += 360;
    }
    public void ItemImF(item _item)
    {
        invetory = GameObject.Find("Canvas").transform.Find("Invetory").GetComponent<Invetory>();
        for (int i = 0; i < invetory.items.Count; i++)
        {
            if (_item.id == invetory.items[i].id)
            {
                
                Debug.Log(" " + _item.itemName);
                return;
            }
        }
        invetory.errorId = 4;
        speaking.InvetoryError(_item, invetory.errorId);
        Debug.Log("아직 아이템이 없습니다");
        
    }
   
}
