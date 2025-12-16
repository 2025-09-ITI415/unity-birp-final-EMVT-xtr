using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int coinCount = 0;
    private  TMP_Text coinText;
    public AudioClip collectSound;
    public float volume = 1f;

    private void Start()
    {
        // Find the TextMeshProUGUI in the scene by name
        coinText = GameObject.Find("Coins_Aquired")?.GetComponent<TMP_Text>();

        if (coinText == null)
            Debug.LogWarning("CoinText not found in scene!");
    }

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
        coinCount++;
        if (coinText != null)
        {
            coinText.text = "Coins Acquired: " + coinCount;
        }

        Destroy(gameObject);
    }
   
}