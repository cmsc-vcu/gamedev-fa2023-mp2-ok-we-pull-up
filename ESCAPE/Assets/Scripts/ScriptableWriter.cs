using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//should be put as a component onto Player
public class ScriptableWriter : MonoBehaviour
{
    // Here you drag in the ScriptableObject instance via the Inspector in Unity
    [SerializeField] private CarryOverScenes scriptable;

    public string scene;
    public GameObject cameraInstance;
    public GameObject collectableInstance;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        StoreData(cameraInstance.GetComponent<Transform>(), GetComponent<Transform>(), collectableInstance.name);
    }

    public void StoreData(){
        scriptable.cameraOrientation = cameraInstance.GetComponent<Transform>();
        scriptable.playerOrientation = GetComponent<Transform>();

        foreach(Collectable part in scriptable.allParts){
            if(part.getName() == collectableInstance.name){
                return;
            }
        }
        Collectable c4 = new Collectable(collectableInstance.name, scene);
        scriptable.allParts.Add(c4);
    }

    public void StoreData(Transform cameraa, Transform player, string collectable)
    {
        scriptable.cameraOrientation = cameraa;
        scriptable.playerOrientation = player;

        foreach(Collectable part in scriptable.allParts){
            if(part.getName() == collectable){
                return;
            }
        }
        Collectable c4 = new Collectable(collectable, scene);
        scriptable.allParts.Add(c4);
    }

    public void CollectItem(int input){
        if(input == 1){
            scriptable.UpdateCollectable(scene, true);
        }
        else{
            scriptable.UpdateCollectable(scene, false);
        }
    }

    public void Reset(){
        scriptable.ResetAll();
    }
}
