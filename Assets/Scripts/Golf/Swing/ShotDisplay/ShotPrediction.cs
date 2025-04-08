using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ShotPrediction : MonoBehaviour
{
    public Rigidbody ball;
    public SwingPowerController powerController;
    public SwingAligner aligner;
    public float timeStep = 0.1f;
    public LayerMask collisionMask;

    private LineRenderer lineRenderer;

    [SerializeField] private float predictionLength = 2f; // max distance in units
    [SerializeField] private int numPoints = 10;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        PredictPath();
    }

    void PredictPath()
    {
        Vector3[] points = new Vector3[numPoints];
        Vector3 startPos = ball.position;
        Vector3 direction = aligner.GetShotDirection().normalized;

        float segmentLength = predictionLength / numPoints;
        for (int i = 0; i < numPoints; i++)
        {
            Vector3 point = startPos + direction * segmentLength * i;
            points[i] = point;

            if (i > 0 && Physics.Linecast(points[i - 1], point, out RaycastHit hit, collisionMask))
            {
                points[i] = hit.point;
                lineRenderer.positionCount = i + 1;
                break;
            }
        }

        lineRenderer.positionCount = numPoints;
        lineRenderer.SetPositions(points);
    }
}
