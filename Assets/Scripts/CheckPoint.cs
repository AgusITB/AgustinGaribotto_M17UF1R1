using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Color enabledColor;
    private SpriteRenderer spriteRenderer;

    [HideInInspector]
    public new bool enabled;
    void Start()
    {
        enabled = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = enabledColor;
    }


}
