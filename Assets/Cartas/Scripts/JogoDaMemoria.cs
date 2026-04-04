using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogoDaMemoria : MonoBehaviour
{   // Script que vai tratar a lógica do jogo da memoria e redirecionar os efeitos
    [SerializeField] private JogoDaMemoriaData jogoDaMemoriaData;
    public List<GameObject> cartasSelecionadas = new List<GameObject>();

    public bool podeEscolher = true; // Para limitar quando o player pode escolher cartas (animacoes etc)
    public bool combina = true;
    private int cartaTipo;
    private int contCombinacoes = 0;

    public void Interacao(ClickCarta carta) // Quando Player escolher uma carta
    {
        if (cartasSelecionadas.Count < jogoDaMemoriaData.combinacoesCartas)
        {
            cartasSelecionadas.Add(carta.gameObject);
            Debug.Log(cartasSelecionadas.Count);
            if (cartasSelecionadas.Count == 1)
            {
                cartaTipo = carta.tipo;
            }
            else
            {
                if (cartaTipo != carta.tipo)
                {
                    combina = false;
                }
            }
        }

        if (cartasSelecionadas.Count == jogoDaMemoriaData.combinacoesCartas)
        {
            StartCoroutine(Resultado(1f));
        }
    }

    public void ResetaEscolhas()
    {
        cartasSelecionadas.Clear();
        combina = true;
    }

    IEnumerator Resultado(float tempoEspera)
    {
        podeEscolher = false;
        yield return new WaitForSeconds(tempoEspera);
        podeEscolher = true;
        if (combina)
        {
            Debug.Log("Acertou combinacao");
            contCombinacoes++;

            int cont = 0;
            foreach (GameObject c in cartasSelecionadas)
            {
                cont++;
                c.GetComponent<ClickCarta>().EfeitoCarta(cont);
            }
        }
        else
        {
            Debug.Log("Errou combinacao");
            foreach (GameObject c in cartasSelecionadas)
            {
                c.GetComponent<ClickCarta>().ResetaCarta();
            }
        }

        ResetaEscolhas();

        if (contCombinacoes >= jogoDaMemoriaData.quantidadeCombinacoesWin)
        {
            // Ganha partida
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
