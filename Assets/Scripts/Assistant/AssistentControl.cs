using UnityEngine;
using UnityEditor;

public class AssistentControl : MonoBehaviour
{

    public GameObject assistantDisplay;

    public float speed, direction;
    private bool opened, moving, monitor;

    private static float closedY = -11, openY = -4;

    private void Start()
    {
        DisplayMessage("");
    }

    private void FixedUpdate()
    {
        CheckMove();
        ListenCommands();

        if (monitor)
            MonitorPlayerMoney();
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
        DisplayMessageOnScreen("Regras do Jogo", AssistantMessages.RULES, 0);
    }
    private void ShowKeys()
    {
        DisplayMessageOnScreen("Teclas", AssistantMessages.KEYS, 0);
    }
    private void ActivateAssistant()
    {
        if (DisplayMessageOnScreen("Assistente", AssistantMessages.ASSISTANT, 1))
            monitor = true;
    }

    private void MonitorPlayerMoney()
    {

    }

    private void DisplayMessage(string msg)
    {
        assistantDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = msg;
    }

    private bool DisplayMessageOnScreen(string title, string msg, int mode)
    {
        bool check = false;
       // if (mode == 0)
       //     check = EditorUtility.DisplayDialog(title, msg, "OK");
       // else
       //     check = EditorUtility.DisplayDialog(title, msg, "Sim", "Não");

        direction = -1;
        moving = true;

        return check;
    }

    private void DisplayMenu()
    {
        DisplayMessage(AssistantMessages.MENU);
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
