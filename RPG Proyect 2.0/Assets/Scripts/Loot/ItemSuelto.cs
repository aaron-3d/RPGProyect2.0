using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSuelto : MonoBehaviour
{
    public int cantidad;
    public int ID;
    public Inventario Inv;

    public void Start()
    {
        Inv = InstanceManager.Instance.Inv1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //ItemSuelto itSuelto = Inv.itemsSueltos.Find(x => x.ID == this.ID);
            Inv.AgregarItem(ID, cantidad);
            
            Destroy(this.gameObject);
            /*if (itSuelto != null && Inv.item.DB.baseDatos[itSuelto.ID].acumulable)
            {
                itSuelto.cantidad += this.cantidad;
            }
            else
            {
                Inv.itemsSueltos.Add(this);
            }
            if (!this.gameObject.name.Contains("(Clone)") || itSuelto == null)
            {
                transform.SetParent(other.transform);
            }
            else
            {
                //Inv.copiasItemsSueltos.Remove(this);
                Destroy(this.gameObject);
            }

            var jug = other.GetComponent<MovimientoJugador>();
            



            //transform.SetParent(other.transform);
            //Inv.itemsSueltos.Add(this);

            //gameObject.SetActive(false);
            Destroy(this.gameObject);*/
        }
    }
}


