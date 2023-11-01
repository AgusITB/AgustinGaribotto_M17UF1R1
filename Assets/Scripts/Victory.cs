using UnityEngine;


public class Victory : MonoBehaviour
{
    public GameObject victory;
    public static Victory vT;
    private GameController controller;

    void Awake()
    {
        if (Victory.vT == null) Victory.vT = this;
        else Destroy(this.gameObject);
        victory.SetActive(false);
    }
    void Start()
    {
        controller = GameObject.FindWithTag("GameController").gameObject.GetComponent<GameController>();
    }
    void Update()
    {
        if (controller.CheckVictory())
        {
            victory.SetActive(true);
            Time.timeScale = 0f;
        } else 
        { 
            victory.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
