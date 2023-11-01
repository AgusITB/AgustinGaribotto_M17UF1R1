using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;

    [SerializeField] private AudioSource shootingSoundEffect;

    private float timer;
    private GameObject player;

 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 20)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                Shoot();
            }
        }


    }

    void Shoot()
    {
        shootingSoundEffect.Play();
        GameObject bullet = BulletPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = bulletPos.position;
            bullet.SetActive(true);
        }

    }
}
