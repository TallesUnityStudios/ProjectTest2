using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProjectTest.Core.Singleton;
using UnityEditor.PackageManager.Requests;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instace;

    public SOint coins;
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
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //UIinGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
