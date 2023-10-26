using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class GameController : MonoBehaviour
{
    private GameObject checkPoint;
    public static GameController gC;

   

    public void RespawnPlayer(Player player)
    {
        checkPoint = GameObject.FindGameObjectWithTag("Respawn");
        player.transform.position = checkPoint.transform.position;  
        
    }
    void Awake()
    {
        if (GameController.gC == null) GameController.gC = this;
        else Destroy(this.gameObject);
    }

    public void ReLoadLevel(Player player)
    {
        SceneManager.LoadScene(1);
        player.transform.position = new(-19.96f, -9.4f, 1);
        Time.timeScale = 1f;
    }
}
