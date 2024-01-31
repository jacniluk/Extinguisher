using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image powderBarFill;
    [SerializeField] private Image fireBarFill;
    [SerializeField] private ExtinguisherController extinguisherController;
    [SerializeField] private FireController fireController;

    private void Update()
    {
        UpdateBars();
    }

    private void UpdateBars()
    {
        powderBarFill.fillAmount = extinguisherController.GetCurrentDischargeTime01();
        fireBarFill.fillAmount = fireController.GetCurrentFirePower01();
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }

    public void SetExtinguisherHeight01(float height01)
    {
        extinguisherController.SetHeight(height01);
    }
}
