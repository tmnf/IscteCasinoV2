using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLogic : MonoBehaviour
{
    public static int LOW = 0, NORMAL = 1, HIGH = 2;

    public int money, casino_entrance, arcade_price, curr_day;
    public float dayly_luck;

    public Vector3 height, wheight;

    private bool first;

    public GameObject moneyText, luckText, currDayText;

    void Start()
    {
        money = GetHeritage();
        dayly_luck = GetLuck();

        casino_entrance = Algorithms.UniformInteger(money, money + 10);
        arcade_price = 1;
        curr_day = 1;
    }

    public void ChangeBody()
    {
        int bodyHeight = AlturaGen();
        int bodyWeight = AlturaGen();

        if (bodyHeight == HIGH)
            height = new Vector3(0, 2f, 0);
        else if (bodyHeight == LOW)
            height = new Vector3(0, -2f, 0);

        if (bodyWeight == HIGH)
            wheight = new Vector3(2f, 0, 0);
        else if (bodyWeight == LOW)
            wheight = new Vector3(-2f, 0);
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

    public bool CanEnter(int scene)
    {
        if (scene == LevelChangerScript.CASINO && money > casino_entrance)
        {
            if (SceneManager.GetActiveScene().name != "GuessTheNumber" && SceneManager.GetActiveScene().name != "SlotMachine" && SceneManager.GetActiveScene().name != "SpinWheel")
            {
                money -= casino_entrance;
                SoundManagerScript.PlaySound("cashout");
            }
            return true;
        }


        if (scene == LevelChangerScript.ARCADE && money > arcade_price)
        {
            money -= arcade_price;
            SoundManagerScript.PlaySound("cashout");
            return true;
        }

        if (scene != LevelChangerScript.ARCADE && scene != LevelChangerScript.CASINO)
        {
            if (scene == LevelChangerScript.MAIN)
                SoundManagerScript.Stop();
            return true;
        }

        return false;
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
        moneyText = GameObject.Find("Money");
        luckText = GameObject.Find("Luck");
        currDayText = GameObject.Find("Day");

        // CHEAT APAGARRRR
        if (Input.GetKeyDown("p"))
            money += 199;

        if (moneyText != null && luckText != null)
        {
            moneyText.GetComponent<TMPro.TextMeshProUGUI>().text = money + "";
            luckText.GetComponent<TMPro.TextMeshProUGUI>().text = Mathf.Round(dayly_luck) + "%";
            currDayText.GetComponent<TMPro.TextMeshProUGUI>().text = curr_day + "";
        }

        if (!first)
        {
            ChangeBody();
            GameObject.Find("Player").transform.localScale += height;
            GameObject.Find("Player").transform.localScale += wheight;
            first = true;
        }

        if (money <= 0)
            GameOver();
    }

    private void GameOver()
    {

    }

    private int GetHeritage()
    {
        return Algorithms.UniformInteger(5, 30);
    }

    public float GetLuck()
    {
        return Algorithms.Normal(50, 20);
    }

}
