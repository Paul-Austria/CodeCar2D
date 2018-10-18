using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RunCode : MonoBehaviour {


    public InputField input;
    public string[] list;
    public GameObject player;
    public void ButtonEnter()
    {
        string inputFieldString = input.text;

        list = inputFieldString.Split('\n');
        player.GetComponent<MoveCode>().ResetCar();
        player.GetComponent<MoveCode>().code = list;
        player.GetComponent<MoveCode>().runCode = true;
        player.GetComponent<MoveCode>().runCar = true;
        player.GetComponent<TimeMessurment>().mesureTime = true;
    }
}