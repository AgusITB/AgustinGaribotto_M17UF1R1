using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

class GameController : MonoBehaviour
{
    private GameObject checkPoint;
    public static GameController gC;
    public int gemstonesNeededToWin = 4;
    private int gemstonesCollected = 0;

    public TextMeshProUGUI gemstonesCount;
    public TextMeshProUGUI gemstonesText;
    public bool[] gemstonesDestroyed;

    public void Update()
    {


    }
    private bool CheckVictory()
    {
        return (gemstonesCollected == gemstonesNeededToWin);
    }
    public void AddGemstone()
    {
        gemstonesCollected++;
        if(!CheckVictory ())
        {
           gemstonesCount.text = gemstonesCollected.ToString();
        }
        else
        {
            gemstonesCount.text = "";
            gemstonesText.text = "All trinkets collected!";
        }
    }

    public void RespawnPlayer(Player player)
    {
        checkPoint = GameObject.FindGameObjectWithTag("Respawn");
        player.transform.position = checkPoint.transform.position;  
        
    }
    void Awake()
    {
        if (GameController.gC == null) GameController.gC = this;
        else Destroy(this.gameObject);
        gemstonesDestroyed = new bool[4];
    }

    public void ReLoadLevel(Player player)
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        gemstonesCollected = 0;
        gemstonesCount.text = gemstonesCollected.ToString();

       
        for (int i = 0; i < gemstonesDestroyed.Length; i++) 
        {
            gemstonesDestroyed[i] = false;
        }
        RespawnPlayer(player);
    }

}
