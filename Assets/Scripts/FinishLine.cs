using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "PushBlock")
        {
            Debug.Log("You Win");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

   

}
