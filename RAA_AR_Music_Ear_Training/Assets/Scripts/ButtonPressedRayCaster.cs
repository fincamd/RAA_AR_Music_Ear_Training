using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class Scores {
    public static int correctAnswers = 0;
    public static int incorrectAnswers = 0;
}

public class ButtonPressedRayCaster : MonoBehaviour {

    public AudioSource chordAudioSource;
    public GameObject correctAnswerButton, incorrectAnswerButton;
    public Animator correctButtonAnimator, incorrectButtonAnimator;
    public Text correctAnswersCounter, incorrectAnswersCounter;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                chordAudioSource.Stop();
                string hitObjectName = hit.transform.name;
                if (hitObjectName == correctAnswerButton.name) {
                    // User did it!!! Yay...  Stop it.
                    correctButtonAnimator.Play("CorrectSolutionButtonAnimation", -1, 0f);
                    incorrectButtonAnimator.Play("IncorrectSolutionButtonAnimation");
                    // Play the Major arpeggio
                    correctAnswerButton.GetComponent<AudioSource>().Play();
                    // Increment correct score
                    Scores.correctAnswers++;
                    correctAnswersCounter.text = "Correct:" + Scores.correctAnswers;
                } else if (hitObjectName == incorrectAnswerButton.name) {
                    // User fucked up xd. Do sth so he notices.
                    incorrectButtonAnimator.Play("IncorrectSolutionButtonAnimation");
                    // Play the Minor arpeggio
                    incorrectAnswerButton.GetComponent<AudioSource>().Play();
                    // Increment incorrect answers counter
                    Scores.incorrectAnswers++;
                    incorrectAnswersCounter.text = "Incorrect:" + Scores.incorrectAnswers;
                }
            }
        }
    }

}
