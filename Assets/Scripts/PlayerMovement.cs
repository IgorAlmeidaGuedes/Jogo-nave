using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento
    private Vector2 screenBounds; // Limites da câmera
    
    void Start()
    {
        Camera cam = Camera.main;
        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;

        // Ajusta os limites com base no tamanho do collider
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        float objectWidth = collider.bounds.extents.x;
        float objectHeight = collider.bounds.extents.y;

        screenBounds = new Vector2(cameraWidth - objectWidth, cameraHeight - objectHeight);
    }

    void Update()
{
    // Recebe entrada do teclado
    float moveX = Input.GetAxis("Horizontal");
    float moveY = Input.GetAxis("Vertical");

    // Calcula o movimento com base na entrada
    Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

    // Aplica o movimento
    transform.Translate(movement);

    // Garante que a posição do jogador fique dentro dos limites da tela
    Vector3 clampedPosition = transform.position;
    clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenBounds.x, screenBounds.x);
    clampedPosition.y = Mathf.Clamp(clampedPosition.y, -screenBounds.y, screenBounds.y);

    // Atualiza a posição do jogador
    transform.position = clampedPosition;

    // Bloqueia a rotação
    transform.rotation = Quaternion.identity;
}

}

