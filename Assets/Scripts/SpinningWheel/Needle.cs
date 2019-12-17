using UnityEngine;

public class Needle : MonoBehaviour
{
    public string colide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colide = collision.gameObject.name;
    }
}