using UnityEngine;

public class ShipStorage : BaseModule
{
    public override float GetBaseHealth()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialization(object module)
    {
        if (module is ShipStorageSO shipStorage)
            Debug.Log($"Я {this} включился. Мне передали модулить типа {shipStorage.GetType()}");
    }
}
