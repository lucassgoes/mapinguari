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
    [SerializeField] private GameObject m_MainCamera;
    [SerializeField] private GameObject m_PlayerFollowCamera;
    [SerializeField] private GameObject m_PlayerCameraRoot;  

    void Awake()
    {
        m_PlayerInput.enabled = false;
        m_StarterAssetsInputs.enabled = false;
        m_FirstPersonController.enabled = false;
        m_BasicRigidBodyPush.enabled = false;
        m_MainCamera.SetActive(false);
        m_PlayerFollowCamera.SetActive(false);
        m_PlayerCameraRoot.SetActive(false);
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
            m_MainCamera.SetActive(true);
            m_PlayerFollowCamera.SetActive(true);
            m_PlayerCameraRoot.SetActive(true);
        }
    }
}
