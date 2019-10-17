using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{

    private int money;
    private float dayly_luck;

    public GameObject txt;

    void Start()
    {
        money = GetHeritage();
        dayly_luck = GetLuck();

        txt.GetComponent<TMPro.TextMeshProUGUI>().text = "Money: " + money + "\nLuck: " + dayly_luck + "%";
    }

    private int GetHeritage()
    {
        return Random.Range(5, 31);
    }

    private float GetLuck()
    {
        return Random.Range(0, 101);
    }

    void Update()
    {
        
    }
}
