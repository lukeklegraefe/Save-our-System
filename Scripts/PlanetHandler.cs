using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetHandler : MonoBehaviour
{
    public CameraZoom cam;
    public PlanetDisplay focusDisplay;
    public AsteroidDisplay asteroidDisplay;
    public bool transition;

    void Start() {

    }

    void Update() {
        if (transition) {
            //transition = false;
        }
    }

    public void punish() {
        cam.focus.SetActive(false);
        cam.punish();
        transition = true;
    }

    public void spare() {
        cam.spared();
        if (cam.focus.gameObject.CompareTag("Asteroid")) {
            asteroidDisplay = cam.focus.GetComponent<AsteroidDisplay>();
            asteroidDisplay.a_button.onClick.Invoke();
        }
        else {
            focusDisplay = cam.focus.GetComponent<PlanetDisplay>();
            focusDisplay.p_button.onClick.Invoke();
        }
    }

    IEnumerator StageTransition() {
        yield return new WaitForSeconds(5);
        Debug.Log("Stage complete");
    }
}
