using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera c;
    public CalculationController calcController;
    public GameObject focus;

    public bool zoomActive;
    public float panSpeed;
    public float zoomSpeed;
    public float camDistance;

    private Vector3 start;
    private Vector3 des;
    private float fraction = 0;

    public SFX sfx;

    void Start() {
        c = Camera.main;
        start = new Vector3(c.transform.position.x, c.transform.position.y, c.transform.position.z);
        des = new Vector3(focus.transform.position.x, focus.transform.position.y, c.transform.position.z);
    }

    void Update() {
        des = new Vector3(focus.transform.position.x, focus.transform.position.y, c.transform.position.z);
        //ASTEROID
        if (focus.gameObject.CompareTag("Asteroid")) {
            if(zoomActive) {
                if(fraction < 1) {
                    fraction += Time.deltaTime * panSpeed;
                    c.transform.position = Vector3.Lerp(start, des, fraction);
                    c.orthographicSize = Mathf.MoveTowards(c.orthographicSize, 150, zoomSpeed * 1.4f);
                    sfx.zoomIn();
                }
                if(c.orthographicSize < 250) {
                    c.transform.position = focus.transform.position + new Vector3(camDistance, 5, -2);
                }
            }
            else {
                if (fraction > 1) {
                    fraction = 0;
                }
                else if (c.transform.position != start) {
                    fraction += Time.deltaTime * panSpeed;
                    c.transform.position = Vector3.Lerp(des, start, fraction);
                    c.orthographicSize = Mathf.MoveTowards(c.orthographicSize, 320, zoomSpeed * 1.4f);
                    sfx.zoomOut();
                }
            }
        }
        //PLANET
        else {
            if (zoomActive) {
                if (fraction < 1) {
                    fraction += Time.deltaTime * panSpeed;
                    c.transform.position = Vector3.Lerp(start, des, fraction);
                    c.orthographicSize = Mathf.MoveTowards(c.orthographicSize, 200, zoomSpeed);
                    sfx.zoomIn();
                }
            }
            else {
                if (fraction > 1) {
                    fraction = 0;
                }
                else if (c.transform.position != start) {
                    fraction += Time.deltaTime * panSpeed;
                    c.transform.position = Vector3.Lerp(des, start, fraction);
                    c.orthographicSize = Mathf.MoveTowards(c.orthographicSize, 320, zoomSpeed);
                    sfx.zoomOut();
                }
            }
        }
    }

    public void punish() {
        zoomActive = false;
        calcController.addTotalPunished(focus);
    }

    public void spared() {
        zoomActive = false;
    }
}
