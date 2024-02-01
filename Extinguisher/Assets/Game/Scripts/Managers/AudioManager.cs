using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private AudioSource extinguishAudioSource;
	[SerializeField] private AudioSource fireAudioSource;
	[SerializeField] private AudioSource gameCompleteAudioSource;
	[SerializeField] private AudioSource gameOverAudioSource;
	[SerializeField] private AudioSource nozzleAudioSource;
	[SerializeField] private AudioSource pinAudioSource;

	public static AudioManager Instance;

	private void Awake()
	{
		Instance = this;
	}

    public void StartExtinguish()
    {
        extinguishAudioSource.Play();
    }

    public void StopExtinguish()
    {
        extinguishAudioSource.Stop();
    }

    public void StartFire()
    {
        fireAudioSource.Play();
    }

    public void SetVolumeFire(float volume)
    {
        fireAudioSource.volume = volume;
    }

    public void StopFire()
    {
        fireAudioSource.Stop();
    }

    public void PlayGameComplete()
    {
        gameCompleteAudioSource.Play();
    }

    public void PlayGameOver()
	{
		gameOverAudioSource.Play();
    }

    public void PlayNozzle()
    {
        nozzleAudioSource.Play();
    }

    public void PlayPin()
    {
        pinAudioSource.Play();
    }
}
