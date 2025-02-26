﻿using System.Collections;
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
        //spriteImage.sprite = asteroid.sprite;

        asteroid.Print();

        if (a_button.gameObject.CompareTag("Asteroid")){
            a_button.onClick.AddListener(displayInfo);
        }
    }

    void Update() {
        if (zoom.zoomActive && zoom.focus != this.gameObject) {
            a_button.enabled = false;
        }
        else {
            a_button.enabled = true;
        }
    }

    public void displayInfo() {
        zoom.focus = a_obj;
        if (display) {
            display = false;
            zoom.zoomActive = display;
        }
        else {
            display = true;
            zoom.zoomActive = display;
        }
        nameText.gameObject.SetActive(display);
        descriptionText.gameObject.SetActive(display);
        climateText.gameObject.SetActive(display);
        infoImage.gameObject.SetActive(display);

        switch (asteroid.color) {
            case "Brown":
                infoImage.color = Color.gray;
                break;
        }

    }
}
