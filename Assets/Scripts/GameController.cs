using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    void Awake()
    {
        if (GameController.gC == null) GameController.gC = this;
        else Destroy(this.gameObject);
    }
}
