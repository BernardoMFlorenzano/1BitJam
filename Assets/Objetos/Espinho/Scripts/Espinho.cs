using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Espinho : MonoBehaviour
{
    private bool ativo = false;

    void Start()
    {
        StartCoroutine(DelayInicio());    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColisorPlayer") && ativo)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator DelayInicio()
    {
        yield return new WaitForSeconds(0.5f);
        ativo = true;
    }
}
