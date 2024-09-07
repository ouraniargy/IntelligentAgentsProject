using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        if (music != null)
        {
            music.Play(); // Ξεκινάει την αναπαραγωγή της μουσικής
        }
        else
        {
            Debug.LogWarning("music not assigned!");
        }
    }


}
