using UnityEngine;


public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip bird1, bird2, bird3, coin, cashout;
    private static AudioSource audioSource;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainGameLogic");

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        bird1 = Resources.Load<AudioClip>("Sounds/bird1");
        bird2 = Resources.Load<AudioClip>("Sounds/bird2");
        bird3 = Resources.Load<AudioClip>("Sounds/bird3");
        coin = Resources.Load<AudioClip>("Sounds/coin");
        cashout = Resources.Load<AudioClip>("Sounds/CashOut");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "bird1":
                audioSource.PlayOneShot(bird1);
                break;
            case "bird2":
                audioSource.PlayOneShot(bird2);
                break;
            case "bird3":
                audioSource.PlayOneShot(bird3);
                break;
            case "coin":
                audioSource.PlayOneShot(coin);
                break;
            case "cashout":
                audioSource.PlayOneShot(cashout);
                break;
        }
    }
}
