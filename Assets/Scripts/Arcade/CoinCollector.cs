using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public Text score;
    private int scoreValue = 0;

    private PlayerLogic playerAtributes;

    private void Start()
    {
        playerAtributes = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            scoreValue += 1;
            setScore();
        }


        // Podes remover dinheiro do player assim playerAtributes.money--;
        // Podes adicionar dinheiro do player assim playerAtributes.money++;
    }

    void setScore()
    {
        score.text = "Coins: " + scoreValue;
    }
}
