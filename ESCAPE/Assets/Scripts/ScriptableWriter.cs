using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableWriter : MonoBehaviour
{
    // Here you drag in the ScriptableObject instance via the Inspector in Unity
    [SerializeField] private CarryOverScenes scriptable;

    public string scene;
    public GameObject cameraInstance;
    public GameObject player;
    public GameObject collectableInstance;

    private void Start()
    {
        StoreData(cameraInstance.GetComponent<Transform>(), player.GetComponent<Transform>(), collectableInstance.name);
    }

    public void StoreData(Transform cameraa, Transform player, string collectable)
    {
        scriptable.cameraOrientation = cameraa;
        scriptable.playerOrientation = player;

        Collectable c4 = new Collectable(collectable, scene);
        scriptable.allParts.Add(c4);
    }
}
