using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        //find the noise component on the camera
        noise = virtualCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void SetFollowTarget(Transform target)
    {
        //follows the player
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
    }

    public void SetShake(float intensity, float duration)
    {
        StartCoroutine(ShakeCoroutine(intensity, duration));
    }

    private IEnumerator ShakeCoroutine(float intensity, float duration)
    {
        //sets the shake amp and freq
        noise.AmplitudeGain = intensity;
        noise.FrequencyGain = intensity;

        yield return new WaitForSeconds(duration);

        //waits for a duration and stops shaking
        noise.AmplitudeGain = 0f;
        noise.FrequencyGain = 0f;
    }
}
