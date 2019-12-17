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
        DisplayMessageOnScreen(AssistantMessages.RULES);
    }
    private void ShowKeys()
    {
        DisplayMessageOnScreen(AssistantMessages.KEYS);
    }
    private void ActivateAssistant()
    {
        AssistantHelp ah = GameObject.Find("MainGameLogic").GetComponent<AssistantHelp>();

        if (!ah.activated)
        {
            DisplayMessageOnScreen("Assistente Monetario Ativado");
            ah.activated = true;
            SoundManagerScript.PlaySound("happy");
        }
        else
        {
            DisplayMessageOnScreen("Assistente Monetario Desactivado");
            ah.activated = false;
            SoundManagerScript.PlaySound("sad");
        }
    }

    private void DisplayMessage(string msg)
    {
        assistantDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = msg;
    }

    private void DisplayMessageOnScreen(string msg)
    {
        GameObject.Find("mainDisplayText").GetComponent<TMPro.TextMeshProUGUI>().text = msg;

        direction = -1;
        moving = true;
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
