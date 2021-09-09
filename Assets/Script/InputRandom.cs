using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRandom : MonoBehaviour
{
    public int moneys;
    public int ints;
    public int randoms;
    public bool random=false;
    public float time = 0;
    public float textT = 0;
    public Text radomText;
    public GameM gameM;
    public int money=0;
    public GameObject[] Input=new GameObject[3];
    public Text resultT;
    
    // Start is called before the first frame update
    void Start()
    {
        gameM = FindObjectOfType<GameM>();
        radomText = GameObject.Find("Canvas").transform.Find("Texts").GetComponent<Text>();
        radomText.gameObject.SetActive(false);
        resultT= GameObject.Find("Canvas").transform.Find("ResultT").GetComponent<Text>();
        resultT.gameObject.SetActive(false);

        Input[1].SetActive(false);
        Input[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 10&&random==true)
        {
            time += Time.deltaTime;
            if (textT > 0.1f)
            {
                radomText.gameObject.SetActive(true);
                randoms = Random.Range(0, moneys + 1);
                radomText.text = " " + randoms;
                textT = 0;
            }
            
            
           
        }
        else if (time > 10)
        {
           
            MoneyCount(randoms);
            random = false;
            time = 0;
        }
       
        textT += Time.deltaTime;
    }
    public void InputT(string de)
    {
        moneys = int.Parse(de);
        if (moneys > 5||moneys<1)
        {
            Debug.Log("오류");
            return;
        }

        Input[0].SetActive(false);
        Input[1].SetActive(true);
        time = 0;
    }
    public void InputInt(string inputI)
    {
        ints = int.Parse(inputI);
        if (ints>moneys||ints<1)
        {
            Debug.Log("오류");
            return;
        }
        Input[1].SetActive(false);
        Input[2].SetActive(true);
    }
    public void InputM(string inputM)
    {
        money = int.Parse(inputM);
        if (gameM.money < money)
        {
            Debug.Log("돈이 부족합니다 "+(gameM.money-money));
            return;
        }
        gameM.money -= money;
        random = true;
        Input[2].SetActive(false);
        

    }
    public void MoneyCount(int _random)
    {
        resultT.gameObject.SetActive(true); 
        if (_random == ints)
        {
            Debug.Log("성공!");
            gameM.money += (money * moneys);
            resultT.text = "성공!\n"+ (money * moneys)+"원를 회득하셨습니다.";
            Debug.Log("dkdkd");
        }
        else
        {
            Debug.Log("실패했습니다..");
            
            gameM.money += (money / moneys);
            resultT.text = "실패!\n" + (money / moneys) + "원를 회득했습니다.";
            if (gameM.money < 0)
            {
                gameM.money = 0;
               
            }
        }
        time = 0;
    }
}
