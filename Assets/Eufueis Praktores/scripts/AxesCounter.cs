using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;

public class AxesCounter : MonoBehaviour
{
    public TextMeshProUGUI axesCountText; // Αναφορά στο UI Text για το μέτρημα των σπαθιων
    private int axesCount = 0; // Αρχικός αριθμός σπαθιων

    public void CollectAxes()
    {
        axesCount++; // Αύξηση του αριθμού των σπαθιων
        axesCountText.text = "Axes: " + axesCount; // Ενημέρωση του κειμένου
    }
}
