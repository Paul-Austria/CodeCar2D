using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PanelCode : MonoBehaviour {
    public GameObject player;
    public void Retry()
    {
        transform.gameObject.SetActive(false);
        player.GetComponent<MoveCode>().ResetCar();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
