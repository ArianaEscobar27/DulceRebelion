using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlDelPersonaje : MonoBehaviour
{
    //public float velocidadDeMovimiento = 5f;
    [SerializeField] private float Velocidad = 5f;
    private float desplazamientoX, desplazamientoY;
    private Vector2 direccionDeMomiento;
    private Rigidbody2D rbPersonaje;
    private Animator galletitaVengadoraAnimator;

    // Start is called before the first frame update
    void Start()
    {
      rbPersonaje = GetComponent <Rigidbody2D>();  
      galletitaVengadoraAnimator = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CapturaDePulsaciones();


    }

    private void FixedUpdate()
    {
        MovimientoDelPersonaje();
    }

    void CapturaDePulsaciones()
    {
        float desplazamientoX = Input.GetAxisRaw("Horizontal");
        float desplazamientoY = Input.GetAxisRaw("Vertical");
        direccionDeMomiento = new Vector2(desplazamientoX, desplazamientoY).normalized;
        galletitaVengadoraAnimator.SetFloat("Horizontal",desplazamientoX);
        galletitaVengadoraAnimator.SetFloat("Vertical",desplazamientoY);
        galletitaVengadoraAnimator.SetFloat("Velocidad",direccionDeMomiento.sqrMagnitude);

    }

    void MovimientoDelPersonaje()
    {
        rbPersonaje.velocity = new Vector2(direccionDeMomiento.x * Velocidad,
            direccionDeMomiento.y * Velocidad);
    }
}
