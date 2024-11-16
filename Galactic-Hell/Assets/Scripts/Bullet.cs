using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 1f;
    public float speed = 1f;

    private Vector3 spawnPoint;
    private float timer = 0f;

    private Vector3 Movement(float timer){
        float x = timer*speed*transform.forward.x;
        float z = timer*speed*transform.forward.z;
        return new Vector3(x+spawnPoint.x, spawnPoint.y, z+spawnPoint.z);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        // transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position= Movement(timer);
        
    }
}
