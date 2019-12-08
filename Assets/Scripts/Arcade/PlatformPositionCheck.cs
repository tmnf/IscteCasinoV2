using UnityEngine;

public class PlatformPositionCheck : MonoBehaviour
{


    public GameObject camObj;

    private Camera cam;
    float height;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        camObj = GameObject.Find("Main Camera");

        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!checkPosition())
        {
            Destroy(this.gameObject);
        }

    }


    private bool checkPosition()
    {
        if (transform.position.x > camObj.transform.position.x - (width / 2))
        {
            return true;
        }
        else
            return false;

    }
}
