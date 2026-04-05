using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaJogo : MonoBehaviour
{
    public bool pausado = false;
    public bool podeDespausar = true;
    public Animator animatorCamera;
    [SerializeField] private GameObject menuPausa;
    

    void Awake()
    {
        Time.timeScale = 1f;
        pausado = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorCamera = GameObject.FindGameObjectWithTag("CineMachine").GetComponent<Animator>();
        //menuPausa = GameObject.FindGameObjectWithTag("MenuPause");
        if (menuPausa != null)
            menuPausa.SetActive(false);
        //animatorCamera.transform.position = new Vector2(-18f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PausaPlayer()
    {
        if (podeDespausar)
        {
            if (!pausado)
            {
                Time.timeScale = 0f;
                Debug.Log(menuPausa);
                if (menuPausa != null)
                    menuPausa.SetActive(true);
            }
            else if (pausado)
            {
                Time.timeScale = 1f;
                if (menuPausa != null)
                    menuPausa.SetActive(false);
            }
            pausado = !pausado;

        }
 
    }

    public void PausaLogica()
    {
        if (!pausado)
        {
            Time.timeScale = 0f;
            podeDespausar = false;
        }
        else if (pausado)
        {
            Time.timeScale = 1f;
            podeDespausar = true;
        }
        pausado = !pausado;
    }

    public void PassaCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetaCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AnimCamera()
    {
        animatorCamera.SetTrigger("ganha");
    }
}
