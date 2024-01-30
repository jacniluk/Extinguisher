using System.Collections;
using UnityEngine;

public class ExtinguisherPin : ExtinguisherElement, IClickable
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip actionAnimation;

    public void OnClickDown() // IClickable
    {
        StartCoroutine(ActionCoroutine());
    }

    private IEnumerator ActionCoroutine()
    {
        interactionTrigger.enabled = false;

        animator.SetTrigger("Action");

        yield return new WaitForSeconds(actionAnimation.length);

        animator.enabled = false;
        rb.useGravity = true;

        extinguisherController.Action();
    }

    public void OnClickUp() { } // IClickable
}
