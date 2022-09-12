using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public void StartGame()
    {
        //Ends game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
