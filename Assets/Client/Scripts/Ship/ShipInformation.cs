using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBase.Containers
{
    public class ShipInformation
    {
        public string m_sName { get; set; }
        public float m_fHealth { get; set; }
        public float m_fWeight { get; set; }
        public float m_fCapacity { get; set; }
        public int m_iWeaponsMountsPositions { get; set; }
        public int m_iEnginesMountsPositions { get; set; }
        public int m_iShieldsMountsPositions { get; set; }
        public int m_iStoragesMountsPositions { get; set; }
        public int m_iAIMountsPositions { get; set; }
        public float m_fAccelerationPower { get; set; }
        public float m_fRotationPower { get; set; }
    }

    public class ShipWeaponsInformation
    {
        public WeaponType m_WeaponType { get; set; }
        public float m_fRateOfFire { get; set; }
        public int m_iDamage { get; set; }
        public int m_fSpeed { get; set; }
    }
}
