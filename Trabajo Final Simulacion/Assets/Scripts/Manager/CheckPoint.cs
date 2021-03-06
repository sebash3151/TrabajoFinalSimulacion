using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] Sprite offSprite;
    private AudioSource audio;
    [SerializeField] SpriteRenderer render;
    private bool aterrizaje;
    [SerializeField] Transform point;
    [SerializeField] GameObject gravity, collider;
    [SerializeField] Walker walker;
    [SerializeField] FirstImpulse impulse;
    [SerializeField] bool repetir = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (repetir)
        {
            aterrizaje = false;
        }
        if (collision.CompareTag("Player") && !aterrizaje)
        {
            impulse.desacelere = false;
            walker.velocidad = Vector2.zero;
            walker.aceleracion = Vector2.zero;
            gravity.SetActive(false);
            CircleCollider2D planetCollider = collider.GetComponent<CircleCollider2D>();
            planetCollider.enabled = false;
            collision.transform.position = point.position; 
            aterrizaje = true;
            render.sprite = offSprite;
            audio.Play();
            manager.Preparate();
        }
    }
}
