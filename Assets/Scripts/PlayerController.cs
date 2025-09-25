using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundLayer))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default:
                    speed = 12;
                    break;
                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
            }
        }


        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
