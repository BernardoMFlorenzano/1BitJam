using UnityEngine;

public class PausaJogo : MonoBehaviour
{
    public bool pausado = false;
    public bool podeDespausar = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            }
            else if (pausado)
            {
                Time.timeScale = 1f;
            }
            pausado = !pausado;

        }
 
    }

    public void PausaLogica()
    {
        if (!pausado)
        {
            Time.timeScale = 0f;
        }
        else if (pausado)
        {
            Time.timeScale = 1f;
        }
        pausado = !pausado;
    }
}
