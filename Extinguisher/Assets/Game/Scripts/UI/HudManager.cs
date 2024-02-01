using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Text hintText;
    [SerializeField] private GameObject extinguisherHeightSlider;
    [SerializeField] private Image powderBarFill;
    [SerializeField] private Image fireBarFill;
    [SerializeField] private ExtinguisherController extinguisherController;
    [SerializeField] private FireController fireController;

    public static HudManager Instance;

	private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateBars();
    }

    private void UpdateBars()
    {
        powderBarFill.fillAmount = extinguisherController.GetCurrentDischargeTime01();
        fireBarFill.fillAmount = fireController.GetCurrentFirePower01();
    }

    public void SetHint(string hint)
    {
        hintText.text = hint;
    }

    public void ShowExtinguisherHeightSlider()
    {
        extinguisherHeightSlider.SetActive(true);
    }

    public void SetExtinguisherHeight01(float height01)
    {
        extinguisherController.SetHeight(height01);
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
