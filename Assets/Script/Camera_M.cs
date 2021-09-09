using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_M : MonoBehaviour
{
    public Player_M player;
    public bool move = false;
    public Vector3 vector;

    void Start()
    {
        player = FindObjectOfType<Player_M>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {
       

    }
    public void Move()
    {
        transform.position = player.transform.position+new Vector3(0,0,-10);
    }
}      //if (move == false)
        //{
        //    Debug.Log("M: " + move);

        //    move = true;
        //}
        //if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        //{
        //    if (Input.GetAxisRaw("Horizontal") > 0)
        //    {
        //        if (this.transform.position.x - Fplayer.transform.position.x < 5.0f)
        //        {
        //            transform.position = new Vector3(transform.position.x + Fplayer.speed * Time.deltaTime, transform.position.y, transform.position.z);
        //        }
        //        else
        //        {
        //            transform.position = new Vector3(transform.position.x + Fplayer.speed * Time.deltaTime, transform.position.y, transform.position.z);
        //        }


        //    }
        //    else if (Input.GetAxisRaw("Horizontal") < 0)
        //    {
        //        if (this.transform.position.x - Fplayer.transform.position.x > -5.0f)
        //        {
        //            transform.position = new Vector3(transform.position.x - Fplayer.speed * Time.deltaTime, transform.position.y, transform.position.z);
        //        }
        //        else
        //        {
        //            transform.position = new Vector3(transform.position.x - Fplayer.speed * Time.deltaTime, transform.position.y, transform.position.z);
        //        }

        //    }
        //    if (Input.GetAxisRaw("Vertical") > 0)
        //    {
        //        if (this.transform.position.x - Fplayer.transform.position.x < 5.0f)
        //        {
        //            transform.position = new Vector3(transform.position.x, transform.position.y + Fplayer.speed * Time.deltaTime, transform.position.z);
        //        }
        //        else
        //        {
        //            transform.position = new Vector3(transform.position.x, transform.position.y + Fplayer.speed * Time.deltaTime, transform.position.z);
        //        }


        //    }
        //    else if(Input.GetAxisRaw("Vertical") < 0)
        //    {
        //        if (this.transform.position.x - Fplayer.transform.position.x > -5.0f)
        //        {
        //            transform.position = new Vector3(transform.position.x, transform.position.y - Fplayer.speed * Time.deltaTime, transform.position.z);
        //        }
        //        else
        //        {
        //            transform.position = new Vector3(transform.position.x, transform.position.y - Fplayer.speed * Time.deltaTime, transform.position.z);
        //        }

        //    }


     

