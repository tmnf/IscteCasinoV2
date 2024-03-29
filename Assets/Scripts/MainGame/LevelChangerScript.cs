﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public static int MENU = 0, MAIN = 1, HOUSE = 2, CASINO = 3, ARCADE = 4, SLOT_MACHINE = 5, SPINING_WHEEL = 6, GUESS_NUMBER = 7, OVER = 8;

    public Animator animator;
    private GameObject player;
    private int levelToLoad;

    private PlayerLogic playerAtributes;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("LevelChanger");

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MainScene":
                MainController();
                break;
            case "CasinoScene":
                CasinoController();
                break;
            case "ArcadeScene":
                ArcadeController();
                break;
            case "HouseScene":
                HouseController();
                break;
            case "SlotMachine":
                SlotMachineController();
                break;
            case "SpinWheel":
                SlotMachineController();
                break;
            case "GuessTheNumber":
                SlotMachineController();
                break;
            default:
                break;
        }

    }

    private void SlotMachineController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FadeToLevel(CASINO);
    }

    private void MainController()
    {
        player = GameObject.Find("Player");
        int level = player.GetComponent<PlayerMovement>().getOnSceneEnter();

        if (Input.GetKeyDown("e") && level != MAIN)
            FadeToLevel(level);

        else if (Input.GetKeyDown(KeyCode.Escape))
            FadeToLevel(MENU);
    }
    private void CasinoController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FadeToLevel(MAIN);
    }
    private void ArcadeController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FadeToLevel(MAIN);

        player = GameObject.Find("Player");
        if (player.transform.position.y < -7)
            FadeToLevel(MAIN);

    }
    private void HouseController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FadeToLevel(MAIN);
    }

    // Casino Methods

    public void SlotMachineEnter()
    {
        FadeToLevel(SLOT_MACHINE);
    }
    public void SpinWheelEnter()
    {
        FadeToLevel(SPINING_WHEEL);
    }
    public void GuessTheNumberEnter()
    {
        FadeToLevel(GUESS_NUMBER);
    }

    public void FadeToLevel(int levelIndex)
    {
        playerAtributes = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();

        if (playerAtributes.CanEnter(levelIndex))
        {
            levelToLoad = levelIndex;
            animator.SetTrigger("FadeOut");
        }
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIn");
    }
}
