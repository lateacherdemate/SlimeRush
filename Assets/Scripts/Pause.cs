using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    [SerializeField] private InputActionReference pauseAction;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void OnEnable()
    {
        pauseAction.action.Enable();
        pauseAction.action.performed += TogglePause;
    }

    void OnDisable()
    {
        pauseAction.action.performed -= TogglePause;
        pauseAction.action.Disable();
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;

    }

    private void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }
}
