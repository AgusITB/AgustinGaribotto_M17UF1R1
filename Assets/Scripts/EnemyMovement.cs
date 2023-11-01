using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // La distancia que queremos que se mueva el enemigo
    [SerializeField] Vector2 movementVector = new(10f, 10f);
    [SerializeField] float period = 2f;
    public bool isStop = false;

    public float movementFactor; // 0 = no se ha movido 1 = ha llegado al final del trayecto
    public bool facingRight = true;
    Vector3 startingPos;
    void Start()
    {
        startingPos = transform.position;
    }


    void Update()
    {
    
        if (period <= Mathf.Epsilon || isStop) { return; }

        float cycles = Time.time / period; // grows from 0

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave; // from -1 to 1
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
        Flip();
    }

    //Flip sprite each time it arrives to the max and min values
    private void Flip()
    {
       
        if ((movementFactor > 0.98f && movementFactor < 1f) && facingRight || (movementFactor < -0.98f && movementFactor > -1f) && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }

    public void Stop()
    {
        isStop = true;
    }


}