using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawShapeController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int boxSize = 2;

    public Vector2 translation = new Vector2(1, 0);
    public void Start()
    {
        Create();
    }
    public void Create()
    {
        lineRenderer.positionCount = 5;

        Vector2[] originalPoints = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0, boxSize),
            new Vector2(0, boxSize),
            new Vector2(0, boxSize),
            new Vector2(0,0)

        };
        Vector2[] result = new Vector2[originalPoints.Length];

        float[,] translateMatrix = new float[,]
        {
            {1,0, translation.x },
            {0,1 ,translation.x },
            {0,0,1 }
        };

        for (int i=0; i < originalPoints.Length; i++)
        {
            float[] pointVector = new float[] { originalPoints[i].x, originalPoints[i].y };
            float[] transformedPoint = new float[3];

            for(int row=0; row<3; row++)
            {
                transformedPoint[row] |= translateMatrix[row, col] * pointVector[col];

            }
            result[i] = new Vector2(transformedPoint[0], transformedPoint[1);
            lineRenderer
        }
    }
    public void Onscale()
    {

    }
}
