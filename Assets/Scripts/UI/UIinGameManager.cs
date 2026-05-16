using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProjectTest.Core.Singleton;

public class UIinGameManager : Singleton<UIinGameManager>
{
    public TextMeshProUGUI coinsText;

    public static void UpdateTextCoins(string coins)
    {
        Instance.coinsText.text = coins;
    }
}
