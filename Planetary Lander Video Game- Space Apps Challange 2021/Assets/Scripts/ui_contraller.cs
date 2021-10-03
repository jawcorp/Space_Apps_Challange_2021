using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_contraller : MonoBehaviour
{
    public Text throttleLevelDisplay;
    public Text allitudeDisplay;
    public Text velocityDisplay;
    public Text fuelDisplay;

    public lander_contraller landerContraller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        throttleLevelDisplay.text = "Throttle Level: " + Mathf.Round(landerContraller.enginePercent).ToString() + " %";
        allitudeDisplay.text = "Allitude: " + Mathf.Round(landerContraller.allitude).ToString() + " meters";
        velocityDisplay.text = "Velocity: " + Mathf.Round(landerContraller.verticalSpeed).ToString() + " meters/second";
        fuelDisplay.text = "Fuel: " + Mathf.Round(landerContraller.currentFuel/landerContraller.startFuel * 100).ToString() + " %";
    }
}