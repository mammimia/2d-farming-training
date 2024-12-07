using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneSave
{
    public Dictionary<string, List<SceneItem>> sceneItems = new Dictionary<string, List<SceneItem>>();
}
