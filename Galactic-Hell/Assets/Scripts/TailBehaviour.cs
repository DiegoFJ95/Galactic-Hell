using UnityEngine;
using UnityEngine.UI;

public class TailBehaviour : MonoBehaviour
{

    public HealthBar healthBar;
    public Collision CollisionScript;
    public BulletSpawner bulletSpawner1;
    public BulletSpawner bulletSpawner2;
    public BulletSpawner bulletSpawner3;
    public BulletSpawner bulletSpawner4;

    private bool enabled = false;
    private bool setup = true;
    private int maxHp, health, wings, modeChange;


    private Vector3 scaleChange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        maxHp = CollisionScript.maxHealth;
        modeChange = 0;
        
        CollisionScript.enabled = false;
        bulletSpawner1.enabled = false;
        bulletSpawner2.enabled = false;
        bulletSpawner3.enabled = false;
        bulletSpawner4.enabled = false;

        scaleChange = new Vector3(+0.05f, +0.05f, +0.05f);



    }

    // Update is called once per frame
    void Update()
    {

        
        
        if(!enabled){
            // (int)healthBar.slider.maxValue
            healthBar.setHealth(maxHp);
            wings = GameObject.FindGameObjectsWithTag("Wing").Length;
        }

        if(wings==0){
            enabled = true;
        }

        if(enabled){
            
            if(setup){
                transform.localScale += scaleChange;
                CollisionScript.enabled = true;
                CollisionScript.currentHealth = maxHp;

                bulletSpawner1.enabled = true;
                bulletSpawner2.enabled = true;
                bulletSpawner3.enabled = true;
                bulletSpawner4.enabled = true;
                setup = false;
            }

            health = CollisionScript.currentHealth;

            if(health==(maxHp*2/3) & modeChange == 0){
                transform.localScale += scaleChange;
                bulletSpawner1.spawnerType = BulletSpawner.SpawnerType.Sine;
                bulletSpawner1.transform.rotation =  Quaternion.Euler(0f, 120f, 0f);

                bulletSpawner2.spawnerType = BulletSpawner.SpawnerType.Sine;
                bulletSpawner2.transform.rotation =  Quaternion.Euler(0f, 160f, 0f);

                bulletSpawner3.spawnerType = BulletSpawner.SpawnerType.Sine;
                bulletSpawner3.transform.rotation =  Quaternion.Euler(0f, 200f, 0f);

                bulletSpawner4.spawnerType = BulletSpawner.SpawnerType.Sine;
                bulletSpawner4.transform.rotation =  Quaternion.Euler(0f, 240f, 0f);
                modeChange++;
            }

            if(health==(maxHp*1/3) & modeChange == 1){
                transform.localScale += scaleChange;
                bulletSpawner1.spawnerType = BulletSpawner.SpawnerType.Hell;
                bulletSpawner1.firingRate = 0.5f;
                bulletSpawner1.speed = 4f;

                bulletSpawner2.spawnerType = BulletSpawner.SpawnerType.Hell;
                bulletSpawner2.firingRate = 0.5f;
                bulletSpawner2.speed = 4f;
                
                bulletSpawner3.spawnerType = BulletSpawner.SpawnerType.Hell;
                bulletSpawner3.firingRate = 0.5f;
                bulletSpawner3.speed = 4f;
                
                bulletSpawner4.spawnerType = BulletSpawner.SpawnerType.Hell;
                bulletSpawner4.firingRate = 0.5f;
                bulletSpawner4.speed = 4f;
                
                modeChange++;
            }


        }
    }
}
