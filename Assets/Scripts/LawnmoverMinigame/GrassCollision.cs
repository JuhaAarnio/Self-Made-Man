
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrassCollision : MonoBehaviour
{
    [SerializeField]
    float grassValueBase;
    [SerializeField]
    LawnmowerMinigameHandler lmg;
    [SerializeField]
    TextMeshProUGUI moneyText;
    
    float grassValueTotal;
    readonly GameManager gm = GameManager.instance;
    // Start is called before the first frame update
    void Start()
    {
        grassValueTotal = grassValueBase + gm.savedCharisma;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.tag = "grass";
        lmg.collectedMoney += grassValueTotal;
        moneyText.text = grassValueTotal.ToString();
        Destroy(collision.gameObject);
    }
}
