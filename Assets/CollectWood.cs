using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWood : MonoBehaviour
{
    public AudioClip collectSound; // Αναφορά στο AudioClip για τον ήχο συλλογής
    // Η συνάρτηση αυτή καλείται όταν ένας άλλος Collider μπαίνει στον Trigger του αντικειμένου αυτού
    private void OnTriggerEnter(Collider other)
    {
        // Έλεγξε αν το αντικείμενο που συγκρούστηκε είναι ο player
        if (other.CompareTag("Player")) // Βεβαιώσου ότι ο player έχει το tag "Player"
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            // Εξαφάνισε το αντικείμενο (μπορείς να το κάνεις είτε με destroy είτε με απενεργοποίηση)
            Destroy(gameObject); // Εξαφανίζει το ξύλο
            // Alternately: gameObject.SetActive(false); // Απενεργοποιεί το ξύλο
            // Εύρεση του αντικειμένου WoodCounter και κλήση της συνάρτησης CollectWood
            FindObjectOfType<WoodCounter>().CollectWood();

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
