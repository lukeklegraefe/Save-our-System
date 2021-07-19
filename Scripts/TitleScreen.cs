using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public Button begin;
    public Button end;

    public GameObject titleObject;
    public GameObject beginObject;
    public GameObject endObject;
    public GameObject tutorialObject;
    public GameObject blackOut;

    public Text tutorialText;
    public Text signText;

    public SFX sfx;


    int id;
    string code;
    int codeNum;

    void Start()
    {
        id = Random.Range(1, 1000000);
        codeNum = Random.Range(65, 90);
        code += (char)codeNum;
        codeNum = Random.Range(65, 90);
        code += (char)codeNum;
    }

    void Update()
    {
        
    }

    public void beginGame() {
        sfx.buttonPress();
        titleObject.SetActive(false);
        beginObject.SetActive(false);
        endObject.SetActive(false);
        tutorialObject.SetActive(true);

        tutorialText.text = $"God #{id} {code}, \n\n\tYou have been chosen to wield insurmountable power. You will be unrivaled amongst the inhabitants of this universe. " +
            $"You will create a universe of your own machinations.\n\tTo first show us your control over this power, we will send you to multiple solar systems, please select " +
            $"a celestial body to destroy for each. Then, you may rule over the universe as you please. Sign below.";
    }

    public void endGame() {
        sfx.buttonPress();
        Application.Quit();
    }

    public void signTutorial() {
        signText.text = id + " " + code;
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut(bool fade = true, int fadeSpeed = 1) {
        yield return new WaitForSeconds(2);
        tutorialObject.SetActive(false);
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
        SceneManager.LoadScene("Main");
     }

}
