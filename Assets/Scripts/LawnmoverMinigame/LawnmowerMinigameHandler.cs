using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerMinigameHandler : MonoBehaviour
{
    public float collectedMoney;
    GameManager gm = GameManager.instance;
    void EndGame(float collectedMoney)
    {
        gm.savedMoney = collectedMoney;
    }
}
