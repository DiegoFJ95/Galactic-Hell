using UnityEngine;

public class TailMovement : MonoBehaviour
{

    public Camera mainCamera;

    private float zMax;
    private Vector3 InitialPos;

    public float speed = 5.0f;
    public float displacement = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialPos = transform.position;
        Vector3 maxLimit = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth-1, mainCamera.pixelHeight-1,0));
        zMax = maxLimit.z - displacement;

        transform.position = new Vector3(InitialPos.x, InitialPos.y, zMax);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(InitialPos.x, InitialPos.y, zMax + Mathf.Sin(Time.time * speed) * 0.1f);
        
    }
}
