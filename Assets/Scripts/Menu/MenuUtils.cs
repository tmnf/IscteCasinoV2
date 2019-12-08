using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUtils : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene(LevelChangerScript.MAIN);
    }
    public void LoadGame()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }

}
