using System.Collections;
using UnityEngine;

public class ExtinguisherPin : ExtinguisherElement, IClickable
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AnimationClip actionAnimation;

    public void OnClickDown() // IClickable
    {
        StartCoroutine(ActionCoroutine());
    }

    private IEnumerator ActionCoroutine()
    {
        interactionTrigger.enabled = false;

        animator.SetBool("On", true);

        AudioManager.Instance.PlayPin();

        yield return new WaitForSeconds(actionAnimation.length);

        transform.SetParent(null);
        animator.enabled = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.down * 1000.0f);

        extinguisherController.Action();
    }

    public void OnClickUp() { } // IClickable
}
