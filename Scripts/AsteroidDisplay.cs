using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidDisplay : MonoBehaviour
{
    public Asteroid asteroid;

    public Text nameText;
    public Text descriptionText;
    public Text climateText;

    public Image spriteImage;
    public Image infoImage;

    public Button a_button;

    public GameObject a_obj;
    private bool display = false;

    public Camera c;
    public CameraZoom zoom;

    void Start() {
        c = Camera.main;
        nameText.text = "Name: " + asteroid.name;
        descriptionText.text = "Info: " + asteroid.description;
        climateText.text = "Climate: " + asteroid.climate;
        spriteImage.sprite = asteroid.sprite;

        asteroid.Print();

        a_button.onClick.AddListener(displayInfo);
    }

    void displayInfo() {
        zoom.p = a_obj;
        if (display) {
            display = false;
            zoom.ZoomActive = display;
        }
        else {
            display = true;
            zoom.ZoomActive = display;
        }
        nameText.gameObject.SetActive(display);
        descriptionText.gameObject.SetActive(display);
        climateText.gameObject.SetActive(display);
        infoImage.gameObject.SetActive(display);

        switch (asteroid.color) {
            case "Blue":
                infoImage.color = Color.blue;
                break;
            case "Red":
                infoImage.color = Color.red;
                break;
            case "Green":
                infoImage.color = Color.green;
                break;
            case "Purple":
                infoImage.color = Color.magenta;
                break;
        }

    }
}
