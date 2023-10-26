using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player.scene.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DontDestroyOnLoad(collision.gameObject);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
            //  DontDestroyOnLoad(GameObject.FindGameObjectWithTag("ChangeScene"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("PauseMenu"));

            if (CompareTag("NextLevel"))
            {
                player.transform.position = new(player.transform.position.x + 5, player.transform.position.y, player.transform.position.z);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (CompareTag("PreviousLevel"))
            {
                player.transform.position = new(player.transform.position.x - 5, player.transform.position.y, player.transform.position.z);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }

        }


    }
}
