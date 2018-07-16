using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScaleCamera : MonoBehaviour {

	// Target Size in Height (Portrait) or in Width (Landscape)
	public int targetSize = 960;
	// Sprites Pixels to Units
	public float pixelsToUnits = 100;

	// Rescale for Portrait (default) or Landscape
	public bool landscape = false;

	int newHeight;


	// Check for resolution changes
	Resolution newRes;

	void Awake ()
	{
		newRes = Screen.currentResolution;

		DebugSafe.Log("Current res: " + Screen.currentResolution.width + "x" + Screen.currentResolution.height);
	}

	void Update () {

		// Check if resolution has changed
		if(newRes.height != Screen.height || newRes.width != Screen.width)
		{
			// Rescale for Landscape
			if(landscape){
				newHeight = Mathf.RoundToInt (targetSize / (float)Screen.width * Screen.height);

				GetComponent<Camera>().orthographicSize = newHeight / pixelsToUnits / 2;
			}
			// Rescale for Portrait
			else{
				GetComponent<Camera>().orthographicSize = targetSize / (pixelsToUnits * 2);
			}	

			// Update new resolution
			newRes = Screen.currentResolution;
		}

	}
}
