using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int coinCount = 0;
    private  TMP_Text coinText;
    public AudioClip collectSound;
    public float volume = 1f;
    public GameObject beaconBread;
    public GameObject Player;

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
        IncrementCoinText();

        Destroy(gameObject);
    }

    void IncrementCoinText()
    {
        // Example text: "Coins Acquired: 3"
        string currentText = coinText.text;

        // Split on colon
        string[] parts = currentText.Split(':');

        if (parts.Length < 2) return;

        // Trim and convert number
        int currentCoins = int.Parse(parts[1].Trim());

        currentCoins++;

        // Write back
        coinText.text = "Coins Acquired: " + currentCoins;

        if(currentCoins == 2){
            Vector3 spawnPos = new Vector3(361.0029f, 202.48f, 795.244f);
            Instantiate(beaconBread, spawnPos, Quaternion.identity);
            Debug.Log("BeaconBread spawned!");
        }
    }
   
}