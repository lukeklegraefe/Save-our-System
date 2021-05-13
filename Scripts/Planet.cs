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

    public void Print() {
        Debug.Log(name + ": " + description + "\nPopulation: " + population);
    }
}
