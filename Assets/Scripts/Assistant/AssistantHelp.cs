using UnityEngine;

public class AssistantHelp : MonoBehaviour
{
    private static int SEVER_MONEY_LOSS = 50;

    private PlayerLogic mainGameLogic;

    private int lastCheckedMoney;
    private float lastCheckedTime;

    public bool activated;
    void Start()
    {
        mainGameLogic = this.gameObject.GetComponent<PlayerLogic>();
        lastCheckedMoney = mainGameLogic.money;
        lastCheckedTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        if (activated)
        {
            if (mainGameLogic.money < 5)
            {
                SevereWarnPlayer();
            }
            else if (Time.realtimeSinceStartup - lastCheckedTime > 15)
            {
                DisplayMessage("");
                int moneyDiference = mainGameLogic.money - lastCheckedMoney;

                if (moneyDiference < 0 && ((moneyDiference) * -1) >= SEVER_MONEY_LOSS)
                    WarnPlayer();
                else if (moneyDiference > 0 && moneyDiference >= SEVER_MONEY_LOSS)
                    CongratPlayer();

                lastCheckedMoney = mainGameLogic.money;
                lastCheckedTime = Time.realtimeSinceStartup;
            }
        }

    }

    private void SevereWarnPlayer()
    {
        DisplayMessage("Cuidado!! Se as suas moedas chegarem a 0 voce perde o jogo..");
        SoundManagerScript.PlaySound("sad");
    }

    private void WarnPlayer()
    {
        DisplayMessage("Voce tem perdido imenso dinheiro... Talvez seja uma boa ideia ir dormir e tentar amanha");
        SoundManagerScript.PlaySound("sad");
    }

    private void CongratPlayer()
    {
        DisplayMessage("Parabens! Voce esta a fazer uma fortuna! Continue assim!");
        SoundManagerScript.PlaySound("happy");
    }

    private void DisplayMessage(string msg)
    {
        GameObject.Find("AssistantDisplay").GetComponent<TMPro.TextMeshProUGUI>().text = msg;
    }




}
