using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerShip m_PlayerShip;
    void Start()
    {
        m_PlayerShip.Initialization();
    }

   
}
