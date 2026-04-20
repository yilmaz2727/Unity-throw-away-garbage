using UnityEngine;

public class TrajectoryPredictor : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] int segments = 20; // Yayýn kaç noktadan oluþacaðý

    void Start()
    {
        // Scriptin olduðu objede (sachuso) LineRenderer arar
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    // Atýþ gücü ve yönüne göre çizgiyi güncelleyen fonksiyon
    public void RenderTrajectory(Vector3 startPos, Vector3 velocity)
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = segments;
        Vector3[] points = new Vector3[segments];

        for (int i = 0; i < segments; i++)
        {
            float t = i * 0.1f; // Zaman adýmý
            // Fiziksel Atýþ Formülü: P = P0 + V0*t + 0.5 * g * t^2
            points[i] = startPos + velocity * t + 0.5f * Physics.gravity * t * t;
        }

        lineRenderer.SetPositions(points);
    }

    // Atýþ bitince veya iptal olunca çizgiyi gizle
    public void ClearTrajectory()
    {
        lineRenderer.enabled = false;
    }
}