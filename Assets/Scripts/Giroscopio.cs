using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giroscopio : MonoBehaviour{
    public GameObject VRCamaras;
    private float PosicionInicialY = 0f;
    private float PosicionDelGyroEnY = 0f;
    private float CalibrarEnLaPosicionY = 0f;
    public bool SeInicioElJuego;
    void Start() {
        Input.gyro.enabled = true;
        PosicionInicialY = VRCamaras.transform.eulerAngles.y;
    }
    void Update() {
        AplicarRotacionDelGiroscopio();
        AplicarCalibracion();
        if (SeInicioElJuego == true){
            Invoke("CalibrarEnPosicionY", 3f);
            SeInicioElJuego = false;
        }
    }
    void AplicarRotacionDelGiroscopio(){
        VRCamaras.transform.rotation = Input.gyro.attitude;
        VRCamaras.transform.Rotate(0f, 0f, 180f, Space.Self);
        VRCamaras.transform.Rotate(90f, 180f, 0f, Space.World);
        PosicionDelGyroEnY = VRCamaras.transform.eulerAngles.y;
    }
    void CalibrarEnPosicionY(){
        CalibrarEnLaPosicionY = PosicionDelGyroEnY - PosicionInicialY;
    }
    void AplicarCalibracion(){
        VRCamaras.transform.Rotate(0f, -CalibrarEnLaPosicionY, 0f, Space.World);
    }
}
