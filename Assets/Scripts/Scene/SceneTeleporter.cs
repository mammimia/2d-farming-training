using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTeleporter : MonoBehaviour
{
    [SerializeField] private SceneName sceneNameToGo = SceneName.Scene1_Farm;
    [SerializeField] private Vector2 spawnPosition = Vector3.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            float xPosition = Mathf.Approximately(spawnPosition.x, 0f) ? player.transform.position.x : spawnPosition.x;
            float yPosition = Mathf.Approximately(spawnPosition.y, 0f) ? player.transform.position.y : spawnPosition.y;
            float zPosition = 0f;

            SceneController.Instance.FadeAndLoadScene(sceneNameToGo.ToString(), new Vector3(xPosition, yPosition, zPosition));
        }
    }
}
