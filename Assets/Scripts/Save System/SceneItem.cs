using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneItem
{
    public ItemDetails itemDetail;
    public Vector3Serializable position;


    public SceneItem()
    {
        position = new Vector3Serializable();
    }
}
