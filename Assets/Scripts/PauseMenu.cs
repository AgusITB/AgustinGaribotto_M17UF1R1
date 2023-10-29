using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public static PauseMenu pM;
    public bool isPaused;

    void Awake()
    {
        if (PauseMenu.pM == null) PauseMenu.pM = this;
        else Destroy(this.gameObject);
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ResumeOrPause(isPaused ? false : true);
    }

    public void ResumeOrPause(bool pause)
    {
        pauseMenu.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
        isPaused = pause;
    }

}
