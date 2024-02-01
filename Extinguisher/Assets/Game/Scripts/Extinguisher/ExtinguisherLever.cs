using UnityEngine;

public class ExtinguisherLever : ExtinguisherElement, IClickable
{
    [Header("References")]
    [SerializeField] private Animator animator;

    public void OnClickDown() // IClickable
    {
        animator.SetBool("On", true);

        extinguisherController.StartExtinguish();
    }

    public void OnClickUp() // IClickable
    {
        animator.SetBool("On", false);

        extinguisherController.StopExtinguish();
    }
}
