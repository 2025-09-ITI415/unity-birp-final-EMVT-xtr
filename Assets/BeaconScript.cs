using UnityEngine;

public class BeaconScript : MonoBehaviour
{
    public AudioClip winSound;
    public float volume = 1f;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            if (winSound != null)
            {
                AudioSource.PlayClipAtPoint(winSound, transform.position, volume);
            }
        }
    }
}
