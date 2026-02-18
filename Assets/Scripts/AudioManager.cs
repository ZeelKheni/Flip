using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip flipSound;
    [SerializeField] private AudioClip matchSound;
    [SerializeField] private AudioClip mismatchSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip uiClickSound; // New!

    public void PlayFlipSound() => sfxSource.PlayOneShot(flipSound);
    public void PlayMatchSound() => sfxSource.PlayOneShot(matchSound);
    public void PlayMismatchSound() => sfxSource.PlayOneShot(mismatchSound);
    public void PlayGameOverSound() => sfxSource.PlayOneShot(gameOverSound);
    public void PlayUIClick() => sfxSource.PlayOneShot(uiClickSound); // New!
}