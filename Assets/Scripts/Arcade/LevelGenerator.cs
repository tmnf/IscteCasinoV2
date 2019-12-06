using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platform;

    public GameObject coin;
    public Transform generationPoint;
    public float distanceBetweenPlat;
    private float platformWidth;

    private int totalCoinsCreated = 0;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.transform.position.x){
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetweenPlat, transform.position.y, transform.position.z);
            Instantiate(platform, new Vector3(transform.position.x,transform.position.y - 2 + Random.Range(0f, 1f),0), transform.rotation);
            int spawn = Random.Range(1,1000);
            if(spawn < 300){
                Instantiate(coin, new Vector3(transform.position.x, transform.position.y - 1, 0), transform.rotation);
                totalCoinsCreated+=1;
                Debug.Log(totalCoinsCreated); //só para debug
            }
        }   
    }
}
