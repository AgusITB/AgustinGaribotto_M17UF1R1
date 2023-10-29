using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;

    [SerializeField] private AudioSource shootingSoundEffect;

    private float timer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 20)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                shoot();
            }

        }


    }

    void shoot()
    {
        shootingSoundEffect.Play();
        //  Instantiate(bullet,bulletPos.position, Quaternion.identity);
        GameObject bullet = BulletPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = bulletPos.position;
            bullet.SetActive(true);
        }

    }
}
