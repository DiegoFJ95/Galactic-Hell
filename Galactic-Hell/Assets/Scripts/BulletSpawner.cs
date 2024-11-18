using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public enum SpawnerType { Straight, Spin, Sine, Hell }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    public SpawnerType spawnerType;
    public float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer, sineTimer = 0f;
    private float sine;

    private float sineAmplitude = 20f;
    private float sineFrequency = 0.5f;
    private float angleOffset;

    private int frame;

    public Vector3 defaultRotation;

    private bool checkRotation = true;

    private Quaternion rotation1, rotation2;
        


    private void Fire()
    {
        if(bullet){
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        	frame += 1;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultRotation = transform.rotation.eulerAngles;
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(spawnerType == SpawnerType.Straight){
            if(timer >= firingRate){
                Fire();
                timer = 0;
            }
        }

        if(spawnerType == SpawnerType.Spin){
            transform.eulerAngles = new Vector3(0f,transform.eulerAngles.y +1f, 0f);
            if(timer >= firingRate){
                Fire();
                timer = 0;
        }
        }

        if(spawnerType == SpawnerType.Sine){
            if(checkRotation){
                defaultRotation = transform.rotation.eulerAngles;
                checkRotation = false;
            }

            sine = Mathf.Sin(sineTimer);
            // Debug.Log("Sine: "+ sine+ "Timer: " + sineTimer);
            transform.eulerAngles = new Vector3(0f,transform.eulerAngles.y + sine*5, 0f);

            // Calcula el ángulo basado en la función seno
            angleOffset = Mathf.Sin(sineTimer * sineFrequency * Mathf.PI * 2) * sineAmplitude;

            // Calcula la dirección del disparo basado en el ángulo actual del Spawner y el offset
            
            transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y + angleOffset, defaultRotation.z);
            sineTimer += Time.deltaTime;

            if(timer >= firingRate){
                Fire();
                timer = 0;
        }

        }

        if(spawnerType == SpawnerType.Hell){
            if(timer >= firingRate){
                if(frame % 2 == 0){
                    Fire();
                    transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y+10f, defaultRotation.z);
                    Fire();
                    transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y+20f, defaultRotation.z);
                    Fire();
                    transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y+30f, defaultRotation.z);
                    Fire();
                    frame++;
                }

                else{
                    transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y+5f, defaultRotation.z);
                    Fire();
                    transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y+15f, defaultRotation.z);
                    Fire();
                    transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y+20f, defaultRotation.z);
                    Fire();
                    transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y+25f, defaultRotation.z);
                    Fire();
                    frame++;
                }
                transform.rotation = Quaternion.Euler(defaultRotation.x, defaultRotation.y, defaultRotation.z);
                timer = 0;
            }
        }


        
    }
}
