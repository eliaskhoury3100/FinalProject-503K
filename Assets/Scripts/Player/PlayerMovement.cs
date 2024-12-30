using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _translationSpeed = 1f;
    [SerializeField] private float _translationSprintSpeed = 2.5f;
    [SerializeField] private float _rotationSpeed = 100f;
    private float _zTranslation = 0f;


    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        // if Shift Key is pressed & movement is forward -> Sprint Speed
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetAxis("Vertical") >= 0)
            _zTranslation = Input.GetAxis("Vertical") * _translationSprintSpeed * Time.deltaTime;
        else
            _zTranslation = Input.GetAxis("Vertical") * _translationSpeed * Time.deltaTime;
        
        transform.Translate(0f, 0f, _zTranslation);
        return;
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        return;
    }
}