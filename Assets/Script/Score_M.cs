using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score_M : MonoBehaviour
{
    public Text text;
    public double score = 1;
    public double scoreT = 0;
    public double scoreEnd=0;
    public RunPlayer player;
    public GameObject ScoreText;
    public Text endScoreText;
    public bool check=true;
    public int gameS;
    
    // Start is called before the first frame update
    void Start()
    {
        gameS = 0;
        player = FindObjectOfType<RunPlayer>();
        text = GameObject.Find("Canvas").transform.Find("Score").GetComponent<Text>();
        text.text =" "+scoreT;
        ScoreText = GameObject.Find("Canvas").transform.Find("EndScore").gameObject;
        endScoreText = ScoreText.transform.Find("EndST").GetComponent<Text>();
        ScoreText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.time < 60 && player.stop == false & player.FirstGO)
        {
            score += 2f * Time.deltaTime;
            scoreT += score * Time.deltaTime;
            text.text = " " + (+Math.Round(scoreT));
        }
        if (check) {
            if (player.time > 60)
            {

                scoreEnd = 0;
                Score(scoreEnd);
                scoreEnd = Math.Round((Math.Round(scoreT)) + (Math.Round(scoreT) * (player.gameM.subP = FindObjectOfType<GameM>().subP)));
                Debug.Log("id: " + scoreEnd);
                ScoreText.SetActive(true);
                scoreEnd = Math.Round((Math.Round(scoreT)) + (Math.Round(scoreT) * (player.gameM.subP = FindObjectOfType<GameM>().subP)));

                endScoreText.text = "점수: " + Math.Round(scoreT) + "\n보너스점수:" + Math.Round(scoreT) + "x" + (player.gameM.subP = FindObjectOfType<GameM>().subP) + "=" + (Math.Round(scoreEnd) - Math.Round(scoreT))
                    + "\n최종점수:" + scoreEnd+"\n올라간 구독자수:"+gameS;
              

            }
            else if (player.stop == true )
            {

                scoreEnd = 0;

                scoreEnd = Math.Round((Math.Round(scoreT)) + (Math.Round(scoreT) * (player.gameM.subP = FindObjectOfType<GameM>().subP)));
                ScoreText.SetActive(true);
                Score(scoreEnd);

                endScoreText.text = "점수: " + Math.Round(scoreT) + "\n보너스점수:" + Math.Round(scoreT) + "x" + (player.gameM.subP = FindObjectOfType<GameM>().subP) + "=" + (Math.Round(scoreEnd) - Math.Round(scoreT))
                    + "\n최종점수:" + scoreEnd + "\n올라간 구독자수:" + gameS;
                
            }
        }
    }
    public void Score(double score)
    {
        if (check)
        {
            GameM gameM = FindObjectOfType<GameM>();
            if (score > 1 && score < 1000)
            {
                gameS = 1000;
                gameM.subScb += gameS;
            }
            else if (score > 1000 && score < 4700)
            {
                gameS = 2000;
                gameM.subScb += gameS;
            }
            else if (score > 4700 && score < 5100)
            {
                gameS = 4000;
                gameM.subScb += gameS;
            }
            else if (score > 5100 && score < 5800)
            {
                gameS = 5000;
                gameM.subScb += gameS;
            }
            else if (score > 5800 && score < 7200)
            {
                gameS = 6000;
                gameM.subScb += gameS;
            }
            else if (score > 7200 && score < 14000)
            {
                gameS = 7000;
                gameM.subScb += gameS;
            }
            else
            {
                endScoreText.text = "<size=50>점수가 너무 낮아 점수를 얻지못합니다</size>";
            }
            check = false;
            
           
        }
        
        
    }
}
