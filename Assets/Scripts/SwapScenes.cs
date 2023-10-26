using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    private int sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DontDestroyOnLoad(collision.gameObject);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("PauseMenu"));

            // Si el trigger es Next level iremos a la siguiente escena, si no lo es iremos a la anterior
            sceneToLoad = CompareTag("NextLevel") ? 1 : -1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneToLoad);

  

        }


    }
}
