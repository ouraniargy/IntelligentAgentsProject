using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentAxesCounter : MonoBehaviour
{
    public TextMeshProUGUI axesCountText;
    private int axesCount = 0;
    private int requiredAxes = 10;

    public void AgentCollectAxes()
    {
        axesCount++;
        axesCountText.text = "Axes: " + axesCount;
        if (axesCount >= requiredAxes)
        {
            axesCountText.text = "Axes: " + axesCount;
        }
    }
}
