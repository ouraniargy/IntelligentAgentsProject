using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentAxesCounter : MonoBehaviour
{
    public TextMeshProUGUI axesCountText; // Reference to the UI Text for axes count
    private int axesCount = 0; // Initial number of axes

    public void AgentCollectAxes()
    {
        axesCount++; // Increase the number of axes
        axesCountText.text = "Agent Axes : " + axesCount; // Update the text
        Debug.Log("Axes collected! Total axes: " + axesCount);
    }
}
