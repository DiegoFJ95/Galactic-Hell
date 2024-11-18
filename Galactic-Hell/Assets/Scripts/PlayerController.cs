using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public Camera mainCamera;



    public float speed = 5.0f;
    public float horizontalInput;
    public float fordwardInput;

    public float height;

    private float xMin, xMax;
    private float zMin, zMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Vector3 minLimit = mainCamera.ScreenToWorldPoint(new Vector3(0,0,0));
        Vector3 maxLimit = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth-1, mainCamera.pixelHeight-1,0));

        zMin = minLimit.z;
        zMax = maxLimit.z - 2.5f;

        xMin = minLimit.x + 0.4f;
        xMax = maxLimit.x - 0.4f;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fordwardInput = Input.GetAxis("Vertical");


        var direction = new Vector3(horizontalInput,0, fordwardInput).normalized;
        direction *= speed * Time.deltaTime;


        Quaternion defaultRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Quaternion leftRotation = Quaternion.Euler(0.0f, 0.0f, 30.0f);
        Quaternion rightRotation = Quaternion.Euler(0.0f, 0.0f, -30.0f);


        if(direction.x > 0){
            transform.rotation = rightRotation;
        }
        else if(direction.x < 0){
            transform.rotation = leftRotation;
        }
        else if(direction.x == 0){
            transform.rotation = defaultRotation;
        }

        var xValidPosition = Mathf.Clamp(transform.position.x + direction.x, xMin, xMax);
        var zValidPosition = Mathf.Clamp(transform.position.z + direction.z, zMin, zMax);
        transform.position = new Vector3(xValidPosition, height, zValidPosition);


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 3.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }

        
    }
}
