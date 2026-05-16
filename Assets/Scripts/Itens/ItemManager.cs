using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProjectTest.Core.Singleton;
using UnityEditor.PackageManager.Requests;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instace;

    public int coins;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        if (Instace == null)
        {
            Instace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
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
        UIinGameManager.UpdateTextCoins(coins.ToString());
    }
}
