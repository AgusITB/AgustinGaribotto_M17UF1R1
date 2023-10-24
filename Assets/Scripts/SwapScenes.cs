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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(player.scene.name.ToString());
        if (collision.gameObject.CompareTag("Player"))
        {
            DontDestroyOnLoad(collision.gameObject);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Respawn"));
            int scene = Convert.ToInt32(player.scene.name.ToString()) + 1;
            Debug.Log($"scene: {scene}");
            SceneManager.LoadScene($"{scene}");
            player.transform.position = new(-21, -10, 1);
        }


    }
}
