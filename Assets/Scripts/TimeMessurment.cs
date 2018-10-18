using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeMessurment : MonoBehaviour {

    public TextMeshProUGUI infoText;
    public GameObject NextLevelButton;
    public GameObject gameOverSound;
    public float minTime;
    public bool finished;
    public bool mesureTime;
    public float TimeRun;
    public Text text;
    public Text madeItTime;
    public GameObject panel;
    bool playAni;
    public Text TryText;
    public float animationTime;
    float plannedRot;
    private void Update()
    {
        if (mesureTime)
        {
            TimeRun += Time.deltaTime;
            text.GetComponent<Text>().text = "Time: " + TimeRun;
            if (animationTime > 0)
            {
                animationTime -= Time.deltaTime;
                if(animationTime <= 0)
                {
                    playAni = false;
                    transform.GetComponent<MoveCode>().ResetCar();
                }
            }
            if(playAni)
            {
                playAnim();
            }
        }
    }

    void playAnim()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, plannedRot), 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "O" && !playAni)
        {
            plannedRot = gameObject.transform.rotation.eulerAngles.z + 180;
            playAni = true;
            animationTime = 1.5f;
            transform.GetComponent<MoveCode>().runCar = false;
            transform.GetComponent<MoveCode>().runCode = true;
            Vector2 direction = new Vector2(transform.up.x, transform.up.y);
            transform.GetComponent<Rigidbody2D>().velocity = direction * Time.fixedDeltaTime * 0;
            //transform.GetComponent<MoveCode>().ResetCar();
            gameOverSound.GetComponent<AudioSource>().Play();
        }
        else if(collision.gameObject.name == "End")
        {
            panel.SetActive(true);
            Debug.Log("Finnishd");
            madeItTime.text = "Your Time is: " + TimeRun + " s";
            if (minTime < TimeRun)
            {
                TryText.text = "You need to have a time of: " + minTime + " s";
                infoText.GetComponent<TextMeshProUGUI>().SetText("Not fast enough!");
                NextLevelButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                NextLevelButton.GetComponent<Button>().interactable = true;
                TryText.text = "It took you " + transform.GetComponent<MoveCode>().trys + " trys";
            }
            mesureTime = false;
            finished = true;
            transform.GetComponent<MoveCode>().runCar = false;
            transform.GetComponent<MoveCode>().runCode = false;
            Vector2 direction = new Vector2(transform.up.x, transform.up.y);
            transform.GetComponent<Rigidbody2D>().velocity = direction * Time.fixedDeltaTime * 0;
        }
    }
}
