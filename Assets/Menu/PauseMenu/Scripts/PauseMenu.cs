using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
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

    public void ResetScene()
    {
        pausaJogo.ResetaCena();
    }

}
