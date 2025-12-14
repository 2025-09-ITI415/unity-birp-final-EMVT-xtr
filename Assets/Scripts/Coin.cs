using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound;
    public float volume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
            }
            Collect();
        }
    }

    void Collect()
    {
        // Optional: play sound here

        Destroy(gameObject);
    }
}