using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menucomponent : MonoBehaviour {

    //all these are used to load a specific scene from the build settings
	public void playgame()
    {
        SceneManager.LoadScene("Level1");
        
    }
    
    //this is used to exit the application
    public void Exitgame()
    {
        Application.Quit();
    }


}
