using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform doorTransform;
    public float openAngle = 90f;
    public float speed = 2f;

    private bool isOpening = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        if (doorTransform == null)
            doorTransform = transform;

        closedRotation = doorTransform.rotation;
        openRotation = Quaternion.Euler(doorTransform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    private void Update()
    {
        if (isOpening)
        {
            doorTransform.rotation = Quaternion.Lerp(
                doorTransform.rotation,
                openRotation,
                Time.deltaTime * speed
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
        }
    }
}
