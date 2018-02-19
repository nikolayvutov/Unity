using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text timer;


    private Rigidbody rb;
    private int count;
    private float timeleft;
    private int seconds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
        timeleft = 20;
        timer.text = "";
        timeleft = 20.0f;
    }
    void Update()
    {
        timeleft -= Time.deltaTime;  
        seconds = Convert.ToInt32(timeleft % 60);

        TimeLeft();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            if (count < 14 && loseText.text != "")
            {
                other.gameObject.SetActive(true);

            }
            else
            {
                other.gameObject.SetActive(false);
                count = count + 1;    
            }    
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); 
        if (count >= 14)
        {
            winText.text = "You Win!";
            loseText.text = "";
        }
    }

    void TimeLeft()
    {
        timer.text = "00:" + seconds.ToString();
        if (timeleft <= 0)
        {
            if (count < 14)
            {
                loseText.text = "You Lose!";
                winText.text = "";

            }

            timer.text = "";
        }
    }
}