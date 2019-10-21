using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject cam;
    public float camSpeed;
    public float speedIncrement;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speedIncrement = Random.Range(0f, 0.0005f);
        camSpeed += speedIncrement;
        movement = new Vector3 (camSpeed,0,0);
        cam.transform.position += movement;

    }
}
