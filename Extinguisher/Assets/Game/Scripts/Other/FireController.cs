using UnityEngine;

public class FireController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float increaseRatio;

    [Header("Data")]
    [SerializeField] private float firePower;

    [Header("References")]
    [SerializeField] private ParticleSystem fireEffect;

    private float startRateOverTime;
    private float currentFirePower;
    private bool isBeingExtinguished;

    private void Awake()
    {
        startRateOverTime = fireEffect.emission.rateOverTime.constant;
        currentFirePower = firePower;
    }

    private void Update()
    {
        UpdateFire();
    }

    private void UpdateFire()
    {
        if (isBeingExtinguished)
        {
            currentFirePower -= Time.deltaTime;
            if (currentFirePower < 0.0f)
            {
                Destroy(gameObject);
            }

            SetRateOverTime();
        }
        else if (currentFirePower < firePower)
        {
            currentFirePower += Time.deltaTime * increaseRatio;
            if (currentFirePower > firePower)
            {
                currentFirePower = firePower;
            }

            SetRateOverTime();
        }
    }

    private void SetRateOverTime()
    {
        ParticleSystem.EmissionModule emissionModule = fireEffect.emission;
        emissionModule.rateOverTime = Utilities.Evaluate(currentFirePower, 0.0f, firePower, 0.0f, startRateOverTime);
    }

    public void StartExtinguish()
    {
        isBeingExtinguished = true;
    }

    public void StopExtinguish()
    {
        isBeingExtinguished = false;
    }

    public float GetCurrentFirePower01()
    {
        return currentFirePower / firePower;
    }
}
