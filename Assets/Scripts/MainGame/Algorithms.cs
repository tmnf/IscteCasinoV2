using UnityEngine;

public class Algorithms : MonoBehaviour
{
    public static int LOW = 0, NORMAL = 1, HIGH = 2;

    public static int JACKPOT = 0, TRY_AGAIN = 1, LOSE_MONEY = 2, WIN_COIN = 3, WIN_2_COIN = 4, WIN_3_COIN = 5;

    public static int UniformInteger(double xMin, double xMax)
    {
        xMax += 1;
        if (xMin < xMax)
            return (int)(xMin + (xMax - xMin) * Random.value);
        else
            return 0;
    }

    public static float Uniform(float xMin, float xMax)
    {
        if (xMin < xMax)
            return xMin + (xMax - xMin) * Random.value;
        else
            return 0;
    }

    public static float Normal(float mean, float variance)
    {

        float p, p1, p2;

        do
        {
            p1 = Uniform(-1, 1);
            p2 = Uniform(-1, 1);
            p = p1 * p1 + p2 * p2;
        } while (p >= 1);

        float res = mean + variance * p1 * Mathf.Sqrt(-2 * Mathf.Log(p) / p);

        while (res < 0 || res > 100)
            res = Normal(mean, variance);

        return res;

    }

    public static int AlturaGen()
    {
        int altura = NORMAL;
        double random = Random.value;

        if (random <= 0.25)
            altura = LOW;
        else if (random >= 0.75)
            altura = HIGH;

        return altura;
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
}
