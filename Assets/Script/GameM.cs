using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using LitJson;

public class GameM : MonoBehaviour
{
    public int money;
    public int subScb;
    public int day;
    
    [SerializeField]
    public int gameLoad=0;
    private  static GameM instance;
    
    public  List<item> invetory;
    public Invetory inv;
    public double subP=0;
    public int idNumber=1;
    public int slotsIdNm =1;
    
    public List<GameObject> npcOb;
    public GameObject npOb;
   
    public List<Stocks> stInv;
    public SlotInv slotIv;
    
    public RandomM random;
    public List<int> slotsMoney = new List<int>();
    public Vector3 npcTf;

    public TextAsset txt;
    [SerializeField]
    public string[,] sentence;
    [SerializeField]
    public Dictionary<int, string> textDi = new Dictionary<int, string>();
    public Dictionary<int, string> textName = new Dictionary<int, string>();
    public int keyT=0;
    public int keys = 5;
    public int gameplaying=0;
    void Json()
    {
        string jsonT = File.ReadAllText(Application.dataPath + "/Resources/Json/DigoText.json");
        Debug.Log(" " + jsonT);
        JsonData diT = JsonMapper.ToObject(jsonT);
        for (int i = 0; i < diT.Count; i++)
        {
            textDi.Add(((int)diT[i]["Id"]), diT[i]["Text"].ToString());
            textName.Add(((int)diT[i]["Id"]), diT[i]["Name"].ToString());
            Debug.Log(" " + textDi[i]);
            Debug.Log(" " + textName[i]);
        }



    }
    private void Awake()
    {
        money = 1000;
        subScb = 0;
        day = 1;
        idNumber = 1;
        slotsIdNm = 1;
        Json();
        string currentText = txt.text.Substring(0, txt.text.Length - 1);

        Debug.Log("릴");
        
        
      
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnLoadScene;
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }
    
  
    
    // Start is called before the first frame update
   
    public void UpDay()
    {
        day += 360;
    } 
    
public void OnLoadScene(Scene scene, LoadSceneMode mode)
{
    if (scene.name == "DiGame")
    {
            subP = 0;
            Debug.Log("T " + inv.items[0]);
            Debug.Log("S->T");
            if (invetory.Count != 0)
            {
                for(int i = 0; i < invetory.Count; i++)
                {
                    subP += invetory[i].upScore;
                }
            }
            Debug.Log(" " + subP);
            
    }
    if (scene.name == "MainGame")
    {
        Money();

        inv = GameObject.Find("Canvas").transform.Find("Invetory").GetComponent<Invetory>();
        inv.LoadInv();

        Debug.Log("T->S");
    }
    if (scene.name == "RandomMine")
    {
        random = FindObjectOfType<RandomM>();
        
        slotIv = GameObject.Find("Canvas").transform.Find("Invetory").GetComponent<SlotInv>();
        slotIv.LoadInv();
            
    }
   

}
   public void Money()
   {
        if (subScb > 1 && subScb < 100000)
        {
            money +=1000;
        }
        else if (subScb > 100000 && subScb < 20000)
        {
            money +=2000;
        }
        else if (subScb > 200000 && subScb < 300000)
        {
            money +=3000;
        }
        else if (subScb > 300000)
        {
            money +=5000;
        }
        else
        {
            Debug.Log("오류");
        }
   }
    public void OnNpcLoad(item _item)
    {
        Debug.Log("오브젝트불러오기1");
        for (int i = 0; i < invetory.Count; i++)
        {
              Debug.Log("오브젝트불러오기2");
            if (i==_item.id-1&&GameObject.Find("Npc"+(i+1)+ "(Clone)")==null)
            {
                Debug.Log("오브젝트불러오기3");
                npOb = Resources.Load("Ob/Npc" + invetory[i].id) as GameObject;
                NpcV(invetory[i]);
                Debug.Log(npOb);
                Debug.Log(npcTf);
                npOb = Instantiate(npOb, npcTf, Quaternion.identity);
            }
            
              
            
        }
    }
    
    public void NpcV(item _items)
    {
        npcTf = new Vector3(_items.id + _items.id,0, 0);

    }
}
