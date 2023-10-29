using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem eS;
    // Start is called before the first frame update
    void Awake()
    {
        if (EventSystem.eS == null) EventSystem.eS = this;
        else Destroy(this.gameObject);
    }
}
