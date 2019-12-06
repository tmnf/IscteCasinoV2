using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public Text score;
    private int scoreValue = 0;


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Coin"){
            collision.gameObject.SetActive(false);
            scoreValue+=1;
            setScore();
        }
    }

    void setScore(){
        score.text = "Coins: " + scoreValue;
    }
}
