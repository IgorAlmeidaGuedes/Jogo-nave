using UnityEngine;

public class FireMovement : MonoBehaviour
{
    public float speed = 10f; // Velocidade do tiro
    private Renderer _renderer; // Referência ao Renderer

    void Start()
    {
        _renderer = GetComponent<Renderer>(); // Obter o componente Renderer
    }

    void Update()
    {
        // Movimento do tiro
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Movimento do tiro para a direita
            rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            // Alternativa usando Translate se Rigidbody2D não estiver presente
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        // Reseta a rotação do tiro para (0, 0, 0) a cada frame
        transform.rotation = Quaternion.identity;

        // Verifica se o tiro está fora da tela e desativa
        if (_renderer != null && !_renderer.isVisible)
        {
            gameObject.SetActive(false);
        }
    }
}
