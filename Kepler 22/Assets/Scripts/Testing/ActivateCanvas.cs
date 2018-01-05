using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCanvas : MonoBehaviour {

    public GameObject mainCanvas;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            mainCanvas.SetActive(true);
    }
}
