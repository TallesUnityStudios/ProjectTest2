using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectTest.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

}
