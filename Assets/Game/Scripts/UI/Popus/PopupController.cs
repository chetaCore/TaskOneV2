using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public CanvasGroup Curtain;
    [SerializeField] private Image _progressBar;
    [SerializeField] private TMP_Text _loadPercentages;

    public Image ProgressBar { get => _progressBar;}
    public TMP_Text LoadPercentages { get => _loadPercentages;}

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Curtain.alpha = 1f;
    }

    public void Hide()
    {
        var hideSeq = DOTween.Sequence();
        hideSeq.Append(Curtain.DOFade(0, 1f)).
            SetEase(Ease.Linear).
            OnComplete(() => hideSeq.Kill());
    }
}