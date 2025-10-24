using UnityEngine;
using NaughtyAttributes;

public class Rope2D : MonoBehaviour
{
    [SerializeField, Range(2, 50)] int segmentsCount = 2;

    public Transform pointA, pointB;
    public HingeJoint hingePrefab;

    [HideInInspector] public Transform[] segments;

    Vector3 GetSegmentPosition(int segmentsIndex)
    {
        Vector3 posA = pointA.position;
        Vector3 posB = pointB.position;

        float fraction = 1f / (float)segmentsCount;

        return Vector3.Lerp(posA, posB, fraction * segmentsIndex);
    }

    [Button]
    void GenerateRope()
    {
        DeleteSegments();

        segments = new Transform[segmentsCount];

        for (int i = 0; i < segmentsCount; i++)
        {
            var currJoint = Instantiate(hingePrefab, GetSegmentPosition(i), Quaternion.identity, this.transform);
            segments[i] = currJoint.transform;

            if (i > 0)
            {
                int prevIndex = i - 1;
                currJoint.connectedBody = segments[prevIndex].GetComponent<Rigidbody>();
            }
        }

        // Conecta o primeiro e último ponto
        if (segmentsCount > 0)
        {
            segments[0].GetComponent<HingeJoint>().connectedBody = pointA.GetComponent<Rigidbody>();
            segments[segmentsCount - 1].GetComponent<HingeJoint>().connectedBody = pointB.GetComponent<Rigidbody>();
        }
    }

    [Button]
    void DeleteSegments()
    {
        if (transform.childCount > 0)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
        segments = null;
    }

    private void OnDrawGizmos()
    {
        if (pointA == null || pointB == null) return;

        Gizmos.color = Color.magenta;

        for (int i = 0; i < segmentsCount; i++)
        {
            Vector3 posAtIndex = GetSegmentPosition(i);
            Gizmos.DrawSphere(posAtIndex, 0.05f);
        }
    }
}