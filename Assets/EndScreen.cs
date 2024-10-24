using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    Animator _animator;

    [SerializeField] TextMeshProUGUI _endingText, _reasonText;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShowEndScreen(EndScreenText endText)
    {
        _endingText.text = endText.EndingText;
        _reasonText.text = endText.ReasonText;
        _animator.SetTrigger("End");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
