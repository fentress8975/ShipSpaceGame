using UnityEngine;

public class ShipHull : BaseModule
{
    public override float GetBaseHealth()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialization(object module)
    {
        if (module is ShipHullSO shipHull)
            Debug.Log($"Я {this} включился. Мне передали модулить типа {shipHull.GetType()}");
    }
}
