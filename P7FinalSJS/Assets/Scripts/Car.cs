using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public float maxBattery = 100f; //max battery
    public float batteryLevel = 100f; //current battery
    public float batteryDrainRate = 10f;
    public Slider batterySlider; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //battery drains while car is moving
       DrainBattery(batteryDrainRate * Time.deltaTime);
       UpdateBatteryUI();
    }

    public void RechargeBattery(float amount)
    {
        batteryLevel = Mathf.Clamp(batteryLevel + amount, 0f, maxBattery);
    }
    void DrainBattery(float amount)
    {
        batteryLevel = Mathf.Clamp(batteryLevel - amount, 0f, maxBattery);
    }
    void UpdateBatteryUI()
    {
        batterySlider.value = batteryLevel / maxBattery;

        if (batteryLevel <= maxBattery * 0.5f) // If batter is at 50%
        {
            batterySlider.fillRect.GetComponentInChildren<Image>().color = Color.red;
        }
        else
        {
            batterySlider.fillRect.GetComponentInChildren<Image>().color = Color.green;
        }
    }
}
