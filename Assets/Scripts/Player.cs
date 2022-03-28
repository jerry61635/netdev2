using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Senstivity;
    }

    [SerializeField] float speed;
    [SerializeField] MouseInput MouseControl;

    InputController playerInput;
    Vector2 mouseInput;

    private PlayerMoveControl m_moveControl;
    public PlayerMoveControl moveControl
    {
        get
        {
            if (m_moveControl == null)
                m_moveControl = GetComponent<PlayerMoveControl>();
            return m_moveControl;
        }
    }

    private void Awake()
    {
        playerInput = gameManager.Instance.inputController;
        gameManager.Instance.LocalPlayer = this;

    }
    private void Start()
    {

    }

    private void Update()
    {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        moveControl.Move(direction);

        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Senstivity.x);
    }
}
