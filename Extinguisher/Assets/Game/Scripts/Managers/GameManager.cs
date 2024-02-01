using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool gameCompleted;

    public bool GameCompleted => gameCompleted;

	private void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 60;
    }

    public void GameComplete()
    {
        gameCompleted = true;

        HudManager.Instance.SetHint(HintsManager.Instance.GetHintGameComplete());

        AudioManager.Instance.StopFire();
        AudioManager.Instance.PlayGameComplete();
    }

    public void GameOver()
    {
        HudManager.Instance.SetHint(HintsManager.Instance.GetHintGameOver());

        AudioManager.Instance.PlayGameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
