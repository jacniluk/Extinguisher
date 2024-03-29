using UnityEngine;

public class ExtinguisherElement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected Collider interactionTrigger;
    [SerializeField] protected Animator animator;
    [SerializeField] protected ExtinguisherController extinguisherController;

    public Collider InteractionTrigger => interactionTrigger;
}
