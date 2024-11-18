using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    private GameObject spawnedBullet;

    private void Fire()
    {
        if(bullet){
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space")){
                Fire();
            }

        // if(timer >= firingRate){
        //     Fire();
        //     timer = 0;
        // }
        
    }
}
