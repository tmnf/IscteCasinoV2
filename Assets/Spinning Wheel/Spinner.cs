using UnityEngine;

public class Spinner : MonoBehaviour
{
    public static int JACKPOT = 0, TRY_AGAIN = 1, LOSE_MONEY = 2, WIN_COIN = 3, WIN_2_COIN = 4, WIN_3_COIN = 5;

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
        {
            Reset();
        }

        if (multiplier > 0)
        {
            transform.Rotate(Vector3.forward, multiplier);
        }

        if (multiplier < 20 && !round1)
        {
            multiplier += 0.1f;
        }
        else
        {
            round1 = true;
        }

        if (round1 && multiplier > 0)
        {
            multiplier -= reducer;

            if(multiplier < 6 && needle.colide == prizeText)
            {
                multiplier = 0f;
            }
        }

        if(multiplier <= 0)
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

    public static int Roleta(double sorte)
    {
        double randomAtribute = Random.value;
        int prize = -1;

        float jackProb, loseMoneyProb;
        jackProb = 0.05f;
        loseMoneyProb = 0.493f;

        if (sorte <= 20)
        {
            jackProb -= 0.04f;
            loseMoneyProb += 0.04f;
        }
        else if (sorte >= 80)
        {
            jackProb += 0.05f;
            loseMoneyProb -= 0.05f;
        }

        if (randomAtribute <= jackProb)
            prize = JACKPOT;
        else if (randomAtribute <= 0.43)
            prize = TRY_AGAIN;
        else if (randomAtribute <= loseMoneyProb)
            prize = LOSE_MONEY;
        else if (randomAtribute <= 0.556)
            prize = WIN_COIN;
        else if (randomAtribute <= 0.936)
            prize = WIN_2_COIN;
        else if (randomAtribute <= 1)
            prize = WIN_3_COIN;

        return prize;
    }

    private string PrizeToString(int prize)
    {
        if (prize == JACKPOT)
            return "Jackpot";
        if (prize == TRY_AGAIN)
            return "Tenta Outra Vez";
        if (prize == LOSE_MONEY)
            return "Perdeu dinheiro..";
        if (prize == WIN_COIN)
            return "Ganhou 1 Moeda!";
        if (prize == WIN_2_COIN)
            return "Ganhou 2 Moedas!";
        if (prize == WIN_3_COIN)
            return "Ganhou 3 Moedas!";
        else return "";
    }

    void Reset()
    {
        if (isStoped)
        {
            prizeInt = Roleta(playerLogic.dayly_luck);
            prizeText = PrizeToString(prizeInt);
            Debug.Log(prizeText);
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