using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject prefab;           // Referência ao prefab do tiro
    public Transform firePoint;         // Ponto de onde o tiro sai
    public float fireRate = 0.5f;       // Tempo entre disparos
    private float nextFireTime = 0f;    // Tempo até o próximo disparo
    private ObjectPool objectPool;      // Referência ao ObjectPool

    void Start()
    {
        // Instancia o ObjectPool com o prefab e tamanho da pool (50 tiros)
        objectPool = new ObjectPool(prefab, 15);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            Fire(); 
            nextFireTime = Time.time + fireRate;
        }
    }
    void Fire()
    {
        // Pega o próximo tiro da pool
        GameObject projectile = objectPool.GetFromPool();

        if (projectile != null)
        {
            // Posiciona o tiro no ponto de disparo
            projectile.transform.position = firePoint.position;

            // Reseta a rotação do tiro para (0, 0, 0)
            projectile.transform.rotation = Quaternion.identity;  // Zera a rotação

            // Ativa o objeto e garante que o componente Renderer esteja visível
            projectile.SetActive(true);
            Renderer renderer = projectile.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true;  // Habilita o Renderer para o tiro ficar visível
            }
        }
    }

}
