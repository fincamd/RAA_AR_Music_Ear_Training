using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressedRayCaster : MonoBehaviour {

    public AudioSource chordAudioSource;
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
                chordAudioSource.Stop();
                string hitObjectName = hit.transform.name;
                if (hitObjectName == correctAnswerButton.name) {
                    // User did it!!! Yay...  Stop it.
                    correctButtonAnimator.Play("CorrectSolutionButtonAnimation", -1, 0f);
                    incorrectButtonAnimator.Play("IncorrectSolutionButtonAnimation");
                    // Play the Major arpeggio
                    correctAnswerButton.GetComponent<AudioSource>().Play();
                } else if (hitObjectName == incorrectAnswerButton.name) {
                    // User fucked up xd. Do smth so he notices.
                    incorrectButtonAnimator.Play("IncorrectSolutionButtonAnimation");
                    // Play the arpeggio Minor
                    incorrectAnswerButton.GetComponent<AudioSource>().Play();
                }
            }
        }
    }

}
