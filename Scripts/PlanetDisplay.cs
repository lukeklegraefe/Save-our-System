using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetDisplay : MonoBehaviour
{
    public Planet planet;

    public Text nameText;
    public Text descriptionText;
    public Text climateText;
    public Text populationText;

    public Image spriteImage;
    public Image infoImage;

    public Button p_button;
    public GameObject p_obj;

    public bool display = false;

    public Camera c;
    public CameraZoom zoom;

    void Start()
    {
        c = Camera.main;
        nameText.text = "Name: " + planet.name;
        descriptionText.text = "Info: " + planet.description;
        climateText.text = "Climate: " + planet.climate;
        populationText.text = "Population: " + planet.population;
        spriteImage.sprite = planet.sprite;

        planet.print();

        p_button.onClick.AddListener(displayInfo);
    }

    void Update() {
        if (zoom.zoomActive && zoom.focus != this.gameObject) {
            p_button.enabled = false;
        }
        else {
            p_button.enabled = true;
        }
    }

    public void displayInfo()
    {
        zoom.focus = p_obj;
        if (display){
            display = false;
            zoom.zoomActive = display;
        }
        else{
            display = true;
            zoom.zoomActive = display;
        }
        nameText.gameObject.SetActive(display);
        descriptionText.gameObject.SetActive(display);
        climateText.gameObject.SetActive(display);
        populationText.gameObject.SetActive(display);
        infoImage.gameObject.SetActive(display);

        switch (planet.color) {
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
            case "Brown":
                infoImage.color = Color.black;
                break;
            case "Cyan":
                infoImage.color = Color.cyan;
                break;
            case "Pink":
                infoImage.color = Color.magenta;
                break;
        }

    }
}
