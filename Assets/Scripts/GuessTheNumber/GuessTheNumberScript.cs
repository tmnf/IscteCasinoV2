using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumberScript : MonoBehaviour
{

    public GameObject prizeText, currNumber, moedas;
    public InputField input;
    public Dropdown bigger;

    private PlayerLogic logic;
    private int lastNum;

    private void Start()
    {
        logic = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();
        setCoins();
        lastNum = 5;
    }

    private void setCoins()
    {
        moedas.GetComponent<TMPro.TextMeshProUGUI>().text = "Moedas: " + logic.money;
    }

    public void GenerateNumber()
    {

        int generated_number = lastNum;

        Debug.Log(bigger.itemText.text);

        if (input.text == "")
        {
            if (logic.money >= 5)
                SpendMoney(5);
            else
            {
                prizeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Nao tem dinheiro suficiente para apostar...";
                return;
            }

            generated_number = Algorithms.UniformInteger(1, 10);

            currNumber.GetComponent<TMPro.TextMeshProUGUI>().text = "Numero Atual: " + generated_number;

            Debug.Log(bigger.itemText.text);

            if ((bigger.value == 0 && generated_number > lastNum) || (bigger.value == 1 && generated_number < lastNum) || (bigger.value == 2 && generated_number == lastNum))
            {
                EarnMoney(30);
            }
            else
                prizeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Nao Ganhou Nada...";

        }
        else
        {
            if (logic.money >= 10)
                SpendMoney(10);
            else
            {
                prizeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Nao tem dinheiro suficiente para apostar...";
                return;
            }

            generated_number = Algorithms.UniformInteger(1, 10);

            currNumber.GetComponent<TMPro.TextMeshProUGUI>().text = "Numero Atual: " + generated_number;

            if (int.Parse(input.text) == generated_number)
            {
                EarnMoney(100);
            }
            else prizeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Nao Ganhou Nada...";
        }

        lastNum = generated_number;
    }

    private void SpendMoney(int moedas)
    {
        logic.money -= moedas;
        SoundManagerScript.PlaySound("cashout");
        setCoins();
    }

    private void EarnMoney(int moedas)
    {
        logic.money += moedas;

        SoundManagerScript.PlaySound("coin");

        prizeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Parabens!!! Ganhou: " + moedas + " Moedas";
        setCoins();
    }
}
