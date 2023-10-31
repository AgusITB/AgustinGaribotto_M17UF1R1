using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

class GameController : MonoBehaviour
{
    private GameObject checkPoint;
    public static GameController gC;
    public int gemstonesNeededToWin = 5;
    public int gemstonesCollected = 0;

    public TextMeshProUGUI gemstonesCount;
    public TextMeshProUGUI gemstonesText;
    public bool[] gemstonesDestroyed;

    public static GameObject victory;

    public bool CheckVictory()
    {
        return (gemstonesCollected == gemstonesNeededToWin);
    }
    public void AddGemstone()
    {
        gemstonesCollected+=1;
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
        gemstonesDestroyed = new bool[5];
    }

    public void ReLoadLevel(Player player)
    {

        SceneManager.LoadScene(1);
        RespawnPlayer(player);
        Time.timeScale = 1f;
        gemstonesCollected = 0;
        gemstonesCount.text = gemstonesCollected.ToString();
        gemstonesText.text = "Gemstones: ";
        
        for (int i = 0; i < gemstonesDestroyed.Length; i++) 
        {
            gemstonesDestroyed[i] = false;
        }
      

    }

}
