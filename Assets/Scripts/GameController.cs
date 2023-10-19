using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

  class GameController : MonoBehaviour
{
    public GameObject enabledCheckpoint;


    public void ActivateCheckpoint(GameObject newCheckpoint)
    {

        if (enabledCheckpoint)
        {
            enabledCheckpoint.GetComponent<Checkpoint>().Deactivated();
        }
        enabledCheckpoint = newCheckpoint;
        enabledCheckpoint.GetComponent<Checkpoint>().Enabled();
    }
}
