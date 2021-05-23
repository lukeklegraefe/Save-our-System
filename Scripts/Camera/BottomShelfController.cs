using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomShelfController : MonoBehaviour
{
    public CameraZoom cam;
    public GameObject b_punish;
    public GameObject b_spare;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cam.zoomActive) {
            b_punish.SetActive(true);
            b_spare.SetActive(true);
        }
        else {
            b_punish.SetActive(false);
            b_spare.SetActive(false);
        }
    }
}
