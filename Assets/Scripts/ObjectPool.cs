using UnityEngine;
using System.Collections.Generic;

public class ObjectPool
{
    private GameObject prefab;
    private Queue<GameObject> queue;
    private int poolSize;

    public ObjectPool(GameObject prefab, int poolSize)
    {
        this.prefab = prefab;
        this.poolSize = poolSize;
        queue = new Queue<GameObject>();

        // Inicializa a pool
        for (int i = 0; i < this.poolSize; i++)
        {
            GameObject obj = Object.Instantiate(prefab);
            obj.SetActive(false);

            // Desativa o Renderer do tiro (para não ser visível)
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            queue.Enqueue(obj);
        }
    }

    public GameObject GetFromPool()
    {
        GameObject obj = queue.Peek();

        if (obj.activeSelf)
        {
            return null;
        }

        queue.Dequeue();
        queue.Enqueue(obj);

        // // para o tiro nao ficar na diagonal
        // obj.transform.rotation = Quaternion.identity;

        obj.SetActive(true);
        return obj;
    }

    
}

