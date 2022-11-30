
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
   [Header("Optional")] public GameObject turret;
    //public BuildManager  buildManager;        if we do this then all the node will that different build managaer which is a prob
    public Color hoverColor;
    public Vector3 offset;
    private Renderer rend;

    private Color startColor;
    private BuildManager buildManager;
    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown(){
        if(!buildManager.CanBuild) return;
        if(turret!=null){
            Debug.Log("Cant built their!! -");
            return;
        }
        
        //Built a turrent...
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
      
       buildManager.BuildTurretOn(this);
        
    }
    void OnMouseEnter(){
        
        if(!buildManager.CanBuild) return; 
        rend.material.color = hoverColor;
    }   
    void OnMouseExit(){
        rend.material.color = startColor;
    }
    public Vector3 GetBuildPosition(){
        return transform.position+offset;
    }
}
