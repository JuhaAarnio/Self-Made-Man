using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterBed : MonoBehaviour {

    public GameObject buttonPrefab;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
        buttonPrefab.GetComponent<Button>().onClick.AddListener(Sleep);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("Entering bed");
            buttonPrefab.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("Leaving bed");
            buttonPrefab.SetActive(false);
        }
    }

    void Sleep()
    {
        Debug.Log("Sleeping");
        gm.savedEnergyLevel = gm.maxEnergy;
        gm.savedAutismLevel -= 50;
        gm.day += 1;
        if (gm.savedAutismLevel <= 0)
        {
            gm.savedAutismLevel = 0;
        }
        gm.autismText.text = gm.savedAutismLevel.ToString();
        gm.energyText.text = gm.savedEnergyLevel.ToString();
        gm.dayText.text = gm.day.ToString();
    }
}
