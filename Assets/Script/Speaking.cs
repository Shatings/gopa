using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speaking : MonoBehaviour
{
 
    public Text texts;
    public GameObject textbox;
    public GameM gameM;
    public Text scoreT;
    public Text InveotoryT;
    public GameObject textOb;
   
    public Button button;
    public Text textN;
    public List<GameObject> Que = new List<GameObject>();
   
    public float time;
    public bool endSpeking = false;

    public bool answeron = false;
    public Image textImage;


  
    // Start is called before the first frame update
    void Start()
    {
        textbox = GameObject.Find("TextBox").gameObject;
        texts = textbox.transform.Find("Text"). GetComponent<Text>();
        textImage = textbox.transform.Find("Image").GetComponent<Image>();
        gameM = FindObjectOfType<GameM>();
        scoreT = transform.Find("Score").GetComponent<Text>();
        InveotoryT= transform.Find("InvetoryText").GetComponent<Text>();
        textOb = transform.Find("InvetoryText").gameObject;
        textN = textbox.transform.Find("TextName").GetComponent<Text>();
        textOb.SetActive(false);
        textbox.SetActive(false);
        for(int i = 0; i < Que.Count; i++)
        {
            Que[i].SetActive(false);
        }
        if (gameM.gameLoad == 0)
        {
            Dige();
        }
        
        
       
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
        
        if (Input.GetKeyDown(KeyCode.Space)||gameM.reTextS)
        {
            gameM.reTextS = false;
            if (answeron == true)
            {
                AnswerDigo();
            }
            else
            {
                Dige();
            }
            
            
        }
        
    }
    public void Dige()
    {
        if (gameM.mainKeyStart <= gameM.mainKeyEnd)
        {
            FindObjectOfType<Player_M>().moveing = false;
            endSpeking = false;
            textbox.SetActive(true);
            textImage.sprite = Resources.Load(gameM.images[gameM.mainKeyStart], typeof(Sprite)) as Sprite;
            textN.text = "<size=60>" + gameM.textName[gameM.mainKeyStart]+"</size>";

            texts.text = "<size=50> " + gameM.textDi[gameM.mainKeyStart] + "</size>";
            
            if (gameM.mainKeyStart == gameM.mainKeyEnd&&gameM.gameLoad==1)
            {
                Quist();
               
            }
            gameM.mainKeyStart++;
        }
        else
        {
            Debug.Log("들가자");
            
            textbox.SetActive(false);
        }
        if (gameM.mainKeyStart > gameM.mainKeyEnd && endSpeking == false)
        {
            FindObjectOfType<Player_M>().moveing = true;
            endSpeking = true;
            gameM.gameLoad++;
        }
    }
    public void Quist()
    {
        
        for(int i = 0; i < Que.Count; i++)
        {
            Que[i].SetActive(true);
            Que[i].transform.Find("Text").GetComponent<Text>().text = "<size=50> " + gameM.Queist[i]+"</size>";
        }
        
    }
    public void Answer(GameObject ob)
    {
        int index = 0;

        
        for(int i = 0; i < Que.Count; i++)
        {
         
            if (ob.name.Equals(Que[i].name))
            {
                Debug.Log("클릭~ "+ob.name);
                
                index = i;
                
             
            }

            Que[i].SetActive(false);
        }
      
       
        switch (index)
        {
            case 0:
                if (gameM.gameLoad == 2)
                {
                    gameM.answerStart = 0;
                    gameM.answerEnd = 2;
                }
                break;
            case 1:
                if (gameM.gameLoad == 2)
                {
                    gameM.answerStart = 3;
                    gameM.answerEnd = 5;
                }
                break;
            case 2:
                if (gameM.gameLoad == 2)
                {
                    gameM.answerStart = 6;
                    gameM.answerEnd = 8;
                }
                break;
            case 3:
                if (gameM.gameLoad == 2)
                {
                    gameM.mainKeyStart++;
                    gameM.mainKeyEnd += 10;
                }
                break;
        }
       
        if (index == 3)
        {
            Dige();
        }
        else
        {
            answeron = true;
            AnswerDigo();
        }
    }
    void AnswerDigo()
    {
        if (gameM.answerStart <= gameM.answerEnd)
        {
            textbox.SetActive(true);
            textImage.sprite = Resources.Load(gameM.answerImages[gameM.answerStart], typeof(Sprite)) as Sprite;
            textN.text = "<size=60>" + gameM.answerName[gameM.answerStart] + "</size>";

            texts.text = "<size=50> " + gameM.answerT[gameM.answerStart] + "</size>";
            gameM.answerStart++;
        }
        else
        {
            Debug.Log("들가자");
            answeron = false;
           
            Quist();


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
