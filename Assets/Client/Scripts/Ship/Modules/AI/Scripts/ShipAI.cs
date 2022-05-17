using UnityEngine;

public class ShipAI : BaseModule
{
    public override float GetBaseHealth()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialization(object module)
    {
        if (module is ShipAISO shipAI)
            Debug.Log($"Я {this} включился. Мне передали модулить типа {shipAI.GetType()}");
    }
}
