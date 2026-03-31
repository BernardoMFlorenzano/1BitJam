using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoPlayer : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private Rigidbody2D rb;
    private Vector2 direcao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //velMov = playerData.velMov;
    }


    public void OnMove(InputValue value)
    {
        direcao = value.Get<Vector2>();
        direcao = direcao.normalized;
    }


    void FixedUpdate()
    {
        rb.linearVelocity = direcao * playerData.velMov;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ChaoCartas"))
        {
            Debug.Log("Caiu");
            Destroy(this.gameObject);
        }
    }
}
