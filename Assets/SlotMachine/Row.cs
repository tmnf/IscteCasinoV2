using System.Collections;
using UnityEngine;

public class Row : MonoBehaviour
{

    private int randomValue;
    private float timeInterval;
    public bool rowStopped;
    public string stoppedSlot;

    private PlayerLogic playerLogic;

    void Start()
    {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating;
        playerLogic = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            Debug.Log(transform.position.y);
            if (transform.position.y <= -1.35f)
            {
                transform.position = new Vector2(transform.position.x, 3.75f);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            yield return new WaitForSeconds(timeInterval);

        }

        randomValue = Random.Range(60, 100);

        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -1.35)
            {
                transform.position = new Vector2(transform.position.x, 3.5f);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
            {
                timeInterval = 0.05f;
            }

            if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.1f;
            }

            if (i > Mathf.RoundToInt(randomValue * 0.75f))
            {
                timeInterval = 0.15f;
            }

            if (i > Mathf.RoundToInt(randomValue * 0.95f))
            {
                timeInterval = 0.2f;
            }

            yield return new WaitForSeconds(timeInterval);

        }

        string[] simbols = { "Diamond", "Crown", "Melon", "Bar", "Seven", "Cherry" };
        string[] simbols_luck = { "Diamond", "Crown", "Melon", "Melon", "Crown", "Diamond" };

        string[] listOfSimbols = simbols;
        // if (playerLogic.dayly_luck >= 80)
        //   listOfSimbols = simbols_luck;

        if (transform.position.y == -1.75f)
        {
            stoppedSlot = listOfSimbols[0];
        }
        else if (transform.position.y == -1f)
        {
            stoppedSlot = listOfSimbols[1];
        }
        else if (transform.position.y == -0.25f)
        {
            stoppedSlot = listOfSimbols[2];
        }
        else if (transform.position.y == 0.5)
        {
            stoppedSlot = listOfSimbols[3];
        }
        else if (transform.position.y == 1.25)
        {
            stoppedSlot = listOfSimbols[4];
        }
        else if (transform.position.y == 2)
        {
            stoppedSlot = listOfSimbols[5];
        }

        Debug.Log(stoppedSlot);

        rowStopped = true;
    }

    private void onDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }
}
