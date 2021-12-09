using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // this is all base on order in build setting, moving one scene to another
    public void playLevel1() // First Player level (1), should be the easiest level compared to the other
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void playLevel2() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void playLevel3() // Player Level 3
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void playLevel4() // First Player level (1), should be the easiest level compared to the other
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void playLevel5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void playLevel6() // Player Level 3
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }



    public void backToMainMenu1() // For Level 1 to go back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void backToMainMenu2() // For Level 2 to go back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    // for only Level 3 to quit to main menu
    public void backToMainMenu3() // For Level 3 to go back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void backToMainMenu4() // For Level 1 to go back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void backToMainMenu5() // For Level 2 to go back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    // for only Level 3 to quit to main menu
    public void backToMainMenu6() // For Level 3 to go back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }

    public void backToMainMenu7() // For Level 3 to go back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
    }
    public void backToMainMenu8() // For Level 3 to go back to main menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 8);
    }


    public void quitGame() // For Level 3 to go back to main menu
    {
        Application.Quit();
    }
}
