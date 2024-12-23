using UnityEngine;
using DG.Tweening;

public class CubeController : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationDuration = 1f;
    [SerializeField] private Ease rotationEase = Ease.InOutBounce;

    [Header("Scale Settings")]
    [SerializeField] private float scaleDuration = 1f; // Збільшена тривалість для повільнішої анімації
    [SerializeField] private Vector3 targetScale = new Vector3(2, 2, 2); // Цільовий розмір
    [SerializeField] private Ease scaleEase = Ease.InOutElastic; // Повільніша і м'якша крива

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
        // Створюємо послідовність
        Sequence scaleSequence = DOTween.Sequence();
        Vector3 originalScale = transform.localScale;

        scaleSequence.Append(transform.DOScale(targetScale, scaleDuration).SetEase(scaleEase)) // Збільшення
                      .Append(transform.DOScale(originalScale, scaleDuration).SetEase(scaleEase)) // Зменшення
                      .OnComplete(() => Debug.Log("<color=green>Scale animation complete!</color>"));
    }
}
