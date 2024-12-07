using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : SingletonMonoBehavior<SaveLoadManager>
{
    public List<ISaveable> saveables;

    protected override void Awake()
    {
        base.Awake();

        saveables = new List<ISaveable>();
    }

    public void StoreCurrentSceneData()
    {
        foreach (ISaveable saveable in saveables)
        {
            saveable.ISaveableStoreScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestoreCurrentSceneData()
    {
        foreach (ISaveable saveable in saveables)
        {
            saveable.ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }
}
