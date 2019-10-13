using UnityEngine;


public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip bird1, bird2, bird3;
    private static AudioSource audioSource;

    void Start()
    {
        bird1 = Resources.Load<AudioClip>("Sounds/bird1");
        bird2 = Resources.Load<AudioClip>("Sounds/bird2");
        bird3 = Resources.Load<AudioClip>("Sounds/bird3");

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
        }
    }
}
