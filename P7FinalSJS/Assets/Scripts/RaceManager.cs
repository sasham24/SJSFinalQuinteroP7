using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class RaceManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public TextMeshProUGUI player1TimeText;
    public TextMeshProUGUI player2TimeText;

    public TextMeshProUGUI player1LapText;
    public TextMeshProUGUI player2LapText;

    private int player1Laps = 0;
    private int player2Laps = 0;
    private float player1Time = 0f;
    private float player2Time = 0f;

    private bool player1Racing = true;
    private bool player2Racing = true;

    private float player1Battery = 100f;
    private float player2Battery = 100f;
    public float batteryDrainRate = 10f; // Drain rate per second

   
    private void Update()
    {
        if (player1Racing) 
        {
            player1Time += Time.deltaTime;
            player1Battery -= batteryDrainRate * Time.deltaTime;
            player1Battery = Mathf.Clamp(player1Battery, 0f, 100f);
            player1TimeText.text = "Player 1 Time: " + player1Time.ToString("F2");
        }   
        if (player2Racing)
        {
            player2Time += Time.deltaTime;
            player2Battery -= batteryDrainRate * Time.deltaTime;
            player2Battery = Mathf.Clamp(player1Battery, 0f, 100f);
            player2TimeText.text = "Player 2 Time: " + player2Time.ToString("F2");
        }
        if (player1Laps >= 3)
        {
            player1Racing = false;
        }
        if (player2Laps >= 3)
        {
            player2Racing = false;
        }
        
    }
    public void Player1CompletedLap()
    {
        player1Laps++;
        player1TimeText.text = "Player 1 Laps: " + player1Laps;
        RechargeBattery(1);
    }
    public void Player2CompletedLap()
    {
        player2Laps++;
        player2TimeText.text = "Player 2 Laps: " + player2Laps;
        RechargeBattery(2);
    }
    private void RechargeBattery(int player)
    {
        if (player == 1)
        {
            player1Battery = 100f;
        }
        else if (player == 2)
        {
            player2Battery = 100f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            Player1CompletedLap();
        }
        else if (other.CompareTag("Player2"))
        {
            Player2CompletedLap();
        }
    }
}
