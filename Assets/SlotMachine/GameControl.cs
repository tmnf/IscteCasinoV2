using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public static event Action HandlePulled = delegate { };

    private Row rowScript1, rowScript2, rowScript3;
    public GameObject row1, row2, row3;

    public Transform handle;

    public GameObject money, prize;

    private PlayerLogic playerLogic;
    private void Start()
    {
        rowScript1 = row1.GetComponent<Row>();
        rowScript2 = row2.GetComponent<Row>();
        rowScript3 = row3.GetComponent<Row>();

        playerLogic = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();
        money.GetComponent<TMPro.TextMeshProUGUI>().text = "Moedas: " + playerLogic.money;
    }

    private void setCoins()
    {
        playerLogic.money--;
        SoundManagerScript.PlaySound("cashout");
        money.GetComponent<TMPro.TextMeshProUGUI>().text = "Moedas: "+ playerLogic.money;
    }

    private void OnMouseDown()
    {
        if (rowScript1.rowStopped || rowScript2.rowStopped || rowScript3.rowStopped)
        {
            setCoins();
            prize.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            StartCoroutine("PullHandle");
        }
    }

    private void FixedUpdate()
    {
        if (rowScript1.rowStopped && rowScript2.rowStopped && rowScript3.rowStopped && rowScript1.started)
            CheckResults();
    }

    private IEnumerator PullHandle()
    {
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }

        HandlePulled();

        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CheckResults()
    {
        if (rowScript1.stoppedSlot == rowScript2.stoppedSlot && rowScript2.stoppedSlot == rowScript3.stoppedSlot)
        {
            SoundManagerScript.PlaySound("coin");
            rowScript1.started = false;

            prize.GetComponent<TMPro.TextMeshProUGUI>().text = "Premio: 100 Moedas";
        }
    }
}
