using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntarProyectil : MonoBehaviour
{
    [SerializeField] private GameObject proyectil;
    [SerializeField] private int danioAtaque = 1;
    [SerializeField] private float velocidadProyectil = 10f;
    [SerializeField] private float offset = -360;
    private float angle;

    [Header("Referencias a componentes")]
    private Rigidbody2D rb;
    //-----

    private Transform aimTransform;
    [SerializeField] private Transform shotPoint;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }
    private void Update()
    {
        HandleAiming();
        Disparar();
    }

    private void HandleAiming() 
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle + offset);
    }

    private void Disparar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject go = Instantiate(proyectil, shotPoint.position, Quaternion.identity);
            go.GetComponent<Proyectil>().danio = danioAtaque;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Sign(rb.velocity.x) * velocidadProyectil, Mathf.Sign(rb.velocity.y) * velocidadProyectil));
            //go.GetComponent<Rigidbody2D>().AddForce();
            //Rigidbody2D rigidbody = go.GetComponent<Rigidbody2D>();
            //rigidbody.velocity = rigidbody.f * velocidadProyectil;
        }
    }

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) 
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

}
