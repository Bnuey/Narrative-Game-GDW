using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;

    [SerializeField] AudioSource soundFXObject;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume, float pitch)
    {
        AudioSource audiosource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audiosource.clip = audioClip;

        audiosource.volume = volume;

        audiosource.pitch = pitch;

        audiosource.Play();

        float clipLength = audiosource.clip.length;

        Destroy(audiosource.gameObject, clipLength);

    }

    public void PlayRandomSoundFXClip(AudioClips sounds, Transform spawnTransform, float volume, float pitch)
    {
        int rand = Random.Range(0, sounds.Clips.Count);

        AudioSource audiosource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audiosource.clip = sounds.Clips[rand];

        audiosource.volume = volume;

        audiosource.pitch = pitch;

        audiosource.Play();

        float clipLength = audiosource.clip.length;

        Destroy(audiosource.gameObject, clipLength);

    }

    public void PlayRandomSoundFXClipWithRandomPitch(AudioClips sounds, Transform spawnTransform, float volume, float minPitch, float maxPitch)
    {
        float randPitch = Random.Range(minPitch, maxPitch);
        int randClip = Random.Range(0, sounds.Clips.Count);

        AudioSource audiosource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audiosource.clip = sounds.Clips[randClip];

        audiosource.volume = volume;

        audiosource.pitch = randPitch;

        audiosource.Play();

        float clipLength = audiosource.clip.length;

        Destroy(audiosource.gameObject, clipLength);
    }
    public void PlayRandomPitchSoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume, float minPitch, float maxPitch)
    {
        float rand = Random.Range(minPitch, maxPitch);

        AudioSource audiosource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audiosource.clip = audioClip;

        audiosource.volume = volume;

        audiosource.pitch = rand;

        audiosource.Play();

        float clipLength = audiosource.clip.length;

        Destroy(audiosource.gameObject, clipLength);
    }
}
