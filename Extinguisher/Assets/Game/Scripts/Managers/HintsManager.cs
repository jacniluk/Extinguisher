using UnityEngine;

public class HintsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Hints hints;

	public static HintsManager Instance;

	private void Awake()
	{
		Instance = this;
	}

	public string GetHintExtinguisherState(ExtinguisherState extinguisherState)
	{
		if (extinguisherState == ExtinguisherState.Locked)
		{
			return hints.hintLocked;
		}
		else if (extinguisherState == ExtinguisherState.Unlocked)
        {
            return hints.hintUnlocked;
        }
		else
		{
            return hints.hintReady;
        }
    }

	public string GetHintSuccess()
	{
		return hints.hintSuccess;
	}

    public string GetHintNoPowder()
    {
        return hints.hintNoPowder;
    }
}
