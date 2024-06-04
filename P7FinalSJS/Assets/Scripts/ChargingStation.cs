using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingStation : MonoBehaviour
{
    public float chargeRate = 0.5f;
    private List<GameObject> carsInStation = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            carsInStation.Add(other.gameObject);
            Debug.Log("Car entered charging station");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            carsInStation.Remove(other.gameObject);
            Debug.Log("Car exited charging station");
        }
    }
    void Update()
    {
      foreach (GameObject car in carsInStation)
        {
            ChargeCar(car);
        }     
    }
    void ChargeCar(GameObject car)
    {
        Car carScript = car.GetComponent<Car>();
        if (carScript != null)
        {
            carScript.currentBatteryLevel += chargeRate * Time.deltaTime;
            carScript.currentBatteryLevel = Mathf.Clamp(carScript.currentBatteryLevel, 0f, 100f);
        }
        Car2 car2Script = car.GetComponent<Car2>();
        if (car2Script != null)
        {
            car2Script.currentBatteryLevel += chargeRate * Time.deltaTime;
            car2Script.currentBatteryLevel = Mathf.Clamp(car2Script.currentBatteryLevel, 0f, 100f);
        }
    }
}
