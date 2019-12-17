using UnityEngine;

public class CasinoHandler : MonoBehaviour
{
    private LevelChangerScript levelChanger;

    private void Start()
    {
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChangerScript>();
        SoundManagerScript.PlaySound("casino");
    }


    public void EnterSlotMachine()
    {
        levelChanger.SlotMachineEnter();
    }

    public void EnterSpinWheel()
    {
        levelChanger.SpinWheelEnter();
    }

    public void EnterGuessTheNumber()
    {
        levelChanger.GuessTheNumberEnter();
    }

}
