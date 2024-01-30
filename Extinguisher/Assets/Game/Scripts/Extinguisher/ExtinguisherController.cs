using UnityEngine;

public class ExtinguisherController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LineRenderer hoseLineRenderer;
    [SerializeField] private ExtinguisherNozzle extinguisherNozzle;
    [SerializeField] private ExtinguisherLever extinguisherLever;

    private ExtinguisherState currentState;

    public ExtinguisherState CurrentState => currentState;

    private void Awake()
    {
        SetCurrentState(ExtinguisherState.Locked);
    }

    private void Update()
    {
        UpdateHose();
    }

    private void UpdateHose()
    {
        hoseLineRenderer.SetPosition(1, extinguisherNozzle.HoseEndPosition);
    }

    private void SetCurrentState(ExtinguisherState _currentState)
    {
        currentState = _currentState;

        // 2do tip
    }

    public void Action()
    {
        if (currentState == ExtinguisherState.Locked)
        {
            SetCurrentState(ExtinguisherState.Unlocked);

            extinguisherNozzle.InteractionTrigger.enabled = true;
        }
        else if (currentState == ExtinguisherState.Unlocked)
        {
            SetCurrentState(ExtinguisherState.Ready);

            extinguisherLever.InteractionTrigger.enabled = true;
        }
    }
}