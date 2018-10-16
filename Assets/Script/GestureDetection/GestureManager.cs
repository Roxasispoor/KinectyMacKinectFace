using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour {

    List<Gesture> modelGesture;
    public GameObject Hand;
	// Use this for initialization
	void Start () {
        Gesture balayageDroite = new Gesture();
        balayageDroite.AddMotionToGameObject(Hand, 0.1f, new Vector3(1, 0),0.1f);
		
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
