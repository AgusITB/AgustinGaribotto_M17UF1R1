using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private LevelConnection connection;
    [SerializeField]
    private LevelConnection firstLevel;

    [SerializeField] //We will tell in the inspector which scene will target each LevelChanger
    private string targetSceneName;
    [SerializeField] //Each LevelChanger will have a position which will be used to move the player between scenes
    private Transform spawnPoint;

    private GameController gameController;
    private Player player;

    // On start of the level changer if the connection available in the screen is the active one
    // (it activates when the player collides with the level changer)
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>();

        //If the active conection is the same as one of the connections in the scene it means we activated a connection while colliding
        //with the player or pressing the reset game button on the menu then, we move the player to the respective spawnpoint after loading the scene
        if (connection == LevelConnection.ActiveConnection) player.transform.position = spawnPoint.position;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.collider.GetComponent<Player>();

        if (player != null)
        {
            //When we change scenes we want to make sure the next game objects become persistent so they can be accessed in the future scenes
            DontDestroyOnLoad(other.gameObject);
            DontDestroyOnLoad(gameController);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("PauseMenu"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Background"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("UI"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("FirstLevelSpawner"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("VicMenu"));

            LevelConnection.ActiveConnection = connection;
            SceneManager.LoadScene(targetSceneName);
        }
      
    }
    // We will call this function when the user presses the Reset Game button on the menu or the Victory screen
    public void Reset()
    {
        // We will set as the active connection the firstLevel connection so it automatically teleports the player to
        // its spawner on loading the first scene
        LevelConnection.ActiveConnection = firstLevel; 
        SceneManager.LoadScene(targetSceneName);
        gameController.ReLoadLevel();

    }



}
