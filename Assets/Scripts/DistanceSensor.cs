﻿using UnityEngine;

public class DistanceSensor : MonoBehaviour
{
    public float m_MaxDistance = 4.0f;
    public LayerMask m_LayerMask;
    public Color m_RayColorWithCollision = Color.red;
    public Color m_RayColorWithoutCollision = Color.green;

    public float Distance { get; set; }
    public bool Detected => Distance < m_MaxDistance;

    public void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), m_MaxDistance, m_LayerMask);
        Distance = hit.collider ? hit.distance : m_MaxDistance;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * Distance, Detected ? m_RayColorWithCollision : m_RayColorWithoutCollision);
    }
}