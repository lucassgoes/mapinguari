using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class ClientPlayerMove : NetworkBehaviour
{
    [SerializeField] private PlayerInput m_PlayerInput;
    [SerializeField] private StarterAssetsInputs m_StarterAssetsInputs;
    [SerializeField] private FirstPersonController m_FirstPersonController;
    [SerializeField] private BasicRigidBodyPush m_BasicRigidBodyPush;

    void Awake()
    {
        m_PlayerInput.enabled = false;
        m_StarterAssetsInputs.enabled = false;
        m_FirstPersonController.enabled = false;
        m_BasicRigidBodyPush.enabled = false;
    }

   public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        if (IsOwner)
        {
            m_PlayerInput.enabled = true;
            m_StarterAssetsInputs.enabled = true;
            m_FirstPersonController.enabled = true;
            m_BasicRigidBodyPush.enabled = true;
        }
    }
}
