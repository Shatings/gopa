using UnityEngine;

public class RunPlayer : MonoBehaviour
{
    public GameM gameM;
    public float speed;
    public int score;
    [SerializeField]
    private Rigidbody2D rigd;
    private Collider2D colle;
    public bool jump = false;
    private bool jumping = false;
    public float jumppower;
    public float jumpdown = 3.0f;
    public Animator ani;
    public float mixX;
    public float maxX;
    public float downY = -3.851f;
    public float groundOnY = -3.44f;
    public bool stop = false;
    public bool FirstGO=false;
    public float time;
    public GameObject button;
    public GameObject mainB;

    // Start is called before the first frame update
    void Start()
    {
        maxX = transform.position.x;
        score = 0;
        speed = 10.0f;
        jumppower = 15.0f;
        gameM = FindObjectOfType<GameM>();
        rigd = GetComponent<Rigidbody2D>();
        colle = GetComponent<Collider2D>();
        ani = GetComponent<Animator>();
        maxX = 200;
        transform.position = new Vector2(transform.position.x, groundOnY);
        button = GameObject.Find("Canvas").transform.Find("Start").gameObject;
        mainB = GameObject.Find("Canvas").transform.Find("MainButton").gameObject;
        mainB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        

        if (time < 60&&FirstGO==true)
        {
            time += Time.deltaTime;
            Move();
            if (rigd.gravityScale != 30)
            {
                if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && jumping == false)
                {
                    ani.SetBool("Jump", true);
                    jump = true;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {

                    JumpDown();
                    jump = false;
                    if (jumping == false)
                        transform.position = new Vector3(transform.position.x, downY, transform.position.z);

                }
                else
                {

                    if (jump == true)
                    {
                        Debug.Log("앙");
                        transform.position = new Vector3(transform.position.x, groundOnY, transform.position.z);
                    }
                    ani.SetBool("Down", false);
                }
            }
        }
        else if(time>60)
        {
            stop = true;
        }
        if (stop == true)
        {
            mainB.SetActive(true);
        }
    }
    public void Move()
    {
        if (stop == false)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (speed <= 20)
            {
                speed += 0.5f * Time.deltaTime;
            }
        }
    }
    public void Jump()
    {
        if (jump != true)
        {

            return;
        }

        rigd.velocity = Vector2.zero;
        ani.SetBool("Jump", true);
        Vector2 jumpvector = new Vector2(0, jumppower);
        rigd.AddForce(jumpvector, ForceMode2D.Impulse);
        jump = false;
        jumping = true;

    }
    public void JumpDown()
    {
        Debug.Log("e");
        rigd.gravityScale = 30;
    }
    private void FixedUpdate()
    {
        Jump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ani.SetBool("Jump", false);

            jumping = false;

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {

            rigd.gravityScale = 5;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ani.SetBool("Down", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ObS")
        {
            stop = true;
            gameM.day += 10;
            ani.SetBool("Die", true);
        }
    }
    public void GO()
    {
        FirstGO = true;
        button.SetActive(false);
    }
}
