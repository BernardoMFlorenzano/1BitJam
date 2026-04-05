using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    private PausaJogo pausaJogo;
    
    void Start()
    {
        pausaJogo = GameObject.FindGameObjectWithTag("JogoDaMemoria").GetComponent<PausaJogo>();
    }

    public void PauseRequest()
    {
        pausaJogo.PausaPlayer();
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
