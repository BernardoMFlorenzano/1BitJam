using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class MiraTurret : MonoBehaviour
{
    [SerializeField] private TurretData turretData;
    private Transform player;
    private Animator animator;
    public GameObject prefabFlecha;

    private GameObject flechaAtirada;
    private Vector2 rotacaoMira;
    private bool recuperando = false;
    private bool podeAtirar = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();

        StartCoroutine(CooldownTiro());
        StartCoroutine(AtiraFlecha());
    }


    void FixedUpdate()
    {
        if (recuperando)
            return;

        rotacaoMira = player.position - transform.position;

        float rotZ = Mathf.Atan2(rotacaoMira.y, rotacaoMira.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    IEnumerator AtiraFlecha()
    {
        while (true)
        {
            if (podeAtirar)
            {
                podeAtirar = false;
                recuperando = true;
                yield return new WaitForSeconds(turretData.delayPreTiro);

                flechaAtirada = Instantiate(prefabFlecha, transform.position, transform.rotation);
                flechaAtirada.GetComponent<Rigidbody2D>().linearVelocity = rotacaoMira.normalized * turretData.flechaVel;

                animator.SetTrigger("Atira");

                StartCoroutine(CooldownTiro());
                yield return new WaitForSeconds(turretData.delayPosTiro);
                recuperando = false;
            }
            else
                yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CooldownTiro()
    {
        yield return new WaitForSeconds(turretData.cooldownTiro);
        podeAtirar = true;
    }
}
