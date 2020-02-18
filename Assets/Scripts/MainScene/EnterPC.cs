
using UnityEngine;
using UnityEngine.UI;

public class EnterPC : MonoBehaviour
{
    public int energyCost, autismReduction;
    public GameObject buttonPrefab;

    private void Start()
    {
        buttonPrefab.GetComponent<Button>().onClick.AddListener(SetValues);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("Player entered the PC");
            buttonPrefab.SetActive(true);
            buttonPrefab.GetComponent<Button>().GetComponentInChildren<Text>().text = "Masturbate to Anime";
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            buttonPrefab.SetActive(false);
        }
    }

    void SetValues()
    {
        if (GameManager.instance.savedEnergyLevel >= energyCost && GameManager.instance.savedAutismLevel > 0)
        {
            GameManager.instance.SetStats(energyCost, autismReduction); 
        }
    }


}
