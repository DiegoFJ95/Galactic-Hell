using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{

    public int health = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EvilBullet")){
            Destroy(other.gameObject);
            health -= 1;
        }
    }

    void Update(){
        if(health < 1){
            Destroy(this.gameObject);
        }
    }
}
