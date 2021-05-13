using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera c;
    public bool ZoomActive;
    public float Speed;
    public float spd;
    public Vector3 tempPos;

    private Vector3 start;
    private Vector3 des;
    public float fraction = 0;

    public GameObject p;
    public GameObject b;

    void Start() {
        c = Camera.main;
        start = new Vector3(c.transform.position.x, c.transform.position.y, c.transform.position.z);
        des = new Vector3(p.transform.position.x, p.transform.position.y, c.transform.position.z);
    }

    void Update() {
        des = new Vector3(p.transform.position.x, p.transform.position.y, c.transform.position.z);
        if (ZoomActive) {
            if (fraction < 1) {
                fraction += Time.deltaTime * Speed;
                c.transform.position = Vector3.Lerp(start, des, fraction);
                c.orthographicSize = Mathf.Lerp(c.orthographicSize, 200, spd);
            }
        }
        else {
            if (fraction > 1) {
                fraction = 0;
            }
            else if (c.transform.position != start){
                fraction += Time.deltaTime * Speed;
                c.transform.position = Vector3.Lerp(des, start, fraction);
                c.orthographicSize = Mathf.Lerp(c.orthographicSize, 320, spd);
            }
        }
              
    }
}
