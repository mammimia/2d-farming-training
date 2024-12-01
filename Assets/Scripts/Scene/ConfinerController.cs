using UnityEngine;
using Cinemachine;
using System.Diagnostics;

public class ConfinerController : MonoBehaviour
{
    private void OnEnable()
    {
        EventHandler.afterSceneLoadEvent += SwitchConfiner;
    }

    private void OnDisable()
    {
        EventHandler.afterSceneLoadEvent -= SwitchConfiner;
    }

    private void SwitchConfiner()
    {
        PolygonCollider2D confiner = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();

        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = confiner;
        cinemachineConfiner.InvalidatePathCache();
    }
}
