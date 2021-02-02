using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionSlider : MonoBehaviour
{
    public Slider positionSlider;
  
    
    public void SetMaxDestination(float destination)
    {
        positionSlider.maxValue = destination;
        positionSlider.value = destination;

    }
    public void SetDestination(float destination)
    {
        positionSlider.value = destination;

        
    }
}
