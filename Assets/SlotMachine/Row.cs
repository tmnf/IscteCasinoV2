using System.Collections;
using UnityEngine;

public class Row : MonoBehaviour
{
    public bool rowStopped, started;
    public int stoppedSlot;

    private PlayerLogic playerLogic;

    public Sprite diamond, crown, melon, bar, seven, cherry;

    void Start()
    {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating;
        playerLogic = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();
    }

    private void StartRotating()
    {
        stoppedSlot = 0;
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        started = true;


        int i = 0;
        int max = Random.Range(10, 50);
        for (int x = 0; x != max; x++)
        {
            GetComponent<SpriteRenderer>().sprite = getSprite(i);
            stoppedSlot = i;
            i++;

            if (playerLogic.dayly_luck >= 80)
            {
                if (i == 3)
                    i = 0;
            }
            else
            {
                if (i == 6)
                    i = 0;
            }
            
            yield return new WaitForSeconds(0.1f);
        }

        rowStopped = true;
    }


    private Sprite getSprite(int i)
    {
        if (i == 0)
            return diamond;
        if (i == 1)
            return crown;
        if (i == 2)
            return melon;
        if (i == 3)
            return bar;
        if (i == 4)
            return seven;
        if (i == 5)
            return cherry;
        return diamond;
    }

    private void onDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }
}
