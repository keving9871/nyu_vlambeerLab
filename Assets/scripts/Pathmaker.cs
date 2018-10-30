using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// MAZE PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you have extra time, complete the "extra tasks" to do at the very bottom


public class Pathmaker : MonoBehaviour {

   
    //Variables:
    private int counter = 0;
    public Transform[] floorPrefab;
    public Transform pathmakerSpherePrefab;
   // public List<Transform> myTileList = new List<Transform>();



   

	void Update () {

        int floorCount = GameObject.FindGameObjectsWithTag("Floor").Length;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("R is Pressed");
            SceneManager.LoadScene("mainLabScene");
        }

        Debug.Log("Floor Counter: " + floorCount);
        if (counter < 125 && floorCount < 500)
        {
            //Get a random number between 0 and 1
            float i = Random.Range(0.0f, 1.0f);
            // If the number is less than .25 move this way
            if (i < .31f)
            {
                gameObject.transform.localEulerAngles += new Vector3 (Random.Range(-20, 0), 0, Random.Range(1, 5));
            }
            // if the number is between .25 and .50 move this way
            else if (i > .31f &&  i  < .56f)
            {
                gameObject.transform.localEulerAngles += new Vector3 (Random.Range(10, -10), 0, Random.Range(-1, -5));
            }
            // if the number is .99 or 1 make a new pathmaker sphere
            else if (i > .99f)
            {
                Instantiate(pathmakerSpherePrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            }
            int randomIndex = Random.Range(0, floorPrefab.Length);
            Transform newClone = (Transform)Instantiate(floorPrefab[randomIndex], gameObject.transform.position, gameObject.transform.rotation);
            //Instantiate(floorPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            this.transform.Translate(3, 0, 0);
            counter++;
            //newClone.GetComponent<Renderer>().material.color = Color.magenta;
        }
        else { Destroy(gameObject); }
       
        //	See how many Floors there are in the console
        //Debug.Log("Floor Count:" + floorCount);
	}

} 


// STEP 3: =====================================================================================
// implement, test, and stabilize the system

//	IMPLEMENT AND TEST:
//	- save your scene!!! the code could potentially be infinite / exponential, and crash Unity
//	- put Pathmaker.cs on a sphere, configure all the prefabs in the Inspector, and test it to make sure it works
//	STABILIZE: 
//	- code it so that all the Pathmakers can only spawn a grand total of 500 tiles in the entire world; how would you do that?
//	- (hint: declare a "public static int" and have each Pathmaker check this "globalTileCount", somewhere in your code? if there are already enough tiles, then maybe the Pathmaker could Destroy my game object



// STEP 4: ======================================================================================
// tune your values...

// a. how long should a pathmaker live? etc.
// b. how would you tune the probabilities to generate lots of long hallways? does it work?
// c. tweak all the probabilities that you want... what % chance is there for a pathmaker to make a pathmaker? is that too high or too low?



// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable




// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)
