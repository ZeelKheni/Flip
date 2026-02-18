using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip flipSound;
    [SerializeField] private AudioClip matchSound;
    [SerializeField] private AudioClip mismatchSound;
    [SerializeField] private AudioClip gameOverSound;

    public void PlayFlipSound() => sfxSource.PlayOneShot(flipSound);
    public void PlayMatchSound() => sfxSource.PlayOneShot(matchSound);
    public void PlayMismatchSound() => sfxSource.PlayOneShot(mismatchSound);
    public void PlayGameOverSound() => sfxSource.PlayOneShot(gameOverSound);
}