using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour {

    List<Gesture> modelGesture;
    public GameObject Hand;
    public float threshold;
    public float speedMin;
    public float distanceMin;
    public Vector3 marginOfError;
	// Use this for initialization
	void Start () {;
        List<GameObject>concernedPoints = new List<GameObject>();
        modelGesture = new List<Gesture>();
        concernedPoints.Add(Hand);
        Gesture balayageDroite = new Gesture(concernedPoints);
        balayageDroite.AddMotionToGameObject(Hand, speedMin, new Vector3(1, 0), distanceMin, threshold,marginOfError);
        modelGesture.Add(balayageDroite);
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Gesture gesture in modelGesture)
        {
            gesture.ActualiseValues(); //ON rajoute les dernières values dans le buffer
            //On regarde si ça correspond au motion en cours. Si oui on le continue, sinon on ne laisse que cette value dedans.
        }

	}
}
