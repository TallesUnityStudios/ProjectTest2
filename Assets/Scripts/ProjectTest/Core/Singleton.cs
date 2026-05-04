using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTest.Core.Singleton
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        private void Awake()
        {
        //Verificacao para garantir que apenas uma instância do GameManager exista
         if (Instance == null)
                Instance = GetComponent<T>();
            else
                Destroy(gameObject);

        }
    }
}

