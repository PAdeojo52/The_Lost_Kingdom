using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPCamera : MonoBehaviour {

    public static float pixelsToUnit = 1f;
    public static float scale = 1f;
    public Vector2 nativerRsolution = new Vector2(240, 160);


	// Use this for initialization
	void Awake ()
    {
        var camera = GetComponent<Camera>();

        if (camera.orthographic)
        {
            scale = Screen.height / nativerRsolution.y;
            pixelsToUnit = scale;
            camera.orthographicSize = (Screen.height / 2.0f)/pixelsToUnit;
        }
		
	}
	
	// Update is called once per frame
}
