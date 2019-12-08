using UnityEngine;
public class PlayerLogic : MonoBehaviour
{
    public int money;
    public float dayly_luck;

    public GameObject txt;

    void Start()
    {
        money = GetHeritage();
        dayly_luck = GetLuck();
    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainGameLogic");

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void FixedUpdate()
    {
        txt = GameObject.Find("ML");

        if (txt != null)
            txt.GetComponent<TMPro.TextMeshProUGUI>().text = "Money: " + money + "\nLuck: " + dayly_luck + "%";
    }

    private void SpendMoney(int moneySpent)
    {
        money -= moneySpent;
        if (money <= 0)
        {
            GameOver();
            return;
        }
    }

    private void EarMoney(int moneyEarned)
    {
        money += moneyEarned;
    }

    private void GameOver()
    {

    }

    private int GetHeritage()
    {
        return UniformInteger(5, 30);
    }

    private float GetLuck()
    {
        return Normal(50, 20);
    }

    //UTILS

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

}
