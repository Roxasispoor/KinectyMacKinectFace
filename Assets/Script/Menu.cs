using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour{
    
    public void LoadInstructions()
    {
        SceneManager.LoadScene("InstructionScene", LoadSceneMode.Single);
    }

    public void LoadFreeDetection()
    {
        SceneManager.LoadScene("DanceWaterDance", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
