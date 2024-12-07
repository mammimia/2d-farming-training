using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor.ShortcutManagement;
using UnityEngine;

[RequireComponent(typeof(GenerateGUID))]
public class SceneItemsManager : SingletonMonoBehavior<SceneItemsManager>, ISaveable
{

    private Transform parentItem;
    [SerializeField] private GameObject itemPrefab = null;

    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get => iSaveableUniqueID; set => iSaveableUniqueID = value; }

    private GameObjectSave GameObjectSave;
    public GameObjectSave gameObjectSave { get => GameObjectSave; set => GameObjectSave = value; }

    private void AfterSceneLoad()
    {
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParent).transform;
    }

    protected override void Awake()
    {
        base.Awake();

        iSaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }

    private void DestroySceneItems()
    {
        Item[] items = GameObject.FindObjectsOfType<Item>();

        foreach (Item item in items)
        {
            Destroy(item.gameObject);
        }
    }

    public void InstantiateSceneItem(ItemDetails itemDetail, Vector3 position)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, position, Quaternion.identity, parentItem);
        Item item = itemGameObject.GetComponent<Item>();
        item.ItemDetail = itemDetail;
    }

    private void InsantiateSceneItems(List<SceneItem> sceneItemList)
    {
        GameObject itemGameObject = null;

        foreach (SceneItem sceneItem in sceneItemList)
        {
            itemGameObject = Instantiate(itemPrefab, new Vector3(sceneItem.position.x, sceneItem.position.y, sceneItem.position.z), Quaternion.identity, parentItem);
            Item item = itemGameObject.GetComponent<Item>();
            item.ItemDetail = sceneItem.itemDetail;
        }
    }

    private void OnDisable()
    {
        ISaveableDeregister();
        EventHandler.afterSceneLoadEvent -= AfterSceneLoad;
    }

    private void OnEnable()
    {
        ISaveableRegister();
        EventHandler.afterSceneLoadEvent += AfterSceneLoad;
    }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance.saveables.Remove(this);
    }

    public void ISaveableRegister()
    {
        SaveLoadManager.Instance.saveables.Add(this);
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave) && sceneSave.sceneItems != null && sceneSave.sceneItems.TryGetValue("sceneItems", out List<SceneItem> sceneItems))
        {
            DestroySceneItems();
            InsantiateSceneItems(sceneItems);
        }
    }

    public void ISaveableStoreScene(string sceneName)
    {
        // Remove old scene data before storing new scene data
        GameObjectSave.sceneData.Remove(sceneName);

        List<SceneItem> sceneItemList = new List<SceneItem>();
        Item[] itemsInScene = GameObject.FindObjectsOfType<Item>();

        foreach (Item item in itemsInScene)
        {
            SceneItem sceneItem = new SceneItem();
            sceneItem.itemDetail = item.ItemDetail;
            sceneItem.position = new Vector3Serializable(item.transform.position);

            sceneItemList.Add(sceneItem);
        }

        SceneSave sceneSave = new SceneSave();
        sceneSave.sceneItems = new Dictionary<string, List<SceneItem>>
        {
            { "sceneItems", sceneItemList }
        };

        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }
}
