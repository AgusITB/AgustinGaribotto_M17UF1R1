using UnityEngine;
using UnityEngine.SceneManagement;

public class Gemstone : MonoBehaviour
{
    public static Gemstone g;
    public bool isActive;


    public void Awake()
    {
        if (Gemstone.g == null) Gemstone.g = this;
        else Destroy(this.gameObject);

        
    }
    public void Start()
    {
        if (GameController.gC.gemstonesDestroyed[SceneManager.GetActiveScene().buildIndex - 1])
        {
            GameObject.FindWithTag("Gemstone").SetActive(false);

        }
        else GameObject.FindWithTag("Gemstone").SetActive(true);
    }


}
