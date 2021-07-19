using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject blackOut;
    public GameObject message;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void endGame() {
        message.active = false;
        blackOut.GetComponent<Image>().enabled = true;
        StartCoroutine(triggerCredits());
    }

    public IEnumerator triggerCredits(bool fade = true, int fadeSpeed = 1) {
        Debug.Log("Game has ended");
        yield return new WaitForSeconds(3);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
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
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Credits");
    }
}
