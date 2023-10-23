using System.Collections;
using System.Collections.Generic;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            DontDestroyOnLoad(collision.gameObject);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MainCamera"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));

            SceneManager.LoadScene("Level2");

        }


    }
}
