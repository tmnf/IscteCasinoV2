using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float reducer, multiplier;

    public Needle needle;

    public bool round1, isStoped, resultCheck;

    private int prizeInt;
    private string prizeText;

    public GameObject scoretext, moedas;
    private PlayerLogic playerLogic;

    private void Start()
    {
        playerLogic = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();

        reducer = 0;
        multiplier = 0;
        round1 = true;
        isStoped = true;

        moedas.GetComponent<TMPro.TextMeshProUGUI>().text = "Moedas: " + playerLogic.money;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            Reset();


        if (multiplier > 0)
            transform.Rotate(Vector3.forward, multiplier);

        if (multiplier < 20 && !round1)
            multiplier += 0.1f;
        else
            round1 = true;

        if (round1 && multiplier > 0)
        {
            multiplier -= reducer;

            if (multiplier < 6 && needle.colide == prizeText)
                multiplier = 0f;
        }

        if (multiplier <= 0)
            isStoped = true;

        if (isStoped && !resultCheck)
        {
            CheckResult();
            resultCheck = true;
        }
    }

    private void CheckResult()
    {
        scoretext.GetComponent<TMPro.TextMeshProUGUI>().text = "Premio: " + prizeText;

        string actualPrize = needle.colide;

        if (actualPrize == "Perdeu dinheiro...")
        {
            SoundManagerScript.PlaySound("cashout");
            playerLogic.money -= 10;
        }
        if (actualPrize == "Ganhou 1 Moeda!")
        {
            SoundManagerScript.PlaySound("coin");
            playerLogic.money += 1;
        }
        if (actualPrize == "Ganhou 2 Moedas!")
        {
            SoundManagerScript.PlaySound("coin");
            playerLogic.money += 2;
        }
        if (actualPrize == "Ganhou 3 Moedas!")
        {
            SoundManagerScript.PlaySound("coin");
            playerLogic.money += 3;
        }
        if (actualPrize == "Jackpot")
        {
            SoundManagerScript.PlaySound("coin");
            playerLogic.money += 100;
        }
        moedas.GetComponent<TMPro.TextMeshProUGUI>().text = "Moedas: " + playerLogic.money;
    }

    private string PrizeToString(int prize)
    {
        if (prize == Algorithms.JACKPOT)
            return "Jackpot";
        if (prize == Algorithms.TRY_AGAIN)
            return "Tenta Outra Vez";
        if (prize == Algorithms.LOSE_MONEY)
            return "Perdeu dinheiro..";
        if (prize == Algorithms.WIN_COIN)
            return "Ganhou 1 Moeda!";
        if (prize == Algorithms.WIN_2_COIN)
            return "Ganhou 2 Moedas!";
        if (prize == Algorithms.WIN_3_COIN)
            return "Ganhou 3 Moedas!";
        else return "";
    }

    void Reset()
    {
        if (isStoped)
        {
            prizeInt = Algorithms.Roleta(playerLogic.dayly_luck);
            prizeText = PrizeToString(prizeInt);

            multiplier = 1;
            reducer = Random.Range(0.05f, 0.1f);
            round1 = false;
            isStoped = false;

            resultCheck = false;
            playerLogic.money--;

            moedas.GetComponent<TMPro.TextMeshProUGUI>().text = "Moedas: " + playerLogic.money;

            SoundManagerScript.PlaySound("cashout");
            scoretext.GetComponent<TMPro.TextMeshProUGUI>().text = "Premio: ...";
        }
    }
}