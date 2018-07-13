using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parrallaxing : MonoBehaviour {

    // This creates a list of Transform objects
    public Transform[] backgrounds;     //Array[] list of all background and foregrounds to be parallaxed
    private float[] parrallaxScales;     //The proportion the camera's movement to move backgrounds by
    public float smoothing = 1f;        //How smooth the paralaxing is going to be

    private Transform cam;              //Reference to the main camera's transform
    private Vector3 previousCamPos;     //Store the position of the camera in the previous frame


    // Is called before Start() but after the game-objects are set up
    // Great for references
    private void Awake(){
        //set up the camera reference
        cam = Camera.main.transform;
    }
   

    // Use this for initialization
    void Start () {
        //the previous frame had the current frame's camera positiopn
        previousCamPos = cam.position;

        parrallaxScales = new float[backgrounds.Length];

        //Assigning corresponding parrallaxScales
        for (int i = 0; i < backgrounds.Length; i++) {
            parrallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //for each background
        for (int i = 0; i < backgrounds.Length; i++) {
            //the parallax is the opposite of the camera movement bcs
            //the previous frame is multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parrallaxScales[i];
        }
	}
}
