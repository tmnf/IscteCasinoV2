using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLogic : MonoBehaviour
{
    public int money, casino_entrance, arcade_price, curr_day;
    public float dayly_luck, day_light, lastTimeChecked;

    public Vector3 height, wheight;

    private bool first, gameOver;
    public bool raising;

    private GameObject moneyText, luckText, currDayText;

    void Start()
    {
        day_light = 255;
        lastTimeChecked = Time.realtimeSinceStartup;

        money = GetHeritage();
        dayly_luck = GetLuck();

        GameObject.Find("mainDisplayText").GetComponent<TMPro.TextMeshProUGUI>().text = "O seu tio faleceu e voce herdou " + money + " moedas...";

        casino_entrance = Algorithms.UniformInteger(money, money + 10);
        arcade_price = 1;
        curr_day = 1;
    }

    public void ChangeBody()
    {
        int bodyHeight = Algorithms.AlturaGen();
        int bodyWeight = Algorithms.AlturaGen();

        if (bodyHeight == Algorithms.HIGH)
            height = new Vector3(0, 2f, 0);
        else if (bodyHeight == Algorithms.LOW)
            height = new Vector3(0, -2f, 0);

        if (bodyWeight == Algorithms.HIGH)
            wheight = new Vector3(2f, 0, 0);
        else if (bodyWeight == Algorithms.LOW)
            wheight = new Vector3(-2f, 0);
    }


    public bool CanEnter(int scene)
    {
        if((SceneManager.GetActiveScene().name == "GuessTheNumber" || SceneManager.GetActiveScene().name == "SlotMachine" || SceneManager.GetActiveScene().name == "SpinWheel") && scene == LevelChangerScript.CASINO)
            return true;
        
        if (scene == LevelChangerScript.CASINO && money >= casino_entrance)
        {
            if (SceneManager.GetActiveScene().name != "GuessTheNumber" && SceneManager.GetActiveScene().name != "SlotMachine" && SceneManager.GetActiveScene().name != "SpinWheel")
            {
                money -= casino_entrance;
                SoundManagerScript.PlaySound("cashout");
            }
            return true;
        }

        if (scene == LevelChangerScript.ARCADE && money >= arcade_price)
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

        // CHEATS
        //if (Input.GetKeyDown("p"))
        //{
        //    money += 199;
        //    dayly_luck += 10;
        //}
        //if (Input.GetKeyDown("c"))
        //{
        //    money -= 20;
        //}


        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            SpriteRenderer sr = GameObject.Find("Background").GetComponent<SpriteRenderer>();
            SpriteRenderer sr2 = GameObject.Find("bg1").GetComponent<SpriteRenderer>();

            if (Time.realtimeSinceStartup - lastTimeChecked > 5f)
            {
                if (raising)
                    day_light += 10;
                else day_light -= 10;

                if (day_light == 255 && raising)
                    raising = false;
                else if (day_light <= 15 && !raising)
                {
                    raising = true;
                    money -= 2;
                    curr_day++;
                    dayly_luck = GetLuck();
                    SoundManagerScript.PlaySound("cashout");
                }


                float value = day_light / 255;
                float value2 = (day_light + 5) / 255;

                if (sr != null && sr2 != null)
                {
                    sr.color = new Color(value, value, value);
                    sr2.color = new Color(value2, value2, value2);
                }

                lastTimeChecked = Time.realtimeSinceStartup;
            }
        }

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

        if (money < 0 && !gameOver)
            GameOver();
    }

    private void GameOver()
    {
        SoundManagerScript.Stop();
        gameOver = true;
        GameObject.Find("LevelChanger").GetComponent<LevelChangerScript>().FadeToLevel(LevelChangerScript.OVER);
        SoundManagerScript.PlaySound("over");
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
