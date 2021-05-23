using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationController : MonoBehaviour
{
    public Player player;
    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
    }

    // Update is called once per frame
    void Update()
    {
        //player.totalPunished += 1;
    }

    public void addTotalPunished(GameObject focus) {
        if (focus.gameObject.CompareTag("Asteroid")) {
            player.totalPunished += (uint)focus.GetComponent<AsteroidDisplay>().asteroid.population;
            player.asteroidsDestroyed += 1;
        }
        else {
            player.totalPunished += (uint)focus.GetComponent<PlanetDisplay>().planet.population;
            player.planetsDestroyed += 1;
        }
    }
}
