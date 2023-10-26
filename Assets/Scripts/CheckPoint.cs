using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Color color;

    public Color enabledColor;


    private SpriteRenderer spriteRenderer;

    [HideInInspector]
    public new bool enabled;


    // Start is called before the first frame update
    void Start()
    {

        enabled = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = enabledColor;


    }


}
