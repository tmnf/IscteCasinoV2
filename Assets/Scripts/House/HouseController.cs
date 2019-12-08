using UnityEngine;

public class HouseController : MonoBehaviour
{
    private GameObject bt1, bt2, bt3, bt4;
    void Start()
    {
        bt1 = GameObject.Find("bt1");
        bt2 = GameObject.Find("bt2");
        bt3 = GameObject.Find("bt3");
        bt4 = GameObject.Find("bt4");
    }

}
