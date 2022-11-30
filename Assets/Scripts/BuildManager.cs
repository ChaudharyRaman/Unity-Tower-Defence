
using UnityEngine;


public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
     private void Awake() {
         if(instance!=null)
         {
             Debug.Log("more than one build manager in scene");
             return;
         }
         instance = this;
    }
    public GameObject standardTurrentPrefab;
    public GameObject missileLauncherPrefab;

    
   private TurretBluePrint turrentToBuild;
   
//    public GameObject getTurrentToBuild(){
//         return turrentToBuild;
//    }
public bool CanBuild{
    get{
        return turrentToBuild!=null;
    }
}
   public void SelectTurretToBuild(TurretBluePrint turret){
       Debug.Log(turret.prefab);
       turrentToBuild = turret;
   }
   
   public void BuildTurretOn(Node node){

       if(PlayerStats.money< turrentToBuild.cost){
           Debug.Log("Not enough money");
           return;
           
       }
    Debug.Log("building");
    PlayerStats.money-=turrentToBuild.cost;
    Debug.Log(turrentToBuild.prefab);
       GameObject turret  = Instantiate(turrentToBuild.prefab,node.GetBuildPosition(),Quaternion.identity) as GameObject; 
       
       node.turret = turret;

        Debug.Log("Turret to Build !"+ PlayerStats.money);
   }
}
