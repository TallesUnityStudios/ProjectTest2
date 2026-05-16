using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Coin Effects/Kill Player")]
public class KillPlayerEffect : ItemCollactableCoinsFake
{
    public bool restartScene = true;

    public override void Apply(GameObject target)
    {
        Debug.Log("Player morreu!");

        Destroy(target);

        if (restartScene)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}
