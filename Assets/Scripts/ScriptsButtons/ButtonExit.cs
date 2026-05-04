using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        // Isso serve para testar no Editor
        Debug.Log("Fechando o jogo...");
    }
}
