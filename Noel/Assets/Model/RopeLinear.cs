using UnityEngine;

public class RopeLinear : MonoBehaviour
{
    Rope2D rope;
    LineRenderer line;

    void Awake()
    {
        rope = GetComponent<Rope2D>();
        line = GetComponent<LineRenderer>();

        line.enabled = true;
        line.positionCount = rope.segments.Length;
    }

    
    void Update()
    {
        for (int i = 0; i < rope.segments.Length; i++)
        {
            line.SetPosition(i, rope.segments[i].position);
        }
    }
}
