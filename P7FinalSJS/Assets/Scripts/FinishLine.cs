using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            FindObjectOfType<RaceManager>().Player1CompletedLap();
        }
        if (other.CompareTag("Player2"))
        {
            FindObjectOfType<RaceManager>().Player2CompletedLap();
        }
    }
}
