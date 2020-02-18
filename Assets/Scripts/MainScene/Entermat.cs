
using UnityEngine;
using UnityEngine.UI;

public class Entermat : MonoBehaviour {

    public int energyCost, autismAdded, strAdded;
    public GameObject buttonPrefab;
    public GameObject buttonContainer;

    private void Start()
    {
        buttonPrefab.GetComponent<Button>().onClick.AddListener(SetValues);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            buttonPrefab.SetActive(true);
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
        
        if (GameManager.instance.savedStrenght <= 10 && GameManager.instance.savedEnergyLevel >= energyCost)
        {
            GameManager.instance.SetStats(energyCost, autismAdded);
            GameManager.instance.SetAttribute(3, strAdded);
        }
    }


}
