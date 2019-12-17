using UnityEngine;


public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip bird1, bird2, bird3, coin, cashout, casino, arcade, sad, happy, slot, over, sad_song;
    private static AudioSource audioSource;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SoundManager");

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
        casino = Resources.Load<AudioClip>("Sounds/casino");
        arcade = Resources.Load<AudioClip>("Sounds/arcade");
        happy = Resources.Load<AudioClip>("Sounds/robot_happy");
        sad = Resources.Load<AudioClip>("Sounds/robot_sad");
        slot = Resources.Load<AudioClip>("Sounds/slotMachine");
        over = Resources.Load<AudioClip>("Sounds/GameOver");
        sad_song = Resources.Load<AudioClip>("Sounds/sadSong");

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
            case "casino":
                audioSource.PlayOneShot(casino);
                break;
            case "arcade":
                audioSource.PlayOneShot(arcade);
                break;
            case "sad":
                audioSource.PlayOneShot(sad);
                break;
            case "happy":
                audioSource.PlayOneShot(happy);
                break;
            case "slot":
                audioSource.PlayOneShot(slot);
                break;
            case "over":
                audioSource.PlayOneShot(over);
                audioSource.PlayOneShot(sad_song);
                break;
        }
    }

    public static void Stop()
    {
        audioSource.Stop();
    }
}
