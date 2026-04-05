using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using TMPro;
using UnityEngine.UI;

public class JogoDaMemoria : MonoBehaviour
{   // Script que vai tratar a lógica do jogo da memoria e redirecionar os efeitos
    [SerializeField] private JogoDaMemoriaData jogoDaMemoriaData;
    [SerializeField] private GameObject desenhoWin;
    private PausaJogo pausaJogo;
    private TMP_Text timerText;
    private Slider sliderTimer;
    private float timerAtual;
    public List<GameObject> cartasSelecionadas = new List<GameObject>();

    public bool podeEscolher = true; // Para limitar quando o player pode escolher cartas (animacoes etc)
    public bool combina = true;
    public bool acabouTempo = false;
    private int cartaTipo;
    private int contCombinacoes = 0;

    void Start()
    {
        pausaJogo = GetComponent<PausaJogo>();
        timerText = GameObject.FindGameObjectWithTag("Cronometro").GetComponentInChildren<TMP_Text>();
        sliderTimer = GameObject.FindGameObjectWithTag("Cronometro").GetComponentInChildren<Slider>();
        timerAtual = jogoDaMemoriaData.timerInicial;
        MudaTimerVal(jogoDaMemoriaData.timerInicial);
        EventosManager.ComecaJogo += ComecaTimer;
    }

    void OnDisable()
    {
        EventosManager.ComecaJogo -= ComecaTimer;
    }

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
            StartCoroutine(Resultado(jogoDaMemoriaData.tempoDelayResultado));
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

            SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.correctSound, transform);

            contCombinacoes++;
            timerAtual += jogoDaMemoriaData.timerTempoGanhoComb;
            MudaTimerVal(timerAtual);

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

            SoundManager.Instance.PlaySoundFXClip(SoundManager.Instance.SoundList.failSound, transform);

            foreach (GameObject c in cartasSelecionadas)
            {
                c.GetComponent<ClickCarta>().ResetaCarta();
            }
        }

        ResetaEscolhas();

        if (contCombinacoes >= jogoDaMemoriaData.quantidadeCombinacoesWin)
        {
            // Ganha partida
            StartCoroutine(AnimWin());
        }
    }

    IEnumerator AnimWin()
    {
        GameObject dogWin = Instantiate(desenhoWin, new Vector3(0f,-10f,0f), quaternion.identity);

        pausaJogo.PausaLogica();

        yield return new WaitUntil(() => dogWin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Vazio"));

        pausaJogo.AnimCamera();

        yield return new WaitForSecondsRealtime(0.5f);
        
        yield return new WaitUntil(() => pausaJogo.animatorCamera.GetCurrentAnimatorStateInfo(0).IsName("Default"));

        pausaJogo.PassaCena();
    }

    void ComecaTimer()
    {
        StartCoroutine(Timer(jogoDaMemoriaData.timerInicial));
    }

    IEnumerator Timer(float timerInicial)
    {
        timerAtual = timerInicial;

        while (!acabouTempo)
        {
            yield return new WaitForSeconds(1f);
            timerAtual--;
            MudaTimerVal(timerAtual);

            if (timerAtual <= 0)
            {
                acabouTempo = true;
                EventosManager.TriggerDanoPlayer();
            }

        }
        yield return null;
    }

    void MudaTimerVal(float valor)
    {
        /*
        //valor += 1;
        float minutos = Mathf.FloorToInt(valor / 60); 
        float segundos = Mathf.FloorToInt(valor % 60);

        // Formata para 0:00
        timerText.text = string.Format("{0:0}:{1:00}", minutos, segundos);
        */

        sliderTimer.value = valor/jogoDaMemoriaData.tempoMax;
    }

}
