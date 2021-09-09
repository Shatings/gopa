using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameM : MonoBehaviour
{
    public GameM gameM;
    
    // Start is called before the first frame update
    void Start()
    {
        gameM = FindObjectOfType<GameM>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
