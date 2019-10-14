using UnityEngine;

public class AssistentControl : MonoBehaviour
{

    public GameObject assistantDisplay;

    public float speed, direction;
    private bool opened, moving;

    private static float closedY = -11, openY = -4;

    private void Start()
    {
        DisplayMessage("");
    }

    private void FixedUpdate()
    {
        CheckMove();
        ListenCommands();
    }

    private void ListenCommands()
    {
        if (Input.GetKeyDown("1"))
            ShowGameRules();
        if (Input.GetKeyDown("2"))
            ShowKeys();
        if (Input.GetKeyDown("3"))
            ActivateAssistant();
    }
    private void ShowGameRules()
    {

    }
    private void ShowKeys()
    {
        DisplayMessage("Teclas\n======\n\n a, d - Andar \n espaço - Saltar \n up - Abrir Assistente \n down - Fechar Assistente");
    }
    private void ActivateAssistant()
    {

    }

    private void DisplayMessage(string msg)
    {
        assistantDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = msg;
    }

    private void DisplayMenu()
    {
        DisplayMessage("Ambrósio Moedas \n 1 - Regras do jogo? \n 2 - Quais as Teclas? \n 3 - Ativar assistente monetário");
    }

    private void CheckMove()
    {
        if (!moving)
        {
            direction = Input.GetAxisRaw("Vertical");
            if (direction != 0)
                moving = true;
        }

        if (!opened && direction > 0)
            MovePhone(1);
        else if (opened && direction < 0)
            MovePhone(-1);

        if ((opened && direction > 0) || (!opened && direction < 0))
            moving = false;
    }

    private void MovePhone(int dir)
    {
        transform.position += new Vector3(0f, speed * Time.deltaTime * dir, 0f);
        assistantDisplay.transform.position += new Vector3(0f, speed * Time.deltaTime * dir, 0f);

        if (dir == 1 && transform.position.y >= openY)
        {
            opened = true;
            moving = false;
            DisplayMenu();
        }
        else if (dir == -1 && transform.position.y <= closedY)
        {
            opened = false;
            moving = false;
            DisplayMessage("");
        }

    }
}
