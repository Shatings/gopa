using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class JsonText : MonoBehaviour
{
    public Dictionary<int, string> textDi=new Dictionary<int, string>();
    public Dictionary<int, string> textName = new Dictionary<int, string>();
    // Start is called before the first frame update
    void Start()
    {
        Json();
        
    }
    void Json()
    {
        string jsonT= File.ReadAllText(Application.dataPath + "/Resources/DigoText.json");
        Debug.Log(" " + jsonT);
        JsonData diT = JsonMapper.ToObject(jsonT);
        for(int i = 0; i < diT.Count; i++)
        {
            textDi.Add(((int)diT[i]["Id"]),diT[i]["Text"].ToString());
            textName.Add(((int)diT[i]["Id"]), diT[i]["Name"].ToString());
            Debug.Log(" " + textDi[i]);
            Debug.Log(" " + textName[i]);
        }
     
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
