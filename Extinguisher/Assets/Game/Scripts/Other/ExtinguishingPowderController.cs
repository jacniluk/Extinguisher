using UnityEngine;

public class ExtinguishingPowderController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Collider collisionTrigger;
    [SerializeField] private ParticleSystem powderEffect;

    private FireController fireController;

    public void OnTriggerEnter(Collider other)
    {
        FireController newFireController = other.GetComponent<FireController>();
        if (newFireController != null)
        {
            fireController = newFireController;
            fireController.StartExtinguish();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FinishExtinguish();
    }

    public void UpdatePosition(Transform socket)
    {
        transform.position = socket.position;
        transform.eulerAngles = socket.eulerAngles;
    }

    public void StartExtinguish()
    {
        powderEffect.Play();
        collisionTrigger.enabled = true;
    }

    public void StopExtinguish()
    {
        powderEffect.Stop();
        collisionTrigger.enabled = false;

        FinishExtinguish();
    }

    private void FinishExtinguish()
    {
        if (fireController != null)
        {
            fireController.StopExtinguish();
        }
    }
}
