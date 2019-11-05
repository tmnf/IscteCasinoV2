using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public static int MAIN = 0, HOUSE = 1, CASINO = 2, ARCADE = 3;

    public Animator animator;
    private GameObject player;
    private int levelToLoad;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("LevelChanger");

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
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
            default:
                break;
        }
    }

    private void MainController()
    {
        player = GameObject.Find("Player");
        int level = player.GetComponent<PlayerMovement>().getOnSceneEnter();

        if (Input.GetKeyDown("e") && level != MAIN)
            FadeToLevel(level);

        else if (Input.GetKeyDown(KeyCode.Escape))
            FadeToLevel(MAIN);
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
    }
    private void HouseController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FadeToLevel(MAIN);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIn");
    }

}
