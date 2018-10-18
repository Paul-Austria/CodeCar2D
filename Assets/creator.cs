using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class creator : MonoBehaviour {

    public GameObject canvas;
    public GameObject button;

    void Start()
    {
        GameObject newButton = Instantiate(button) as GameObject;
        newButton.transform.SetParent(canvas.transform, false);
        Vector3 x = newButton.transform.position;
        x.y = 500;
        newButton.transform.position = x;
    }
    void Update () {
		
	}
}
