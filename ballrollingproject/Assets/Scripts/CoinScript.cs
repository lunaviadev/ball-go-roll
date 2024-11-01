using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public int coinCount = 0;
    public TMP_Text coinCountText; 
    void Start()
    {
        UpdateCoinCountUI();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Coin"))
        {
            coinCount++; 
            UpdateCoinCountUI(); 
            Destroy(other.gameObject); 
        }
    }

    void UpdateCoinCountUI()
    {
        if (coinCountText == null)
            return;
        coinCountText.text = "Coins: " + coinCount; 
    }

    public Vector3 rotationDirection = Vector3.up;
    public float rotationSpeed = 50f;

    private void Update()
    {
        transform.Rotate(rotationDirection.normalized, rotationSpeed * Time.deltaTime);
    }
}
