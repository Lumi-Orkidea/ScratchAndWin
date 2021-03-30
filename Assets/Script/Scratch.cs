using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This was largely done by followin the tutorial of DanteT92 on Unity forums
// https://forum.unity.com/threads/tutorial-scratch-card-or-scratch-and-win-effect.1036090/
public class Scratch : MonoBehaviour
{
    public List<LineRenderer> lineRenderers = new List<LineRenderer>();
    public List<List<Vector3>> allLinePoints = new List<List<Vector3>>();
    public Material lineMaterial;

    private LineRenderer currentLineRenderer;
    private List <Vector3> currentLinePoints = new List<Vector3>();
    private int lineCount = 0;

    /*
     * Generates a newLinge for the line renderer to render
     */
    public void NewLine()
    {
        GameObject newGameObject = new GameObject();
        LineRenderer newLineRenderer;
        newLineRenderer = newGameObject.AddComponent<LineRenderer>();
        newLineRenderer.positionCount = 0;
        newLineRenderer.startColor = Color.white;
        newLineRenderer.endColor = Color.white;
        newLineRenderer.startWidth = 0.4f;
        newLineRenderer.endWidth = 0.4f;
        newLineRenderer.useWorldSpace = true;
        newLineRenderer.material = lineMaterial;

        lineRenderers.Add(newLineRenderer);

        List<Vector3> linePoints = new List<Vector3>();

        allLinePoints.Add(linePoints);
    }

    /*
     * The actual "erasing" of the scratchable surface
     */ 
    void Update()
    {
        //Checks when we are touching the screen and  gets the touch
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //When finger first time touches the screen we'll generate a new line
            if (touch.phase == TouchPhase.Began) 
            {
                lineCount += 1;
                NewLine();
                currentLinePoints = allLinePoints[lineCount - 1];
                currentLineRenderer = lineRenderers[lineCount - 1];
            }
            //When finger is moved we draw the lines using the transparent material.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch.position);

                worldPos.z = -8;

                if (currentLinePoints.Contains(worldPos) == false)
                {
                    currentLinePoints.Add(worldPos);

                    currentLineRenderer.positionCount = currentLinePoints.Count;
                    currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, worldPos);
                }
            }
        }
    }
}
