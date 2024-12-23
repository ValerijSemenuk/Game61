using UnityEngine;
using DG.Tweening;

public class CubeController : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationDuration = 1f;
    [SerializeField] private Ease rotationEase = Ease.InOutBounce;

    [Header("Scale Settings")]
    [SerializeField] private float scaleDuration = 1f; // �������� ��������� ��� �������� �������
    [SerializeField] private Vector3 targetScale = new Vector3(2, 2, 2); // ֳ������ �����
    [SerializeField] private Ease scaleEase = Ease.InOutElastic; // �������� � �'���� �����

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log($"<color=blue>Button: 1</color> - <color=green>Rotating cube</color>");
            RotateCube();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log($"<color=blue>Button: 2</color> - <color=green>Scaling cube</color>");
            ScaleCube();
        }
    }

    private void RotateCube()
    {
        transform.DORotate(new Vector3(0, 360, 0), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(rotationEase)
            .OnComplete(() => Debug.Log("<color=green>Rotation complete!</color>"));
    }

    private void ScaleCube()
    {
        // ��������� �����������
        Sequence scaleSequence = DOTween.Sequence();
        Vector3 originalScale = transform.localScale;

        scaleSequence.Append(transform.DOScale(targetScale, scaleDuration).SetEase(scaleEase)) // ���������
                      .Append(transform.DOScale(originalScale, scaleDuration).SetEase(scaleEase)) // ���������
                      .OnComplete(() => Debug.Log("<color=green>Scale animation complete!</color>"));
    }
}
