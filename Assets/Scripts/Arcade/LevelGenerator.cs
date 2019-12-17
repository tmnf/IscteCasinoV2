using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platform;

    public GameObject coin;
    public Transform generationPoint;

    public float distanceBetweenPlat;
    private float platformWidth;

    private float change;

    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        SoundManagerScript.PlaySound("arcade");
    }

    void Update()
    {
        if (transform.position.x < generationPoint.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetweenPlat, transform.position.y, transform.position.z);

            float platform_y = transform.position.y - 2 + Random.value;

            platform.transform.localScale += new Vector3(-change, 0, 0);
            change = Algorithms.Uniform(-1.5f, 0f);
            platform.transform.localScale += new Vector3(change, 0, 0);

            Instantiate(platform, new Vector3(transform.position.x, platform_y, 0), transform.rotation);

            int spawn = Algorithms.UniformInteger(1, 1000);
            if (spawn < 300)
            {
                Instantiate(coin, new Vector3(transform.position.x, platform_y + 0.5f, 0), transform.rotation);
            }
        }
    }
}
