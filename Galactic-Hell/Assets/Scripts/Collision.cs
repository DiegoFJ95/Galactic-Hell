using System.Collections;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public int maxHealth = 10;
    public string tag;

    public int currentHealth;

    public HealthBar healthBar;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag)){
            Destroy(other.gameObject);
            currentHealth -= 1;
            healthBar.setHealth(currentHealth);
        }
    }

    void Start(){
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void Update(){
        if(currentHealth < 1){
            Destroy(this.gameObject);
        }
    }
}
