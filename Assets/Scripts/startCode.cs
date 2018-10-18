using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startCode : MonoBehaviour {

	public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenPage()
    {
        Application.OpenURL("https://ksppaul.itch.io/code-car");
    }
}
