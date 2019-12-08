using UnityEngine;

public class AssistantHelp : MonoBehaviour
{
    private static int SEVER_MONEY_LOSS = 10;

    private PlayerLogic mainGameLogic;

    private int lastCheckedMoney;

    void Start()
    {
        mainGameLogic = this.gameObject.GetComponent<PlayerLogic>();
        lastCheckedMoney = mainGameLogic.money;
    }

    void Update()
    {
        int moneyDiference = mainGameLogic.money - lastCheckedMoney;

        if (mainGameLogic.money < 5)
        {
            SevereWarnPlayer();
        }
        else
        {
            if (moneyDiference < 0 && ((moneyDiference) * -1) >= SEVER_MONEY_LOSS)
                WarnPlayer();
            else if (moneyDiference > 0 && moneyDiference >= SEVER_MONEY_LOSS)
                CongratPlayer();
        }

        lastCheckedMoney = mainGameLogic.money;
    }

    private void SevereWarnPlayer()
    {

    }

    private void WarnPlayer()
    {

    }

    private void CongratPlayer()
    {

    }




}
