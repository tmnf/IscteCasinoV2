using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
   
    public Animator animator;
    private GameObject player;
    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");

        if(Input.GetKeyDown("e")){
            if(player.transform.position.x >=-8 && player.transform.position.x <= -7){
                Debug.Log("Enter house");
                FadeToLevel(1);
            }
            if (player.transform.position.x >= 1.1  && player.transform.position.x <= 3)
            {
                Debug.Log("Enter Casino");
                FadeToLevel(2);
            }
            if (player.transform.position.x >= 6.1 && player.transform.position.x <= 7)
            {
                Debug.Log("Enter arcade");
                FadeToLevel(3);
            }
     }   
    }

    public void FadeToLevel(int levelIndex){
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete(){
        SceneManager.LoadScene(levelToLoad);
    }
}
