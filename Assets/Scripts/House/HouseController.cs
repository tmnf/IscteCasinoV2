using UnityEngine;

public class HouseController : MonoBehaviour
{
    private LevelChangerScript levelChanger;
    private PlayerLogic playerLogic;
    private void Start()
    {
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChangerScript>();
        playerLogic = GameObject.Find("MainGameLogic").GetComponent<PlayerLogic>();
    }

    public void Sleep()
    {
        playerLogic.dayly_luck = playerLogic.GetLuck();
        playerLogic.curr_day++;
        playerLogic.money -= 2;

        SoundManagerScript.PlaySound("cashout");

        levelChanger.FadeToLevel(LevelChangerScript.MAIN);
    }

}
