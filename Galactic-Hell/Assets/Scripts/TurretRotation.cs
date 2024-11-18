using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public GameObject FollowObject;
    public float rotationOffset = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // transform.LookAt(FollowObject.transform.position, Vector3.up);
        // Quaternion defaultRotation = transform.rotation;

        Vector3 direction = FollowObject.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        targetRotation *= Quaternion.Euler(0, rotationOffset, 0);
        transform.rotation = new Quaternion(0f, targetRotation.y, 0f, targetRotation.w);
        // transform.rotation = new Quaternion(0f,defaultRotation.y,0f,defaultRotation.w);

    }

}
