using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAnyways : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("NarrativeGame");
    }
}
