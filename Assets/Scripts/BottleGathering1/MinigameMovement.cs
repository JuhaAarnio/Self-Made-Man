using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigameMovement : MonoBehaviour
{
    float speed = 10f;
    Rigidbody2D rb;
    [SerializeField]
    int jumpCounter = 1;
    [SerializeField]
    TextMeshProUGUI timerText;
    int jumpCounterMax = 1;
    float timer = 120;
    float secs;
    int mins;
    GameManager gm;

    public Text hpText;
    public float maxVelocity = 10f;
    public float hitpoints = 100f;
    public float jumpForce = 200f;
    public BottleHandler bh;
    public bool isDead;
    
    

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = hitpoints.ToString();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameManager.instance;
        speed += (gm.savedDexterity / 10);
        jumpForce += (gm.savedStrenght / 10);
        timer += (gm.savedIntelligence);

        if (gm.savedDexterity > 30)
        {
            jumpCounter = 2;
            jumpCounterMax = 2;
        }
        if (gm.savedDexterity > 60)
        {
            jumpCounter = 3;
            jumpCounterMax = 3;
        }  
     
    }


    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        timer -= Time.deltaTime;
        mins = (int)timer / 60;
        secs = timer % 60;
        timerText.text = string.Format("{0:00}:{1:00.00}", mins, secs);
        Vector2 movement = new Vector2(speed * moveHorizontal, 0);
        rb.AddForce(movement);
        if (rb.velocity.sqrMagnitude > maxVelocity)
        {
            rb.velocity *= 0.99f;
        }
        if (Input.GetKeyDown("w"))
        {
            Jump(jumpCounter, jumpForce);
            jumpCounter--;
            if (jumpCounter <= 0)
            {
                jumpCounter = 0;
            }
        }

        if (timer <= 0)
        {
            Debug.Log("Time's Up!");
            isDead = false;
            bh.EndGame(isDead);
        }
    }

    void Jump(int jumpCounter, float jumpForce)
    {
        if (jumpCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            Vector2 jumpHeight = new Vector2(0, jumpForce);
            rb.AddForce(jumpHeight);
        } 
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("worldgeometry") || coll.gameObject.CompareTag("rock"))
        {
            jumpCounter = jumpCounterMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rock_bottom"))
        {
            hitpoints -= 25f;
            hpText.text = hitpoints.ToString();
            collision.gameObject.GetComponentInParent<Rock>().DestroyRock();
            if (hitpoints <= 0f)
            {
                Debug.Log("Game Over");
                isDead = true;
                bh.EndGame(isDead);
            }
        }
    }


} 
