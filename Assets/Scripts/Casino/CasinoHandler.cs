using UnityEngine;

public class CasinoHandler : MonoBehaviour
{

    private LevelChangerScript levelChanger;
    private void Start()
    {
        levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChangerScript>();
    }


    public void EnterSlotMachine()
    {
        levelChanger.SlotMachineEnter();
    }

}
