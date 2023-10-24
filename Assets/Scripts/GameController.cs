using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class GameController : MonoBehaviour
{
    public GameObject enabledCheckpoint;
    public static GameController gC;
    public void ActivateCheckpoint(GameObject newCheckpoint)
    {

        if (enabledCheckpoint)
        {
            enabledCheckpoint.GetComponent<Checkpoint>().Deactivated();
        }
        enabledCheckpoint = newCheckpoint;
        enabledCheckpoint.GetComponent<Checkpoint>().Enabled();
    }

    public void RespawnPlayer(Player player)
    {
        player.transform.position = gC.enabledCheckpoint.transform.position;
    }
    void Awake()
    {
        if (GameController.gC == null) GameController.gC = this;
        else Destroy(this.gameObject);
    }
}
