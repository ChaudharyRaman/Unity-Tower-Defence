using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    BuildManager buildManager;
    private void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret(){
        //Debug.Log("Standard Turret Purchase");
        buildManager.SelectTurretToBuild(standardTurret);

    }
    public void SelectMissileLauncher(){
       // Debug.Log("Missle Launcher Selected");
       buildManager.SelectTurretToBuild(missileLauncher);
    }
}
