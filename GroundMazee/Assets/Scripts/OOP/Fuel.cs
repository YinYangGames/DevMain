using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{

    public Slider fuelSlider;

    public Gradient gradient;
    public Image fill;
    // Start is called before the first frame update
  

    public void SetMaxFuel(int fuel)
    {
        fuelSlider.maxValue = fuel;
        fuelSlider.value = fuel;

    }
    public void SetFuel(float fuel)
    {
        fuelSlider.value = fuel;

        fill.color = gradient.Evaluate(fuelSlider.normalizedValue);
    }
}
