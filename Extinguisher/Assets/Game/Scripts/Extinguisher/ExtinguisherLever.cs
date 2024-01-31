using UnityEngine;

public class ExtinguisherLever : ExtinguisherElement, IClickable
{
    [Header("References")]
    [SerializeField] private Animator animator;

    public void OnClickDown() // IClickable
    {
        animator.SetTrigger("On");

        extinguisherController.StartExtinguish();
    }

    public void OnClickUp() // IClickable
    {
        animator.SetTrigger("Off");

        extinguisherController.StopExtinguish();
    }
}
