using UnityEngine;

public class ExtinguishingPowderController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem powderEffect;

    public void UpdatePosition(Transform socket)
    {
        transform.position = socket.position;
        transform.eulerAngles = socket.eulerAngles;
    }

    public void StartExtinguish()
    {
        powderEffect.Play();
    }

    public void StopExtinguish()
    {
        powderEffect.Stop();
    }
}
