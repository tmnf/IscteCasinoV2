using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public static int HOUSE = 1, CASINO = 2, ARCADE = 3;

    public Animator animator;
    private GameObject player;
    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        int level = player.GetComponent<PlayerMovement>().getOnSceneEnter();

        if (Input.GetKeyDown("e") && level != 0)
            FadeToLevel(level);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
