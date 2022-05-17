using UnityEngine;

public class ShipWeapon : BaseModule
{
    public override float GetBaseHealth()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialization(object module)
    {
        if (module is ShipWeaponSO shipWeapon)
            Debug.Log($"Я {this} включился. Мне передали модулить типа {shipWeapon.GetType()}");
    }
}
