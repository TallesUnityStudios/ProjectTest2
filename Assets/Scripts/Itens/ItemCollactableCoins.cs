using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoins : ItemCollactableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instace.AddCoins();
    }
}
