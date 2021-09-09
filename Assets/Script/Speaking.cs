using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speaking : MonoBehaviour
{
    public TextM text;
    public Text texts;
    public GameObject textbox;
    public GameM gameM;
    public Text scoreT;
    public Text InveotoryT;
    public GameObject textOb;
   
    public Button button;
    public Text textN;
  
   
    public float time;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        textbox = GameObject.Find("TextBox").gameObject;
        texts = textbox.transform.Find("Text"). GetComponent<Text>();
        gameM = FindObjectOfType<GameM>();
        scoreT = transform.Find("Score").GetComponent<Text>();
        InveotoryT= transform.Find("InvetoryText").GetComponent<Text>();
        textOb = transform.Find("InvetoryText").gameObject;
        textN = textbox.transform.Find("TextName").GetComponent<Text>();
        textOb.SetActive(false);
        textbox.SetActive(false);
        
        
       
    }

    // Update is called once per frame
  


    void Update()
    {
        
        scoreT.text = "구독: " + gameM.subScb + " 돈:" + gameM.money+"  "+gameM.day+"일";
        if (textOb.activeSelf == true)
        {
            time += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.E)||time>5f)
            {
                Debug.Log("T:" + time);
                textOb.SetActive(false);
                time = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {


            Dige();
            
        }
    }
    public void Dige()
    {
        if (gameM.keyT <= gameM.keys)
        {
            textbox.SetActive(true);
            textN.text = "<size=60>" + gameM.textName[gameM.keyT]+"</size>";

            texts.text = "<size=50> " + gameM.textDi[gameM.keyT] + "</size>";
            gameM.keyT++;
        }
        else
        {
            textbox.SetActive(false);
        }
    }
    public void InvetoryError(item item,int id)
    {
        textOb.SetActive(true);
        switch (id) 
        {
            case 1:
                InveotoryT.text = item.buyDays + "일 부터 살수있습니다.";
                break;
            case 2:
                InveotoryT.text = item.itemName + "를 구매할려면 그전 스트리머를 구매하세요. ";
                break;
            case 3:
                InveotoryT.text = item.itemName + " 는 이미 있는 스트리머입니다.";
                break;
            case 4:
                InveotoryT.text =" 아직 스트리머를 구매하지 않았습니다.";
                break;
            case 5:
                InveotoryT.text ="를 사기에는 돈이 부족합니다.";
                break;
            default:
                return;
                
        }
        InveotoryT.text += "\n 창을 닫으시라면 e키를 누르세요";
       
    }
}
