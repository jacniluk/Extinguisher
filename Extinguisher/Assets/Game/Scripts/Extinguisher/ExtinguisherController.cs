using UnityEngine;

public class ExtinguisherController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int hosePoints;
    [SerializeField] private AnimationCurve hoseCurve;

    [Header("References")]
    [SerializeField] private LineRenderer hoseLineRenderer;
    [SerializeField] private ExtinguisherNozzle extinguisherNozzle;
    [SerializeField] private ExtinguisherLever extinguisherLever;
    [SerializeField] private Transform hoseStart;

    private ExtinguisherState currentState;

    public ExtinguisherState CurrentState => currentState;

    private void Awake()
    {
        hoseLineRenderer.positionCount = hosePoints;
        SetCurrentState(ExtinguisherState.Locked);
    }

    private void Update()
    {
        UpdateHose();
    }

    private void UpdateHose()
    {
        Vector3 startPoint = hoseStart.position;
        Vector3 endPoint = extinguisherNozzle.HoseEndPosition;
        Vector3 direction = endPoint - startPoint;
        Vector3 upCurve = Vector3.Cross(direction, Vector3.back).normalized * hoseCurve.Evaluate(Vector3.Distance(startPoint, endPoint));
        Vector3 middlePoint = startPoint + direction / 2.0f + upCurve;

        hoseLineRenderer.SetPosition(0, startPoint);
        for (int i = 1; i < hosePoints - 1; i++)
        {
            float t = (float)i / (hosePoints - 1);
            Vector3 tangent1 = Vector3.Lerp(startPoint, middlePoint, t);
            Vector3 tangent2 = Vector3.Lerp(middlePoint, endPoint, t);
            Vector3 position = Vector3.Lerp(tangent1, tangent2, t);

            hoseLineRenderer.SetPosition(i, position);
        }
        hoseLineRenderer.SetPosition(hosePoints - 1, endPoint);
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