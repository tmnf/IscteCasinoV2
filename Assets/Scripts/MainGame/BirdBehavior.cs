using UnityEngine;

public class BirdBehavior : MonoBehaviour
{

    private Rigidbody2D rb;

    public float flySpeed;

    private bool direction; // 1 - Right, 0 - Left

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = true;
    }

    private void FixedUpdate()
    {

        if ((transform.position.x > 14 && direction) || (transform.position.x < -14 && !direction))
            RotateBird();

        float altitude = 1 + Random.Range(0f, 1.5f);
        if (transform.position.y < altitude)
        {
            float verticalForce = 12f;
            rb.AddForce(new Vector2(0f, verticalForce));
        }

        float speedBoost = Random.Range(0.00f, 0.01f);
        transform.position += new Vector3(flySpeed + speedBoost, 0f, 0f);

        TryToSing();
    }

    private void TryToSing()
    {
        float aux = Random.Range(1, 1000);

        string clip = "bird" + Random.Range(1, 3);

        if (aux <= 1)
            SoundManagerScript.PlaySound(clip);
    }

    private void RotateBird()
    {
        flySpeed = -flySpeed;
        direction = !direction;
        transform.Rotate(new Vector3(0, 1, 0), 180);
    }
}
