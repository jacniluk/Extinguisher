using UnityEngine;

public class HudManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ExtinguisherController extinguisherController;

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
