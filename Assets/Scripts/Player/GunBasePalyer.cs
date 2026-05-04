using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBasePalyer : MonoBehaviour
{
    public GunPlayer prefabProjectilleGun;

    [Header("Settings Shoot")]
    public Transform positionShoot;
    public float timeBetweenShoot = .2f;
    public Transform directionPlayerReference;

    private Coroutine _currentCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectille = Instantiate(prefabProjectilleGun);
        projectille.transform.position = positionShoot.position;
        projectille.side = directionPlayerReference.localScale.x;
    }
}
