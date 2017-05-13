using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{

    public Light RedLight_Upper;
    public Light RedLight_Lower;
    public Light AmberLight_Upper;
    public Light AmberLight_Lower;
    public Light GreenLight_Upper;
    public Light GreenLight_Lower;

    public float timer_red;
    public float timer_green;

    void Start()
    {
        timer_red = 0;
        RedLight_Upper.enabled = true;
        RedLight_Lower.enabled = true;
        AmberLight_Upper.enabled = false;
        AmberLight_Lower.enabled = false;
        GreenLight_Upper.enabled = false;
        GreenLight_Lower.enabled = false;
    }

    void Update()
    {
            FlipFlop();
    }

    void FlipFlop()
    {
        timer_red += Time.deltaTime;
        if (timer_red <= timer_green)
        {
            RedLight_Upper.enabled = true;
            RedLight_Lower.enabled = true;
            AmberLight_Upper.enabled = false;
            AmberLight_Lower.enabled = false;
            GreenLight_Upper.enabled = false;
            GreenLight_Lower.enabled = false;
        }
        else
        {
            RedLight_Upper.enabled = false;
            RedLight_Lower.enabled = false;
            AmberLight_Upper.enabled = false;
            AmberLight_Lower.enabled = false;
            GreenLight_Upper.enabled = true;
            GreenLight_Lower.enabled = true;
            StartCoroutine("ResetCounter");
        }
    }
    IEnumerator ResetCounter()
    {
        yield return new WaitForSecondsRealtime(10);
        timer_red = 0;
        FlipFlop();
    }
}
