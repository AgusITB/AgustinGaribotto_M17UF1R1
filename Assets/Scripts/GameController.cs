using UnityEngine;
using TMPro;

class GameController : MonoBehaviour
{

    //Singleton
    public static GameController gC;

    //Checkpoint object
    private GameObject checkPoint;

    //UI
    public TextMeshProUGUI gemstonesCount;
    public TextMeshProUGUI gemstonesText;

    //Gemstones
    public bool[] gemstonesDestroyed;
    private int gemstonesNeededToWin = 5;
    private int gemstonesCollected = 0;

    //Victory menu
    public static GameObject victory;


    //Singleton
    void Awake()
    {

        if (GameController.gC == null) GameController.gC = this;
        else Destroy(this.gameObject);
        gemstonesDestroyed = new bool[5];
    }

    // Check if the player has collected the 5 gemstones needed to win
    public bool CheckVictory()
    {
        return (gemstonesCollected == gemstonesNeededToWin);
    }

    // We add gemstones to the gemstonesCollected int as the player collects the gems.
    public void AddGemstone()
    {
        gemstonesCollected+=1;
        if(!CheckVictory ()) gemstonesCount.text = gemstonesCollected.ToString();
        else
        { // If the player collects the gemstones needed to win we change the UI text.
            gemstonesCount.text = "";
            gemstonesText.text = "All trinkets collected!";
        }
    }

    //When the player dies we respawn it to the available checkpoint in the scene
    public void RespawnPlayer(Player player)
    {
        checkPoint = GameObject.FindGameObjectWithTag("Respawn");
        player.transform.position = checkPoint.transform.position;  
    }

    // Update the score, the UI text and the state of the gemstone objects
    public void ReLoadLevel()
    {
      
        Time.timeScale = 1f;
        gemstonesCollected = 0;
        gemstonesCount.text = gemstonesCollected.ToString();
        gemstonesText.text = "Gemstones: ";
        
        for (int i = 0; i < gemstonesDestroyed.Length; i++) gemstonesDestroyed[i] = false;

    }

}
