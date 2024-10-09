using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class AxesCounter : MonoBehaviour
{
    public TextMeshProUGUI axesCountText; 
    private int axesCount = 0;
    public TextMeshProUGUI gameStatusText; 
    private int requiredAxes = 10; 

    public void CollectAxes()
    {
        axesCount++; 
        axesCountText.text = "Axes: " + axesCount; 
        if (axesCount >= requiredAxes)
        {
            gameStatusText.text = "Axes Collected!";
        }
    }
}
