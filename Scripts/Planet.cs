using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planet", menuName = "Planet")]
public class Planet : ScriptableObject
{
    public new string name;
    public string description;
    public string size;
    public string climate;
    public string color;

    public Sprite sprite;

    public int population;

    public PlanetDisplay pDisplay;

    public void print() {
        Debug.Log(name + ": " + description + "\nPopulation: " + population);
    }

}
