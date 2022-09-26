using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguimientoDeCamara : MonoBehaviour
{
   public GameObject objetivo;

   private float objetivo_posX;
   private float objetivo_posY;

   private float posX;
   private float posY;

   public float derechaMax;
   public float izquierdaMax;

   public float alturaMax;
   public float alturaMin;

   public float velocidad;
   public bool encendida = true;
   //public Transform objetivo;
   //private float distaciaObjetivoX = 22f;
   //private float velocidadCamara = 15f;
   //public bool suavizadoCamara = false; 
  
void Awake()
{
    posX = objetivo_posX + derechaMax;
    posY = objetivo_posY + alturaMin;
    transform.position = Vector3.Lerp(transform.position, new Vector3(posX,posY,-1),1);
}


void Move_Cam()
{
    if (encendida)
    {
        if (objetivo)
        {
            objetivo_posX = objetivo.transform.position.x;
            objetivo_posY = objetivo.transform.position.y;

            if (objetivo_posX > derechaMax && objetivo_posX < izquierdaMax)
            {
                posX = objetivo_posX;
            }
            if (objetivo_posY < alturaMax && objetivo_posY > alturaMin)
            {
                posY = objetivo_posY;
            }
        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX,posY,-1), velocidad*Time.deltaTime);
    }
}
    // Update is called once per frame
    void Update()
    {
        Move_Cam();
      //transform.position = objetivo.transform.position;
      //nuevaPosicion = this.transform.position;
      //nuevaPosicion.x = objetivo.transform.position.x - distaciaObjetivoX;
      //nuevaPosicion.y = objetivo.transform.position.y;

    }
}



