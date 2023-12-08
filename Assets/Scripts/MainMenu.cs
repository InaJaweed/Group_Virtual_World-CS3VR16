using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // When the player presses play it will take them to the next scene 
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Quit(){
      Application.Quit();
    }

}
   // public void Quit()
    //{
     //When the player presses quit they will exit out of the scene 
       // Application.Quit();
        //Debug.log("Player has Quit MaineScene");

    //}
  //

//}
