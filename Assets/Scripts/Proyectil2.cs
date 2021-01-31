using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    public int danio;

    private void Start()
    {
        Invoke("DestroyProyectil", lifeTime);
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProyectil()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemigo")
        {
          other.GetComponent<VidaEnemigo>().PerderVida(danio);
          Destroy(gameObject);
        }
    }

}
