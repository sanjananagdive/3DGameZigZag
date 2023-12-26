using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float speed;//1

    Rigidbody rb;//2 : declare, define in awake 

    bool gameStarted;//3,started, bool to check if game started bc at
                     //start of game we will move ball
    bool gameOver;//4

    int diamondCollected = 0;

    public GameObject partical;

    public Text dcText;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStarted= false;//initially game not started will be not started 
        //only at beggining of game

        gameOver = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        //at begining only game not started therefore this if condn will only
        //be satisfied once
        if (!gameStarted)//if game not started then touch to start
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(0, 0, speed);

                gameStarted = true;//this if loop will now be executed only once as we are
                //setting true immediately after providing velocity

                GameManager.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 8f))
        {
            gameOver = true;


            rb.velocity = new Vector3(0, -25f, 0);//since ball doesnt have any gravity

            Camera.main.GetComponent<CameraController>().gameOver = true;

            PlatformSpawner.instance.gameOver = true;

            GameManager.instance.GameOver();

        }

        //now next if will keep executing whenever left mouse key pressed
        if (Input.GetMouseButtonDown(0) && !gameOver)//if gameOver happens then switchingof dirn not possible
        {
            SwitchDirection();
        }

        
        
    }

    //fn to switch dirn
    void SwitchDirection()
    {
        if(rb.velocity.z > 0)// if velocity in z dirn then it will be >0 :.
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            diamondCollected++;

            dcText.text = diamondCollected.ToString();

            GameObject part = Instantiate(partical, col.gameObject.transform.position, Quaternion.identity);

            Destroy(col.gameObject);

            Destroy(part, 1f);


        }
    }

    
}
