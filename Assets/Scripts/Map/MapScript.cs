using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField]
    private float Height;

    [SerializeField]
    private Transform FollowTaget;

    private void Awake()
    {
        Height = transform.position.y;
    }

    private void LateUpdate()
    {
        if (FollowTaget != null)
        {
            transform.position = new Vector3(FollowTaget.position.x, Height, FollowTaget.position.z);
        }
    }
 
}
