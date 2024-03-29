﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed, jumpingForce, move;
    private bool isJumping;

    private int sceneToEnter;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject textDisplay, camObj;

    private Camera cam;
    private float height, width;

    void Start()
    {
        cam = Camera.main;
        this.height = 2f * cam.orthographicSize;
        width = this.height * cam.aspect;

        if (GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>().height != null)
        {
            transform.localScale += GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>().height;
            transform.localScale += GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>().wheight;
        }
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
        int price = 0;
        if (collision.gameObject.CompareTag("House"))
        {
            place = "em Casa";
            sceneToEnter = LevelChangerScript.HOUSE;
        }
        if (collision.gameObject.CompareTag("Casino"))
        {
            place = "no Casino";
            price = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>().casino_entrance;
            sceneToEnter = LevelChangerScript.CASINO;
        }
        if (collision.gameObject.CompareTag("Arcade"))
        {
            place = "no Arcade";
            price = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>().arcade_price;
            sceneToEnter = LevelChangerScript.ARCADE;
        }

        if (price == 0)
            textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Pressione 'E' para entrar " + place;
        else
            textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Pressione 'E' para entrar " + place + ". Custo: " + price + " moedas";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        sceneToEnter = LevelChangerScript.MAIN;
    }

    public int getOnSceneEnter()
    {
        return sceneToEnter;
    }
}
