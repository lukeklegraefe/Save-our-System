using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public Player player;
    public Image messageOverlay;
    public Text message;
    public Text creditsText;
    public GameObject button;
    public GameObject creditRoll;
    public GameObject exitButton;

    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
        if (player.totalPunished > 100) {
            message.text = "God,\n\nWe citizens of Earth have been monitoring your actions throughout the universe. We are distraught with your neglect for intergalactic life. Please, go away and never come back.";
            creditsText.text += $"\n\nBad End\n\nTotal organisms punished: {player.totalPunished}";
        }
        else {
            message.text = "God,\n\nWe citizens of Earth have been monitoring your actions throughout the universe. Though we renounce a singular power for fear of imbalance, we thank you for your treatment of intergalactic life.";
            creditsText.text += $"\n\nGood End\n\nTotal organisms punished: {player.totalPunished}";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void credits() {
        message.enabled = false;
        messageOverlay.enabled = false;
        button.SetActive(false);
        creditRoll.GetComponent<Animator>().SetBool("roll", true);
        StartCoroutine(Wait());
    }

    public IEnumerator Wait() {
        yield return new WaitForSeconds(30);
        exitButton.SetActive(true);
    }

    public void exit() {
        Application.Quit();
    }
}
