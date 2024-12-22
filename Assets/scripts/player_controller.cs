using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator; // Referência ao componente Animator
    private float input_X = 0f; // Entrada do eixo horizontal
    private float input_Y = 0f; // Entrada do eixo vertical
    public float speed = 2.5f; // Velocidade de movimento do personagem
    private bool isMoving = false; // Indica se o personagem está se movendo

    void Start()
    {
        // Verifica se o Animator foi atribuído
        if (animator == null)
        {
            Debug.LogError("Animator não atribuído no PlayerController. Certifique-se de atribuí-lo no Inspetor.");
        }
    }

    void Update()
    {
        // Captura as entradas do teclado
        input_X = Input.GetAxisRaw("Horizontal"); // Eixo horizontal (A/D ou setas esquerda/direita)
        input_Y = Input.GetAxisRaw("Vertical");   // Eixo vertical (W/S ou setas cima/baixo)

        // Determina se o personagem está se movendo
        isMoving = (input_X != 0 || input_Y != 0);

        if (isMoving)
        {
            // Calcula a direção do movimento e normaliza o vetor
            Vector3 move = new Vector3(input_X, input_Y, 0).normalized;

            // Atualiza a posição do personagem
            transform.position += move * speed * Time.deltaTime;

            // Atualiza os parâmetros do Animator
            if (animator != null)
            {
                animator.SetFloat("input_X", input_X);
                animator.SetFloat("input_Y", input_Y);
            }
        }

        // Atualiza o estado de movimento no Animator
        if (animator != null)
        {
            animator.SetBool("isWalking", isMoving);
        }
    }
}
