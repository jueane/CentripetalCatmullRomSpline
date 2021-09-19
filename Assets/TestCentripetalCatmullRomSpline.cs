using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TestCentripetalCatmullRomSpline : MonoBehaviour
{
    // Use the transforms of GameObjects in 3d space as your points or define array with desired points
    public Transform[] points;

    // Parametric constant: 0.0 for the uniform spline, 0.5 for the centripetal spline, 1.0 for the chordal spline
    public float alpha = 0.5f;

    /////////////////////////////

    // How many points you want on the curve
    const int numberOfPoints = 1000;

    // Store points on the Catmull curve so we can visualize them
    List<CV2> newPoints = new List<CV2>(numberOfPoints);

    private void Start()
    {
    }

    void Update()
    {
        p0 = points[0].position.ToCV2(); // Vector3 has an implicit conversion to Vector2
        p1 = points[1].position.ToCV2();
        p2 = points[2].position.ToCV2();
        p3 = points[3].position.ToCV2();

        t0 = 0.0f;
        t1 = GetT(t0, p0, p1);
        t2 = GetT(t1, p1, p2);
        t3 = GetT(t2, p2, p3);

        newPoints.Clear();

        float step = 1f / numberOfPoints;

        for (float i = 0; i < 1; i += step)
        {
            CatmulRom(i);
            newPoints.Add(CC);
        }
    }

    CV2 p0;
    CV2 p1;
    CV2 p2;
    CV2 p3;

    float t0;
    float t1;
    float t2;
    float t3;

    CV2 A1;
    CV2 A2;
    CV2 A3;
    CV2 B1;
    CV2 B2;

    CV2 CC;

    void CatmulRom(float normal)
    {
        var t = t1 + (t2 - t1) * normal;

        A1 = (t1 - t) / (t1 - t0) * p0 + (t - t0) / (t1 - t0) * p1;
        A2 = (t2 - t) / (t2 - t1) * p1 + (t - t1) / (t2 - t1) * p2;
        A3 = (t3 - t) / (t3 - t2) * p2 + (t - t2) / (t3 - t2) * p3;
        B1 = (t2 - t) / (t2 - t0) * A1 + (t - t0) / (t2 - t0) * A2;
        B2 = (t3 - t) / (t3 - t1) * A2 + (t - t1) / (t3 - t1) * A3;
        CC = (t2 - t) / (t2 - t1) * B1 + (t - t1) / (t2 - t1) * B2;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    Vector2 Multiply(float len, Vector2 v2)
    {
        v2.x *= len;
        v2.y *= len;
        return v2;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    Vector2 Add(Vector2 v1, Vector2 v2)
    {
        v1.x += v2.x;
        v1.y += v2.y;
        return v1;
    }

    float GetT(float t, CV2 p0, CV2 p1)
    {
        float a = Mathf.Pow((p1.x - p0.x), 2.0f) + Mathf.Pow((p1.y - p0.y), 2.0f);
        float b = Mathf.Pow(a, alpha * 0.5f);

        return (b + t);
    }

    // Visualize the points
    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        for (int i = 0; i < newPoints.Count - 1; i++)
        {
            var p1 = newPoints[i].ToV3();
            var p2 = newPoints[i + 1].ToV3();
            Gizmos.DrawLine(p1, p2);
        }
    }
}
