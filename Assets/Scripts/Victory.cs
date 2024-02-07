using System;
using UnityEngine;


public class Victory : MonoBehaviour
{
    public static Victory instance;

    void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        GameController.playerWon += PlayerWon;
        GameController.playerRestarted += PlayerRestarted;

    }
    private void PlayerWon()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0f;

    }
    private void PlayerRestarted()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1f;
    }


}
