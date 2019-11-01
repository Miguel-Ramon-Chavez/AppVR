using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCaminar : MonoBehaviour{
    public GameObject VisionVR;
    public const int AnguloRecto = 90;
    public bool EstaCaminando = false;
    public float Velocidad;
    public bool CaminarCuandoPulsamos;
    public bool CaminarCuandoMiramos;
    public double AnguloDelUmbra1;
    public bool CongelarLaPosicionY;
    public float CompensarY;
    void Update(){
        if (CaminarCuandoMiramos && !CaminarCuandoPulsamos && !EstaCaminando && VisionVR.transform.eulerAngles.x >= AnguloDelUmbra1 && VisionVR.transform.eulerAngles.x <= AnguloRecto){
            EstaCaminando = true;
        } else if (CaminarCuandoMiramos && !CaminarCuandoPulsamos && EstaCaminando && (VisionVR.transform.eulerAngles.x<= AnguloDelUmbra1 || VisionVR.transform.eulerAngles.x>= AnguloRecto)){
            EstaCaminando = false;
        }
        if (EstaCaminando){
            Caminar();
        }
        if (CongelarLaPosicionY){
            transform.position = new Vector3(transform.position.x, CompensarY, transform.position.z);
        }
    }
    public void Caminar() {
        Vector3 Direccion = new Vector3(VisionVR.transform.forward.x, 0, VisionVR.transform.forward.z).normalized * Velocidad * Time.deltaTime;
        Quaternion Rotacion = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        transform.Translate(Rotacion * Direccion);
    }
}
