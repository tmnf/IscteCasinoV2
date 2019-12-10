using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject cam;
    public float camSpeed;
    public float speedIncrement;
    private Vector3 movement;
    private float initial_x;
    void Start()
    {
        initial_x = GameObject.Find("Player").transform.position.x;
        camSpeed += speedIncrement;
        movement = new Vector3(camSpeed, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float curr_x = GameObject.Find("Player").transform.position.x;

        if (curr_x - initial_x >= 10 && camSpeed <= 0.06f)
        {
            camSpeed += speedIncrement;
            initial_x = curr_x;
            movement = new Vector3(camSpeed, 0, 0);
        }

        cam.transform.position += movement;
    }
}
