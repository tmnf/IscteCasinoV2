using UnityEngine;

public class Algorithms : MonoBehaviour
{
    public static int UniformInteger(double xMin, double xMax)
    {
        xMax += 1;
        if (xMin < xMax)
            return (int)(xMin + (xMax - xMin) * Random.value);
        else
            return 0;
    }

    public static float Uniform(float xMin, float xMax)
    {
        if (xMin < xMax)
            return xMin + (xMax - xMin) * Random.value;
        else
            return 0;
    }

    public static float Normal(float mean, float variance)
    {

        float p, p1, p2;

        do
        {
            p1 = Uniform(-1, 1);
            p2 = Uniform(-1, 1);
            p = p1 * p1 + p2 * p2;
        } while (p >= 1);

        float res = mean + variance * p1 * Mathf.Sqrt(-2 * Mathf.Log(p) / p);

        while (res < 0 || res > 100)
            res = Normal(mean, variance);

        return res;

    }
}
