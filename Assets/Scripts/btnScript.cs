using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class btnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void exitGame()
    {
        Application.Quit();
    }
    public void startGame()
    {
        //possibly make it so it loads the level and fades the UI
        SceneManager.LoadScene("Level1");
    }
    public void returnMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
