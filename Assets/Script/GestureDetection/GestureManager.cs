using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GestureManager : MonoBehaviour {

    public GameObject bodyTrigger;
    public List<Gesture> modelGesture;

 
    // Use this for initialization
    void Start () {
        
       /* List<GameObject>concernedPointsBalayage = new List<GameObject>();
        modelGesture = new List<Gesture>();
        concernedPointsBalayage.Add(HandRight);
        Gesture balayageDroite = new Gesture(,"balayage droit");
        
        balayageDroite.AddMotionToGameObject(HandRight, speedMin, new Vector3(1, 0), distanceMin, threshold,marginOfError);
        balayageDroite.AddMotionToGameObject(HandRight, speedMin, new Vector3(-1, 0), distanceMin, threshold,marginOfError);

        Gesture balayageGauche = new Gesture(concernedPointsBalayage, "balayage gauche");
        balayageGauche.AddMotionToGameObject(HandRight, speedMin, new Vector3(-1, 0), distanceMin, threshold, marginOfError);
        balayageGauche.AddMotionToGameObject(HandRight, speedMin, new Vector3(1, 0), distanceMin, threshold, marginOfError);

        Gesture praise = new Gesture(concernedPointsBalayage, "Praise the SUN");
        praise.AddMotionToGameObject(HandLeft, speedMin, new Vector3(0, 1), distanceMin, threshold, marginOfError);
        praise.AddMotionToGameObject(HandRight, speedMin, new Vector3(0, 1), distanceMin, threshold, marginOfError);


        modelGesture.Add(balayageDroite);
        modelGesture.Add(balayageGauche);
        modelGesture.Add(praise);*/
	}
	public void AddGesture()
    {

    }
	// Update is called once per frame
	void Update () {
		foreach(Gesture gesture in modelGesture)
        {
            if (GetComponent<KinectPointController>().Hand_Right.transform.position != new Vector3(0, 0, 0)
                && GetComponent<KinectPointController>().Elbow_Left.transform.position != new Vector3(0, 0, 0)
                && GetComponent<KinectPointController>().Hand_Left.transform.position != new Vector3(0, 0, 0))
            {
                if (bodyTrigger != null)
                {
                    bodyTrigger.GetComponent<Image>().color = Color.green;
                }
            }
            else
            {
                bodyTrigger.GetComponent<Image>().color = Color.red;
            }
            
            gesture.ActualiseValues(); //ON rajoute les dernières values dans le buffer
                                       //On regarde si ça correspond au motion en cours. Si oui on le continue, sinon on ne laisse que cette value dedans.
           // positionCount = gesture.positionCount;
            //currentMotion = gesture.currentMotion;
        }

	}
}
