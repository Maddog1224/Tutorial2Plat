using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed = 0;
    public Text LivesText;
    public Text WinText;
    public Text ScoreText;
    public float jumpForce;
    
    private int scoreValue = 0;
    private int lives;
    private int count;
    private int score;

    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    private bool facingRight = true;
    public float hozMovement;
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
   
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        ScoreText.text = scoreValue.ToString();


        
            WinText.text = "";
            lives = 3;
            SetLivesText();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        if (facingRight == false && hozMovement > 0)
        {
            Flip();

        }

        else if (facingRight == true && hozMovement < 0)
        {
            Flip();

        }

    }
    void Update()
    {
        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }

        if (scoreValue >= 1)
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            ScoreText.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetScoreText();

            if (scoreValue == 4)
            {
                transform.position = new Vector3(96.0f, 0.0f, 4.0f);
                lives = 3;
                SetLivesText ();
            }
        }

        if (collision.collider.tag == "Enemy")
        {
            lives -= 1;
            LivesText.text = lives.ToString();
            Destroy(collision.collider.gameObject);
            SetLivesText();
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }





    }
    void OnTriggerEnter(Collider other)
    {


       
            if (other.gameObject.CompareTag("Coin"))
            {
                other.gameObject.SetActive(false);
                score = score + 1;
                SetScoreText();
            }


            else if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
                lives = lives - 1;
                SetLivesText();
            }



    }

    void SetScoreText()
    {
        ScoreText.text = "score " + scoreValue.ToString();
        if (scoreValue >= 8)
        {
            WinText.text = "You Win! Game created by James Draper";
            musicSource.clip = musicClipTwo;
            musicSource.Play();
             gameObject.SetActive(false);
        }
    }

    void SetLivesText()
    {
        LivesText.text = "lives " + lives.ToString();
        if (lives <= 0)
        {
            WinText.text = "You Lose :(";
             gameObject.SetActive(false);
        }
    }

 


}