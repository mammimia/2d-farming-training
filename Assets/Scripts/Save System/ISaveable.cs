using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    string ISaveableUniqueID { get; set; }

    GameObjectSave gameObjectSave { get; set; }

    void ISaveableRegister();

    void ISaveableDeregister();

    void ISaveableStoreScene(string sceneName);

    void ISaveableRestoreScene(string sceneName);
}
