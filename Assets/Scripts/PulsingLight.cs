using UnityEngine;

public class PulsingLight : MonoBehaviour
{
    public float minIntensity = 1.0f;
    public float maxIntensity = 2.0f;
    public float pulseSpeed = 1.0f;

    private Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
    }

    void Update()
    {
        float pulse = Mathf.PingPong(Time.time * pulseSpeed, maxIntensity - minIntensity) + minIntensity;
        pointLight.intensity = pulse;
    }
}
