using UnityEngine;
using TMPro;

public class Collectibles : MonoBehaviour
{
    public TMP_Text keysCollectedText; 
    public GameObject door; 
    public GameObject gameOverPanel; 

    private static int totalKeys = 6; 
    private static int keysCollected = 0;
    private bool doorLocked = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Key"))
            {
                Debug.Log("Player Collision Detected");
                CollectKey();
            }
            else if(gameObject.CompareTag("Door"))
            {
                CheckCompletion();
            }
        }   
    }

    private void CollectKey()
    {
        keysCollected++;
        UpdateKeysUI();
        Destroy(gameObject); 
        
    }

    private void UpdateKeysUI()
    {
        if (keysCollectedText != null)
        {
            keysCollectedText.text = "Keys Collected: " + keysCollected + " / " + totalKeys;
        }
    }

    private void CheckCompletion()
    {
        if (keysCollected >= totalKeys && doorLocked)
        {
            PlayerWins();
        }
    }

    private void PlayerWins()
    {
        doorLocked = false;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 

            TMP_Text gameOverText = gameOverPanel.GetComponentInChildren<TMP_Text>();
            if (gameOverText != null)
            {
                gameOverText.text = "Player Wins!";
            }
        }
    }
}