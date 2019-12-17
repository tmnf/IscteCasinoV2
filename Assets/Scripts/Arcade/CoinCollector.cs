using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public GameObject score;
    private int scoreValue;

    private PlayerLogic playerAtributes;

    private void Start()
    {
        scoreValue = 0;
        playerAtributes = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            setScore();
            Destroy(collision.gameObject);
        }
    }

    void setScore()
    {
        scoreValue += 1;
        playerAtributes.money++;
        SoundManagerScript.PlaySound("coin");
        score.GetComponent<TMPro.TextMeshProUGUI>().text = "Moedas Apanhadas: " + scoreValue;
    }
}
