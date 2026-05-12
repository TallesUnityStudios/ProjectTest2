using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProjectTest.Core.Singleton;
using UnityEditor.PackageManager.Requests;

public class ItemManager : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinText;

    void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinText.text = coins.ToString();
    }
}
