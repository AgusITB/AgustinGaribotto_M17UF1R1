using UnityEngine;

public class UI : MonoBehaviour
{  //Singleton
    public static UI ui;

    void Awake()
    {
        if (UI.ui == null) UI.ui = this;
        else Destroy(this.gameObject);
    }

}
