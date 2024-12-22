using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator; // Referência ao Animator
    float input_X = 0f; // Entrada no eixo X
    float input_Y = 0f; // Entrada no eixo Y
    public float speed = 2.5f; // Velocidade de movimento
    bool isMoving = false; // Estado de movimento

    void Start()
    {
        // Verifica se o Animator está atribuído
        if (animator == null)
        {
            Debug.LogError("Animator não atribuído no PlayerController.");
        }
    }

    void Update()
    {
        // Captura as entradas do teclado
        input_X = Input.GetAxisRaw("Horizontal");
        input_Y = Input.GetAxisRaw("Vertical");

        // Verifica se o personagem está se movendo
        isMoving = (input_X != 0 || input_Y != 0);

        if (isMoving)
        {
            // Calcula o vetor de movimento normalizado
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
