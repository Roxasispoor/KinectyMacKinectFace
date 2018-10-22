using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Gesture
{
    public string name;
    public List<GameObjectAndMotions> motions;
    public GameObject trigger;
    private bool detected;
    private float displayBuffer;
    //   int totalDetected = 0;

    // Use this for initialization
    public Gesture(List<GameObject> concernedPoints, string name)
    {
        this.name = name;
        motions = new List<GameObjectAndMotions>();
        foreach (GameObject point in concernedPoints)
        {
            motions.Add(new GameObjectAndMotions(point, new List<Motion>()));
        }

    }
    public void AddMotionToGameObject(GameObject obj, float speedMin, Vector3 direction, float distanceMin, float threshold, Vector3 marginOfError)
    {

        FindInMotions(obj).Add(new Motion(speedMin, direction, distanceMin, threshold, marginOfError));
    }


    public List<Motion> FindInMotions(GameObject point)
    {
        foreach (GameObjectAndMotions goam in motions)
        {
            if (goam.point == point)
            {
                return goam.motions;
            }
        }
        Debug.Log("GameObject not found in Gesture.Find()!");
        return null;
    }

    public void ActualiseValues()
    {
        if (Time.fixedTime > displayBuffer)
        {
            trigger.GetComponent<Image>().color = Color.white;
        }
        foreach (GameObjectAndMotions goam in motions)
        {

            // if(motions[point][currentMotion].NewBelongs(point.transform.position,position[point][position[point].Count]))//si il appartient bien on l'ajoute
            //{
            goam.Positions.Add(goam.point.transform.position);
            if (goam.Positions.Count > 1)
            {
                if (goam.motions[goam.currentMotion].NewBelongs(goam.point.transform.position, goam.Positions[goam.Positions.Count - 2],
                    goam.Positions[0], goam.currentMotion)) //Si la distance est supérieure a la distance min du motion on passe au suivant
                {
                    if (goam.currentMotion == goam.motions.Count - 1 &&
                        (goam.Positions[goam.Positions.Count - 1] - goam.Positions[0]).magnitude > goam.motions[goam.currentMotion].distanceMin) // Si c'était le dernier
                    {
                        goam.alreadyDetected = true;
                        goam.timeDetected = Time.fixedTime;
                        goam.Positions.Clear();
                        goam.currentMotion = 0;

                        //Debug.Log(name+" détecté");

                    }
                }

                else
                {
                    if (goam.currentMotion < goam.motions.Count - 1 && (goam.motions[goam.currentMotion + 1].NewBelongs(goam.point.transform.position,
                        goam.Positions[goam.Positions.Count - 1], goam.Positions[0], goam.currentMotion)) &&
                        (goam.Positions[goam.Positions.Count - 2] - goam.Positions[0]).magnitude > goam.motions[goam.currentMotion].distanceMin) // on est dans le mouvement d'après et on avait fais assez
                    {
                        goam.currentMotion++;
                        goam.Positions.Clear();
                        goam.Positions.Add(goam.point.transform.position);
                    }
                    else
                    {
                        goam.Positions.Clear();
                        //   Debug.Log("connard, suis le mouvement!");
                        if (goam.timeDetected + goam.timeBuffer < Time.deltaTime)
                        {
                            goam.alreadyDetected = false;
                        }

                        goam.currentMotion = 0;

                    }
                }

            }

        }
        bool detectedAll = true;
        foreach (GameObjectAndMotions goam in motions)
        {
            if (!goam.alreadyDetected)
            {
                detectedAll = false;
                displayBuffer = Time.fixedTime + 2;
            }

        }
        if (detectedAll)
        {
            if(name == "Show me your moves")
            {
                SceneManager.LoadScene("Main Menu");
            }
            Debug.Log(name + " détecté");
            if (trigger != null)
            {
                trigger.GetComponent<Image>().color = Color.green;                
            }   
            foreach (GameObjectAndMotions goam in motions)
            {
                goam.alreadyDetected = false;
                                 
            }
        }
    }
}

