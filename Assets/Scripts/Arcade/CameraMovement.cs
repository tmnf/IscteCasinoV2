using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject cam, player;
    public float camSpeed, speedIncrement, initial_x;
    private Vector3 movement;

    void Start()
    {
        player = GameObject.Find("Player");
        initial_x = player.transform.position.x;
        camSpeed += speedIncrement;
        movement = new Vector3(camSpeed, 0, 0);
    }

    void FixedUpdate()
    {
        float curr_x = player.transform.position.x;

        if (curr_x - initial_x >= 10 && camSpeed <= 0.063f)
        {
            camSpeed += speedIncrement;
            initial_x = curr_x;
            movement = new Vector3(camSpeed, 0, 0);
        }

        GameObject.Find("distText").GetComponent<TMPro.TextMeshProUGUI>().text = "Distancia Percorrida: " + Mathf.Round(curr_x) + "m";
        cam.transform.position += movement;
    }
}
