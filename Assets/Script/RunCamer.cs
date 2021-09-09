using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCamer : MonoBehaviour
{
    public RunPlayer player;
    public float minX;
    public int i = 0;
    
    void Start()
    {
        minX = transform.position.x;
        player = FindObjectOfType<RunPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime<60)
        {
            Move();
        }
    }
    public void Move()
    {
        if (player.stop == false&&player.FirstGO)
        {
            if(transform.position.x-8>=player.transform.position.x)
            {
                Debug.Log("앙기모띠");
                transform.position = new Vector3(player.transform.position.x + 8, transform.position.y,transform.position.z);
            }
            transform.position = new Vector3(transform.position.x + player.speed * Time.deltaTime, transform.position.y, transform.position.z);

            //if (transform.position.x >= player.maxX)
            //{
            //    player.transform.position = new Vector3(player.mixX, player.transform.position.y, player.transform.position.z);

            //    transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            //    i++;
            //}
        }
        else
        {
            Debug.Log("엄");
        } 
    }

}
