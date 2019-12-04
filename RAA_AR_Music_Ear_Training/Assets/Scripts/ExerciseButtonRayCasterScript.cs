using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseButtonRayCasterScript : MonoBehaviour {

    public AudioSource audioSource;
    public GameObject correctAnswerButton;
    public GameObject incorrectAnswerButton;
    public Animator correctButtonAnimator;
    public Animator incorrectButtonAnimator;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                string hitObjectName = hit.transform.name;
                if (hitObjectName == correctAnswerButton.name) {
                    // User did it!!! Yay...  Stop it.
                    correctButtonAnimator.Play("CorrectSolutionButtonAnimation");
                    incorrectButtonAnimator.Play("IncorrectSolutionButtonAnimation");
                    // Play the arpeggio Major
                } else if (hitObjectName == incorrectAnswerButton.name) {
                    // User fucked up xd. Do smth so he notices.
                    incorrectButtonAnimator.Play("IncorrectSolutionButtonAnimation");
                    // Play the arpeggio Minor
                }
            }
        }
    }

}
