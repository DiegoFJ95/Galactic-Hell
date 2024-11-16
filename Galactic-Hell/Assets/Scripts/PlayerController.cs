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

        // Vector3 p = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
        // Debug.Log("Posición: " + p);
        // Debug.Log( mainCamera.GetComponent<Camera>().pixelRect );

        
        // else{
        //     Debug.Log("No camara");
        // }
        
        // var spriteSize = GetComponent<SpriteRenderer>().bounds.size.x * .5f;

        // var camHeight = mainCamera.orthographicSize;
        // var camWidth = mainCamera.orthographicSize * mainCamera.aspect;
        
        // yMin = -camHeight + spriteSize; // lower bound
        // yMax = camHeight - spriteSize; // upper bound
        Vector3 minLimit = mainCamera.ScreenToWorldPoint(new Vector3(0,0,0));
        Vector3 maxLimit = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth-1, mainCamera.pixelHeight-1,0));

        zMin = minLimit.z;
        zMax = maxLimit.z - 2.5f;

        xMin = minLimit.x + 0.4f;
        xMax = maxLimit.x - 0.4f;
        
        // xMin = -camWidth + spriteSize; // left bound
        // xMax = camWidth - spriteSize;
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



        // transform.position = new Vector3(xValidPosition, yValidPosition, 0f);


        // transform.Translate(Vector3.forward * Time.deltaTime * speed * fordwardInput, Space.World);
        // transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput, Space.World);

        // if (Input.GetKeyDown("d"))
        // {
        //     transform.rotation = rightRotation;
        // }
        // if (Input.GetKeyUp("d"))
        // {
        //     transform.rotation = defaultRotation;
        // }

        // if (Input.GetKeyDown("a"))
        // {
        //     transform.rotation = leftRotation;
        // }
        // if (Input.GetKeyUp("a"))
        // {
        //     transform.rotation = defaultRotation;
        // }


        

        // transform.position = new Vector3(xValidPosition, yValidPosition, 0f);
        // transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        
    }
}
