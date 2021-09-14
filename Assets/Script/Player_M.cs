using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_M : MonoBehaviour
{
    
    [SerializeField]
    private Vector3 vector;
    [SerializeField]
    private bool moveing;

 

    private float orderT;
    private GameObject inverty;
    private bool invertyOn=false;
    public float speed = 5f;
    private Collider2D coll;
    private Rigidbody2D rigid;
    public GameObject shop;
    public float shopT;
    public bool shopOn=false;
    public ScenesM scenes;
    public GameM gameM;
    public float shopX=-127f;
    public float mainX = 0;
    


    // Start is called before the first frame update
    void Start()
    {

        shopX = -127f;
        speed = 5f;
        coll = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
        inverty = GameObject.Find("Canvas").transform.Find("Invetory").gameObject;
        inverty.transform.Find("Bag").gameObject.SetActive(false);
        shop = GameObject.Find("Canvas").transform.Find("BuySt").gameObject;
        shop.SetActive(false);
        scenes = FindObjectOfType<ScenesM>();
        gameM = FindObjectOfType<GameM>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {
       
        if (moveing)
        {
            oderMoving();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inVetry();
        }
        if (shopOn)
        {
            Shop();
        }
    }
    public void Shop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            shop.SetActive(true);
        }
        if (shop.activeSelf)
        {
            shopT += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.E) && shopT > 0.5f)
            {
                Debug.Log("EX");
                shop.SetActive(false);
                shopT = 0;
            }
        }
    }
    public void oderMoving()
    {
        orderT += Time.deltaTime;
        if (orderT < 10f)
        {
            
            Debug.Log("움직여");

           transform.position += vector * speed * Time.deltaTime;
           
        }
        else
        {
            Debug.Log("끝끝");
            return;
        }

    }
   public void inVetry()
    {
        if (invertyOn)
        {
            inverty.transform.Find("Bag").gameObject.SetActive(false);
            invertyOn = false;
            
        }
        else
        {
            inverty.transform.Find("Bag").gameObject.SetActive(true);
            invertyOn = true;
        }
    }
    public void Move()
    {
        
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
           
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                vector = Vector2.right;
                Debug.Log("오");
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                vector = Vector2.left;
                Debug.Log('왼');
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                vector = Vector2.up;
                Debug.Log('위');


            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                vector = Vector2.down;
                Debug.Log("아래");


            }
           transform.position += vector * speed * Time.deltaTime;
            
        }
        
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Di")
        {
            scenes.DiGame();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shop")
        {

            Debug.Log("B");
            shopOn = true;
        }

        if (collision.gameObject.tag == "Npc")
        {
            Debug.Log("" + 1);
        }
        if (collision.gameObject.tag == "Npc2")
        {
            Debug.Log("" + 2);
        }
        if (collision.gameObject.tag == "Npc3")
        {
            Debug.Log("" + 3);
        }
        if (collision.gameObject.tag == "Npc4")
        {
            Debug.Log("" + 4);
        }
        if (collision.gameObject.tag == "Npc5")
        {
            Debug.Log("" + 5);
        }
        if (collision.gameObject.tag == "Npc6")
        {
            Debug.Log("" + 6);
        }
        if (collision.gameObject.tag == "Npc7")
        {
            Debug.Log("" + 7);
        }
        if (collision.gameObject.tag == "Npc8")
        {
            Debug.Log("" + 8);
        }
        if (collision.gameObject.tag == "Npc9")
        {
            Debug.Log("" + 9);
        }
        if (collision.gameObject.tag == "Npc10")
        {
            Debug.Log("" + 10);
        }
        if (collision.gameObject.tag == "Npc11")
        {
            Debug.Log("" + 11);
        }
        if (collision.gameObject.tag == "Npc12")
        {
            Debug.Log("" + 12);
        }
        if (collision.gameObject.tag == "MainHoll")
        {
            this.transform.position = new Vector3(shopX, transform.position.y, transform.position.z);
            if (gameM.gameLoad == 1)
            {
                gameM.mainKeyEnd = 14;
                gameM.mainKeyStart = 6;
                FindObjectOfType<Speaking>().Dige();

                this.transform.position = new Vector3(shopX, transform.position.y, transform.position.z);
            }
        }
        if (collision.gameObject.tag == "MainQuit")
        {
            this.transform.position = new Vector3(mainX, transform.position.y, transform.position.z);
        }
        if (collision.gameObject.tag == "GameOn")
        {
            if (gameM.gameLoad == 3)
            {
                gameM.mainKeyEnd = 27;
                gameM.mainKeyStart = 25;
                FindObjectOfType<Speaking>().Dige();
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shpp")
        {
            Debug.Log("A");
            shopOn = false;
            shop.SetActive(false);
            shopT = 0;
        }
    }

}
