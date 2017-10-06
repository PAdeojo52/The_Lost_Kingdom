using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

    public int textureSize = 32;
	// Use this for initialization
	void Start ()
    {

        var newWidth = Mathf.Ceil(Screen.width / (textureSize * PPCamera.scale/2));
        var newHeight = Mathf.Ceil(Screen.height / (textureSize * PPCamera.scale/2));


        transform.localScale = new Vector3(newWidth * textureSize,newHeight*textureSize,1);

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
