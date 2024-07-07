
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private GameObject apple; 
    [SerializeField] private AudioClip jumpSound;

    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    private AudioSource _audioSource;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() => jumpButton.action.performed += Jumping;

    private void OnDisable() => jumpButton.action.performed -= Jumping;

    public void Jumping(InputAction.CallbackContext obj)
    {
        if (!_characterController.isGrounded) return;
        //Debug.Log("Character is grounded. Jumping!");
        _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

        //Sound abspielen
        PlayJumpSound();
    }

    private void Update()
    {
        if(_characterController.isGrounded && _playerVelocity.y<0)
        {
            _playerVelocity.y = 0f;
        }

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);

        //Debug.Log("Vertikale Geschwindigkeit: " + _playerVelocity.y);
        //Debug.Log("Position: " + transform.position);

        // Debug-Logs hinzufügen
        /*Debug.Log("isGrounded: " + _characterController.isGrounded);
        Debug.Log("Player Velocity: " + _playerVelocity);
        Debug.Log("Player Position: " + transform.position);*/
    }

    public void SetJumpHeight(float newJumpHeight)
    {
        jumpHeight = newJumpHeight;
        Debug.Log("Neue Sprunghöhe gesetzt: " + newJumpHeight);

        if(apple != null)
        {
            apple.SetActive(false);
        }
    }

    public void PerformJump(float jumpForce)
    {
        if (_characterController.isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpForce * -3.0f * gravityValue);


            Debug.Log($"Sprung ausgelöst: neue Y-Geschwindigkeit = {_playerVelocity.y}");
        }
    }

    private void PlayJumpSound()
    {
        if (_audioSource != null && jumpSound != null)
        {
            _audioSource.PlayOneShot(jumpSound);
        }
    }

}
