using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargingStation : MonoBehaviour
{
    public float chargeRate = 0.5f;
    public GameObject car1;
    public GameObject car2;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == car1 || other.gameObject == car2)
        {
            //Increase the cars battery level while in the charging station
            other.GetComponent<Car>().RechargeBattery(chargeRate * Time.deltaTime);
        }
    }
}
