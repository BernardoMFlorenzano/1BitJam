
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool paused = false;

    [SerializeField] GameObject pausePanel;
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PauseRequest();
        }
    }

    public void PauseRequest()
    {
        if (paused)
        {

            paused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else if(!paused){
            paused = true;
            Time.timeScale = 0;

            pausePanel.SetActive(true);
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
