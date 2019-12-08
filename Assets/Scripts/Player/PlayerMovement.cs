using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed, jumpingForce;
    private bool isJumping;
    private float move;

    private int sceneToEnter;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject textDisplay;

    public GameObject camObj;

    private Camera cam;
    float height;
    float width;

    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            jump();

        move = Input.GetAxisRaw("Horizontal") * movementSpeed;
        animator.SetFloat("movement", move / movementSpeed);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(move * Time.deltaTime, 0f, 0f);

        checkPosition();

    }


    private void jump()
    {
        if (!isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpingForce * rb.mass));
            isJumping = true;
        }
    }

    private void checkPosition()
    {
        if (transform.position.x > camObj.transform.position.x + (width / 2) || transform.position.x < camObj.transform.position.x - (width / 2))
            transform.position = new Vector3(-transform.position.x, transform.position.y + 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
            isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string place = "";
        if (collision.gameObject.CompareTag("House"))
        {
            place = "em Casa";
            sceneToEnter = LevelChangerScript.HOUSE;
        }
        if (collision.gameObject.CompareTag("Casino"))
        {
            place = "no Casino";
            sceneToEnter = LevelChangerScript.CASINO;
        }
        if (collision.gameObject.CompareTag("Arcade"))
        {
            place = "no Arcade";
            sceneToEnter = LevelChangerScript.ARCADE;
        }

        textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Pressione 'E' para entrar " + place;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        sceneToEnter = 0;
    }

    public int getOnSceneEnter()
    {
        return sceneToEnter;
    }
}
