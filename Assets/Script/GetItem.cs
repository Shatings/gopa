using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class  Items {

    private static int m_nID;

    private static string m_strName;

    private static string m_strIcon;

    private static int m_nBuyCost;

 



    public int ID

    {

        set { m_nID = value; }

        get { return m_nID; }

    }

    public string NAME

    {

        set { m_strName = value; }

        get { return m_strName; }

    }

    public string ICON

    {

        set { m_strIcon = value; }

        get { return m_strIcon; }

    }

    public int BUY_COST

    {

        set { m_nBuyCost = value; }

        get { return m_nBuyCost; }

    }

    


}

public class GetItem : MonoBehaviour
{
    public Items item;
    public xmlLoad xmlload;

    private void Awake()
    {
        xmlload = GetComponent<xmlLoad>();
               
    }
    private void Start()
    {
        item = new Items();

        for(int i = 1; i<xmlload.lineSize ; i++)
        {
            for (int j = 0; j < xmlload.rowSize; j++) {
                switch (j)
                {
                    case 0:
                        item.ID = i;
                        //Debug.Log("ID "+i);
                        break;

                    case 1:
                        
                        //Debug.Log("이름 " + xmlload.sentence[i, j]);
                        break;
                    case 2:
                        
                        //Debug.Log("Day " + xmlload.sentence[i, j]);
                        break;
                    case 3:
                        //Debug.Log("아이콘 " + xmlload.sentence[i, j]);
                        break;
                }
            }
        }

    }


    private void Update()
    {
       

    }
    




}

