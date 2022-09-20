using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    int apples = 0;
    [SerializeField] Text AppleText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //When the player touches the apples the apples are destroyed
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            apples++;
            AppleText.text = "Apples: " + apples;
            
        }
    }
}
