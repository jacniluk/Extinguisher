using UnityEngine;

public class ExtinguisherElement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Collider interactionCollider;
    [SerializeField] protected ExtinguisherController extinguisherController;

    public Collider InteractionCollider => interactionCollider;
}
