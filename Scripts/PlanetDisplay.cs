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

    public Image spriteImage;
    public Image infoImage;

    public Button p_button;

    public GameObject p_obj;
    private bool display = false;

    public Camera c;
    public CameraZoom zoom;

    void Start()
    {
        c = Camera.main;
        nameText.text = "Name: " + planet.name;
        descriptionText.text = "Info: " + planet.description;
        climateText.text = "Climate: " + planet.climate;
        spriteImage.sprite = planet.sprite;

        planet.Print();

        p_button.onClick.AddListener(displayInfo);
    }
    
    void displayInfo()
    {
        zoom.p = p_obj;
        if (display){
            display = false;
            zoom.ZoomActive = display;
        }
        else{
            display = true;
            zoom.ZoomActive = display;
        }
        nameText.gameObject.SetActive(display);
        descriptionText.gameObject.SetActive(display);
        climateText.gameObject.SetActive(display);
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
        }

    }
}
