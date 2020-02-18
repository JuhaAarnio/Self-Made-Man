using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottleHandler : MonoBehaviour
{
    [SerializeField]
    Text moneyText;
    [SerializeField]
    TextMeshProUGUI moneyEndText;
    [SerializeField]
    TextMeshProUGUI endPanelTitle;
    GameManager gm;
    [SerializeField]
    GameObject endPanel;

    public float collectedMoney;

    private void Start()
    {
        gm = GameManager.instance;
    }

    public void EndGame(bool isDead)
    {
        gm.savedMoney += collectedMoney;
        endPanel.SetActive(true);
        moneyEndText.text = collectedMoney.ToString();
        if (isDead)
        {
            endPanelTitle.text = "You fainted!";
        }
        else
        {
            endPanelTitle.text = "Time's Up!";
        }
        Time.timeScale = 0;
    }

    public void UpdateText()
    {
        moneyText.text = collectedMoney.ToString();
    }

}
