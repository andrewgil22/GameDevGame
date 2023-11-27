using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMovement : MonoBehaviour
{
    private float speed;
    private Vector2 movementDirection; // Changed to Vector2 to handle both x and y movement
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Initialize(float speed, Vector2 direction)
    {
        this.speed = speed;
        this.movementDirection = direction;

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            audioSource.Play();
            Destroy(other.gameObject);
            StartCoroutine(DestroyAfterSound());
        }
    }

    IEnumerator DestroyAfterSound()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        Destroy(gameObject);
    }
}
