using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car2 : MonoBehaviour
{
    public float maxBattery = 100f; //max battery
    public float currentBatteryLevel = 100f; //current battery
    public float batteryDrainRate = 10f;

    public float moveSpeed = 50f;
    public float turnSpeed = 50f; 

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

        if (currentBatteryLevel > 0f)
        {
            DrainBattery(batteryDrainRate * Time.deltaTime);
        }
        else
        {
            Debug.Log("Car out of battery");
            return;
        }
        MoveCar();
        UpdateBatteryUI();
    }
    void MoveCar()
    {
        float turnInput = Input.GetAxis("Horizontal2");
        float rotationAmount = turnInput * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, rotationAmount, 0f);
        float moveInput = Input.GetAxis("Vertical2");
        float moveAmount = moveInput * moveSpeed * Time.deltaTime;
        Vector3 moveDirection = transform.forward * moveAmount;
        transform.Translate(moveDirection, Space.World);
    }
    public void RechargeBattery(float amount)
    {
        currentBatteryLevel = Mathf.Clamp(currentBatteryLevel + amount, 0f, maxBattery);
    }
    void DrainBattery(float amount)
    {
        currentBatteryLevel = Mathf.Clamp(currentBatteryLevel - amount, 0f, maxBattery);
    }
    void UpdateBatteryUI()
    {
        batterySlider.value = currentBatteryLevel / maxBattery;

        if (currentBatteryLevel <= maxBattery * 0.5f) // If batter is at 50%
        {
            batterySlider.fillRect.GetComponentInChildren<Image>().color = Color.red;
        }
        else
        {
            batterySlider.fillRect.GetComponentInChildren<Image>().color = Color.green;
        }
    }
}
