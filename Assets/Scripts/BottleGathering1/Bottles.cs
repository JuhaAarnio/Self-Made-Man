using UnityEngine;

public class Bottles : MonoBehaviour
{   
    public float bottleValue;
    BottleHandler bh;


    private void Start()
    {
        bh = GameObject.Find("BottleMinigameHandler").GetComponent<BottleHandler>();
    }
    private void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime);
        if (gameObject.transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            bh.collectedMoney += bottleValue;
            bh.UpdateText();
            Destroy(gameObject);
        }
    }

}
