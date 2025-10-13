using UnityEngine;

/// <summary>
/// Used to link a bone in Mich-L character's rig, to UVs in the corresponding shader.
/// </summary>
[ExecuteInEditMode] 
public class SimpleRobotBonesToUV : MonoBehaviour
{
    public GameObject AnimatedBoneToLinkToUvs;
    public Material MaterialToAnimate;
    public string PropertyNameX;
    public string PropertyNameY;
    public float UvCenterOffsetFactor; // This value = 1/16 of the texture for a 8*8 Atlas = 0,0625
    private Transform AnimatedBoneTransform;
    private Vector3 LastPosition;

    private void Start()
    {
        AnimatedBoneTransform = AnimatedBoneToLinkToUvs.transform;
        LastPosition = AnimatedBoneTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 currentPosition = AnimatedBoneTransform.position;
        if (MaterialToAnimate != null && currentPosition != LastPosition)
        {
            MaterialToAnimate.SetFloat(PropertyNameX, -currentPosition.x + UvCenterOffsetFactor);
            MaterialToAnimate.SetFloat(PropertyNameY, currentPosition.y - UvCenterOffsetFactor);
            LastPosition = currentPosition;
        }
    }
}
