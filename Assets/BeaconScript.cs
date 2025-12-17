using UnityEngine;

public class BeaconScript : MonoBehaviour
{
    public GameObject winPanel;
    public AudioClip winSound;
    public float volume = 1f;
    
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            if (winSound != null)
            {
                Canvas canvas = FindFirstObjectByType<Canvas>();

                GameObject panel = Instantiate(winPanel, canvas.transform);
                panel.transform.localScale = Vector3.one;
                Cursor.visible = true;
                AudioSource.PlayClipAtPoint(winSound, transform.position, volume);
            }
        }
    }
}
