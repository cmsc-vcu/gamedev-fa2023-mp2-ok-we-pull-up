using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// fileName is the default name when creating a new Instance
// menuName is where to find it in the context menu of Create
[CreateAssetMenu(fileName = "DataCarriedOver", menuName = "Scripts/CarryOverScenes")]
public class CarryOverScenes : ScriptableObject
{
    // between each scene, what do I need to carry over?
    // PLAYER DETAILS
    //     the direction the player is facing
    //     the orientation of camera angle
    public Transform cameraOrientation = null;
    public Transform playerOrientation = null;
    
    // EVENTS
    //     each collectable + a bool for if it's been collected
    //     a bool for if you are ready to escape
    //     a bool for if the specialItem was picked up
    public List<Collectable> allParts = new List<Collectable>();
    private bool ableToEscape = false;
    private bool trueEnding = false;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;        
    }

    private void OnDestroy()
    {
        
    }
    
    public void updateCollectable(string name, bool collect){
        foreach(Collectable part in allParts){
            if(part.getName() == name){
                part.setCollected(collect);
            }
        }
        foreach(Collectable part in allParts){
            if(!part.isCollected()){
                return;
            }
        }
        ableToEscape = true;
    }

    public void findSecret(){
        trueEnding = true;
    }

    public bool escape()
    {
        return ableToEscape;
    }

    public bool secretEscape()
    {
        return trueEnding;
    }

    public void resetAll()
    {
        cameraOrientation = null;
        playerOrientation = null;
        allParts = new List<Collectable>();
        ableToEscape = false;
        trueEnding = false;
    }
}

public class Collectable
{
    private string name;
    private string sceneLocatedIn;
    private bool collected;

    public Collectable(){
        this.name = "objName";
        this.sceneLocatedIn = "scene";
        this.collected = false;
    }

    public Collectable(string objName, string scene){
        this.name = objName;
        this.sceneLocatedIn = scene;
        this.collected = false;
    }

    public Collectable(string objName, string scene, bool collect){
        this.name = objName;
        this.sceneLocatedIn = scene;
        this.collected = collect;
    }

    public void setName(string objName){
        this.name = objName;
    }
    public string getName(){
        return this.name;
    }

    public void setScene(string scene){
        this.sceneLocatedIn = scene;
    }
    public string getScene(){
        return this.sceneLocatedIn;
    }

    public void setCollected(bool collect){
        this.collected = collect;
    }
    public bool isCollected(){
        return this.collected;
    }
}