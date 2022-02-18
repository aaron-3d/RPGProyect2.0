using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class Item : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public int cantidad = 1; //cantidad de cada objeto (20 pociones)
    public Text cantidadTexto;
    public int ID;
    public bool acumulable;
    public Button Boton;
    public GameObject _descripcion;
    public TextMeshPro Nombre_;
    public TextMeshPro Dato_;
    public Vector3 offset;
    public DataBase DB;
    void Start()
    {
        acumulable = DB.baseDatos[ID].acumulable;
        Boton = GetComponent<Button>();
        _descripcion = Inventario.Descripcion;
        Nombre_ = _descripcion.transform.GetChild(0).GetComponent<TextMeshPro>();
        Dato_ = _descripcion.transform.GetChild(1).GetComponent<TextMeshPro>();
        _descripcion.SetActive(false);
        if (!_descripcion.GetComponent<Image>().enabled) //en el caso de que el componente image no este activado, lo voy a activar.
        {
            _descripcion.GetComponent<Image>().enabled = true;
            Nombre_.enabled = true;
            Dato_.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //textoCantidad.text = cantidad.ToString();
        if(transform.parent.GetComponent<Image>() != null)
        {
            transform.parent.GetComponent<Image>().fillCenter = true;
        }

        cantidadTexto.text = cantidad.ToString();

        if(transform.parent == Inventario.canvas)
        {
            _descripcion.SetActive(false);
        }
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _descripcion.SetActive(true);
        Nombre_.text = DB.baseDatos[ID].nombre;
        Dato_.text = DB.baseDatos[ID].descripcion;
        _descripcion.transform.position = transform.position + offset;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _descripcion.SetActive(false);
    }
}
