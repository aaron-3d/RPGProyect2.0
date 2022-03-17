using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CartelEliminacion : MonoBehaviour
{
    [SerializeField]
    Inventario Inv;
    public Slider slider;
    public Text cantidadText;

    private void Start()
    {
        Inv = GameObject.Find("Inv").GetComponent<Inventario>();
    }
    private void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            slider.maxValue = Inv.OSC;
            cantidadText.text = slider.value.ToString();
        }
    }

    public void Aceptar()
    {
        Inv.EliminarItem(Inv.OSID, Mathf.RoundToInt(slider.value));
        Debug.Log("Se Acepto Eliminar: " + Mathf.RoundToInt(slider.value) + " item/s con ID: " + Inv.OSID);
        slider.value = 1;
        this.gameObject.SetActive(false);
    }
    public void Cancelar()
    {
        slider.value = 1;
        this.gameObject.SetActive(false);
    }
}
