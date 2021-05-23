using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public GameObject blackOut;
    public PlanetHandler planetHandler;
    public ParticleSystem particleSystem;
    public Canvas canvas;
    public bool loadNextLevel;

    void Start() {
        canvas.sortingOrder = -1;
    }

    void Update() {
        if (planetHandler.cam.zoomActive) {
            canvas.sortingOrder = 1;
        }
        else {
            canvas.sortingOrder = -1;
        }
        if (planetHandler.transition) {
            canvas.sortingOrder = 1;
            StartCoroutine(FadeOut());
            loadNextLevel = true;
        }
    }

    public IEnumerator FadeOut(bool fade = true, int fadeSpeed = 1) {
        particleSystem.Stop();
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        Color objectColor = blackOut.GetComponent<Image>().color;
        float fadeAmount;

        if (fade) {
            while (blackOut.GetComponent<Image>().color.a < 1) {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOut.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else {
            while (blackOut.GetComponent<Image>().color.a > 0) {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOut.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        SceneManager.LoadScene("Level2");
    }
}
