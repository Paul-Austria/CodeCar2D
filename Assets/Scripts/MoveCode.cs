using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveCode : MonoBehaviour {

    public bool runCode = false;
    public bool lastCommandStillRunning = false;
    public string[] code;
    public float currentRot;
    public float plannedRot;
    public int currentCommeand = 0;
    public float plannedSpeed;
    public float maxRot;
    public float pause = 0;
    public float speed;
    public float speedChange;
    public int trys;
    public bool runCar;
    Vector2 startPos;
    Quaternion rot;
    public Text speedUI, rotUI, timeUI;
    private void Start()
    {
        startPos = transform.position;
        rot = transform.rotation;
    }

    void Update () {
        speedUI.text = "Speed: " + speed;
        rotUI.text = "Rotation: " + gameObject.transform.rotation.eulerAngles.z;
        timeUI.text = "Pause: " + pause;
        if(pause > 0)
        {
            pause -= Time.deltaTime;
            if (pause < 0) pause = 0;
        }
        if(runCar)
        {
            AlwaysCall();
        }
        if (runCode && pause <= 0)
        {
            if(!lastCommandStillRunning)
            {

                string[] splitCommand = code[currentCommeand].Split(' ');
                Debug.Log("Command: "+splitCommand[0]);
                if (splitCommand[0] == "acc")
                {
                    plannedSpeed = float.Parse(splitCommand[1]);
                }
                else if(splitCommand[0] == "rot")
                {
                    plannedRot = float.Parse(splitCommand[1]) *(-1);
                }
                else if(splitCommand[0] == "pause")
                {
                    pause = float.Parse(splitCommand[1]);
                }
                currentCommeand++;
                if(splitCommand[0] == "goto")
                {
                    currentCommeand = int.Parse(splitCommand[1]);
                }
                if (currentCommeand >= code.Length) runCode = false;

            }
        }
    }
    public void ResetCar()
   {
        trys++;
        runCode = false;
        runCar = false;
        speed = 0;
        plannedSpeed = 0;
        pause = 0;
        plannedRot = 90;
        transform.rotation = rot;
        transform.GetComponent<TimeMessurment>().TimeRun = 0;
        transform.GetComponent<TimeMessurment>().mesureTime = false;
        Vector2 direction = new Vector2(transform.up.x, transform.up.y);
        transform.GetComponent<Rigidbody2D>().velocity = direction * Time.fixedDeltaTime * 0;
        transform.position = startPos;
        currentCommeand = 0;
   }
    void AlwaysCall()
    {
        Move();
        Rot();
        Vector2 direction = new Vector2(transform.up.x, transform.up.y);
        transform.GetComponent<Rigidbody2D>().velocity = direction * Time.fixedDeltaTime * speed;
    }
    void Rot()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, plannedRot), maxRot);
    }
    void Move()
    {
        if(plannedSpeed < speed)
        {
            speed -= speedChange;
            if(plannedSpeed > speed)
            {
                speed = plannedSpeed;
            }
        }
        if(plannedSpeed > speed)
        {
            speed += speedChange;
            if (plannedSpeed < speed)
            {
                speed = plannedSpeed;
            }
        }
    }
}
