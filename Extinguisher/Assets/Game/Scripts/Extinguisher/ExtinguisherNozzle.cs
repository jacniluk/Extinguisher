using System.Collections;
using UnityEngine;

public class ExtinguisherNozzle : ExtinguisherElement, IClickable
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip actionAnimation;
    [SerializeField] private Transform hoseEnd;
    [SerializeField] private Transform extinguishingPowderSocket;

    public Vector3 HoseEndPosition => hoseEnd.position;
    public Transform ExtinguishingPowderSocket => extinguishingPowderSocket;

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

        extinguisherController.Action();
    }

    public void OnClickUp() { } // IClickable
}
