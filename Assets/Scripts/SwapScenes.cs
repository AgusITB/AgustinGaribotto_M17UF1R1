using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    public GameObject player;
    int scenetoload;
    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(player.scene.name.ToString());
        if (collision.gameObject.CompareTag("Player"))
        {
            DontDestroyOnLoad(collision.gameObject);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("ChangeScene"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
            player.transform.position = new(player.transform.position.x+5, player.transform.position.y, player.transform.position.z);
            
            if (player.scene.name == "1")
            {
                scenetoload = 1;
            }
            else if(player.scene.name == "2")
            {
                scenetoload = 0;
            }
            SceneManager.LoadScene(1);

        }


    }
}
