using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BulletSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public float moveSpeed;
    public int numBounces;
}
