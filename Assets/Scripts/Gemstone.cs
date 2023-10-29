using UnityEngine;

public class Gemstone : MonoBehaviour
{
    public bool isDestroyed = false;

    public void Start()
    {
        if (isDestroyed) Destroy(gameObject);
    }
    public void CollectGemstone()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }

    public void SetDestroyedState(bool destroyed)
    {
        isDestroyed = destroyed;
    }
}
