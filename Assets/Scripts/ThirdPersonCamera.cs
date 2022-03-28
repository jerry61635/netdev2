using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Senstivity;
    }

    [SerializeField] MouseInput MouseControl;
    InputController playerInput;
    Vector2 mouseInput;

    Transform cameraLookTarget;
    Player localPlayer;


    private void Awake()
    {
        gameManager.Instance.OnLocalPlayerJoin += HandleOnLocalPlayerJoin;
    }

    void HandleOnLocalPlayerJoin(Player player)
    {
       localPlayer = player;
       cameraLookTarget = localPlayer.transform.Find("cameraLookTarget");

        if (cameraLookTarget == null)
            cameraLookTarget = localPlayer.transform;
    }

    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffset.z +
            localPlayer.transform.up * cameraOffset.y +
            localPlayer.transform.right * cameraOffset.x;

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
    }
}
