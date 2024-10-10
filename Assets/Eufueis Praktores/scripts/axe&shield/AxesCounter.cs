using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AxesCounter : MonoBehaviour
{
    public TextMeshProUGUI axesCountText;
    private int axesCount = 0;
    private int requiredAxes = 10;
    public void CollectAxes()
    {
        axesCount++;
        axesCountText.text = "Axes :" + axesCount;
        if (axesCount >= requiredAxes)
        {
            axesCountText.text = "Axes Collected:" + axesCount;
        }
    }
    public int GetaxesCount()
    {
        return axesCount; 
    }

}
