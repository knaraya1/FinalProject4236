using UnityEngine;

public class CameraLean : MonoBehaviour
{
    public PlayerController playerMovement;

    public float targetLeanAngle = 15f;
    public float leanSpeed = 5f;
    private Vector3 normalLocalPosition;

    bool isLeaning;
    bool isLeaning2;

    void FixedUpdate()
    {
        isLeaning = Input.GetKey(KeyCode.E);

        float target = isLeaning ? targetLeanAngle : 0f;

        playerMovement.currentLeanAngle =
            Mathf.Lerp(
                playerMovement.currentLeanAngle,
                target,
                leanSpeed * Time.deltaTime);

        Vector3 targetPos = isLeaning
            ? normalLocalPosition + new Vector3(0.5f, 0f, 0f)
            : normalLocalPosition;

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetPos,
            leanSpeed * Time.deltaTime);

//-------------------------------------------
         isLeaning2 = Input.GetKey(KeyCode.Q);

        target = isLeaning2 ? -targetLeanAngle : 0f;

        playerMovement.currentLeanAngle =
            Mathf.Lerp(
                playerMovement.currentLeanAngle,
                target,
                leanSpeed * Time.deltaTime);

        Vector3 targetPos2 = isLeaning2
            ? normalLocalPosition + new Vector3(-0.5f, 0f, 0f)
            : normalLocalPosition;

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetPos2,
            leanSpeed * Time.deltaTime);   

    }
}
