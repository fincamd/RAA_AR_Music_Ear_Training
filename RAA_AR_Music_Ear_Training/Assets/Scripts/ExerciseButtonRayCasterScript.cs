﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseButtonRayCasterScript : MonoBehaviour {

    private string buttonName;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                buttonName = hit.transform.name;
                // TODO remove
                audioSource.Pause();
                // boolean correct = checkIfUserAnswerIsCorrect(buttonName);
                // if (correct) {
                //    processCorrectAnswer();
                //} else {
                //     processIncorrectAnswer();
                // }
            }
        }
    }

}
