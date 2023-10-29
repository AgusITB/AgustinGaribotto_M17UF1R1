using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private LevelConnection connection;

    [SerializeField]
    private string targetSceneName;

    [SerializeField]
    private Transform spawnPoint;

    private void Start()
    {
        if (connection == LevelConnection.ActiveConnection)
        {
            FindObjectOfType<Player>().transform.position = spawnPoint.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DontDestroyOnLoad(other.gameObject);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("PauseMenu"));
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Background"));
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("UI"));


        Player player = other.collider.GetComponent<Player>(); 
        
        if (player != null)
        {
            LevelConnection.ActiveConnection = connection;
            SceneManager.LoadScene(targetSceneName);        
        }
    }
}
