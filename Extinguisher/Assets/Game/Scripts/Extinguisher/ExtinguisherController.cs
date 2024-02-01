using System.Collections;
using UnityEngine;

public class ExtinguisherController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int hosePoints;
    [SerializeField] private AnimationCurve hoseCurve;
    [SerializeField] private float maxHeight;

    [Header("Data")]
    [SerializeField] private float dischargeTime;

    [Header("References")]
    [SerializeField] private LineRenderer hoseLineRenderer;
    [SerializeField] private ExtinguisherNozzle extinguisherNozzle;
    [SerializeField] private ExtinguisherLever extinguisherLever;
    [SerializeField] private Transform hoseStart;
    [SerializeField] private ExtinguishingPowderController extinguishingPowderController;

    private ExtinguisherState currentState;
    private IEnumerator extinguishCoroutine;
    private float currentDischargeTime;
    private float minHeight;

    public ExtinguisherState CurrentState => currentState;
    public float CurrentDischargeTime => currentDischargeTime;

    private void Awake()
    {
        hoseLineRenderer.positionCount = hosePoints;
        currentDischargeTime = dischargeTime;
        minHeight = transform.position.y;
    }

    private void Start()
    {
        SetCurrentState(ExtinguisherState.Locked);
    }

    private void Update()
    {
        UpdateHose();
        UpdateExtinguishingPowderPosition();
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

    private void UpdateExtinguishingPowderPosition()
    {
        extinguishingPowderController.UpdatePosition(extinguisherNozzle.ExtinguishingPowderSocket);
    }

    private void SetCurrentState(ExtinguisherState _currentState)
    {
        currentState = _currentState;

        HudManager.Instance.SetHint(HintsManager.Instance.GetHintExtinguisherState(currentState));
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

            HudManager.Instance.ShowExtinguisherHeightSlider();
        }
    }

    public void StartExtinguish()
    {
        if (currentDischargeTime > 0.0f)
        {
            extinguishCoroutine = ExtinguishCoroutine();
            StartCoroutine(extinguishCoroutine);
        }
    }

    private IEnumerator ExtinguishCoroutine()
    {
        extinguishingPowderController.StartExtinguish();

        AudioManager.Instance.StartExtinguish();

        float time = Time.timeSinceLevelLoad;
        while (currentDischargeTime > 0.0f)
        {
            yield return null;

            currentDischargeTime -= Time.timeSinceLevelLoad - time;
            time = Time.timeSinceLevelLoad;
            if (currentDischargeTime < 0.0f)
            {
                currentDischargeTime = 0.0f;
            }
        }

        if (GameManager.Instance.GameCompleted == false)
        {
            GameManager.Instance.GameOver();
        }

        FinishExtinguish();
    }

    public void StopExtinguish()
    {
        if (extinguishCoroutine != null)
        {
            StopCoroutine(extinguishCoroutine);

            FinishExtinguish();
        }
    }

    private void FinishExtinguish()
    {
        extinguishingPowderController.StopExtinguish();

        extinguishCoroutine = null;

        AudioManager.Instance.StopExtinguish();
    }

    public void SetHeight(float height01)
    {
        transform.position = new Vector3(transform.position.x, Utilities.Evaluate(height01, minHeight, maxHeight), transform.position.z);
    }

    public float GetCurrentDischargeTime01()
    {
        return currentDischargeTime / dischargeTime;
    }
}