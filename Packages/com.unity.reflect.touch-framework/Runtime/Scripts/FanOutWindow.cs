using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Unity.TouchFramework
{
    /// <summary>
    /// Component for handling the visibility and interactivity of a window represented by a <see cref="Canvas"/>.
    /// </summary>
    [ExecuteAlways]
    public class FanOutWindow : MonoBehaviour, IDialog
    {
        bool m_Open;
#pragma warning disable CS0649
        [SerializeField]
        Canvas m_Canvas;
        [SerializeField]
        CanvasGroup m_CanvasGroup;
#pragma warning restore CS0649
        FloatTween m_OpenDialogTween;
        FloatTween m_CloseDialogTween;
        TweenRunner<FloatTween> m_TweenRunner;

        public bool open => m_Open;

        public UnityEvent dialogClose { get; } = new UnityEvent();

        public UnityEvent dialogOpen { get; } = new UnityEvent();

        public void Open(bool instant = false, bool setInteractable = true)
        {
            if (!m_Open)
                dialogOpen.Invoke();

            m_Open = true;

            if (instant || !Application.isPlaying)
            {
                OnOpenTransitionComplete();
            }
            else
            {
                SetInteractable(setInteractable);

                m_OpenDialogTween.startValue = m_CanvasGroup.alpha;
                m_OpenDialogTween.targetValue = 1f;
                m_TweenRunner.StartTween(m_OpenDialogTween, EaseType.EaseInCubic);
            }
        }

        public void Close(bool instant = false)
        {
            if (m_Open)
                dialogClose.Invoke();

            m_Open = false;

            SetInteractable(false);

            if (instant || !Application.isPlaying)
            {
                OnCloseTransitionComplete();
            }
            else
            {
                m_CloseDialogTween.startValue = m_CanvasGroup.alpha;
                m_CloseDialogTween.targetValue = 0f;
                m_TweenRunner.StartTween(m_CloseDialogTween, EaseType.EaseInCubic);
            }
        }

        /// <summary>
        /// Set the window to be interactable, meaning that it will block raycasts and UI objects inside of the window
        /// will generate UI events. This is useful if you want to set a window to not be interactable during a
        /// transition.
        ///
        /// Note that this does not change visibility of the canvas.
        /// </summary>
        /// <param name="interactable"></param>
        public void SetInteractable(bool interactable)
        {
            if (interactable && !m_Open)
                Debug.LogWarning("You are setting a window to be interactable but it is not visible.",
                    gameObject);

            m_CanvasGroup.interactable = interactable;
            m_CanvasGroup.blocksRaycasts = interactable;
        }

        void SetVisible(bool visible)
        {
            m_Canvas.enabled = visible;
            m_CanvasGroup.alpha = visible ? 1f : 0f;
        }

        void Awake()
        {
            m_OpenDialogTween = new FloatTween()
            {
                duration = UIConfig.dialogFadeTime,
                ignoreTimeScale = true
            };
            m_OpenDialogTween.AddOnChangedCallback(OnSetAlpha);
            m_OpenDialogTween.AddOnCompleteCallback(OnOpenTransitionComplete);
            m_CloseDialogTween = new FloatTween()
            {
                duration = UIConfig.dialogFadeTime,
                ignoreTimeScale = true
            };
            m_CloseDialogTween.AddOnChangedCallback(OnSetAlpha);
            m_CloseDialogTween.AddOnCompleteCallback(OnCloseTransitionComplete);
            m_TweenRunner = new TweenRunner<FloatTween>();
            m_TweenRunner.Init(this);

            if (m_Canvas != null)
            {
                m_Open = m_Canvas.enabled;
            }
        }

        void OnSetAlpha(float alpha)
        {
            m_CanvasGroup.alpha = alpha;
        }

        void OnOpenTransitionComplete()
        {
            SetInteractable(true);
            SetVisible(true);
        }

        void OnCloseTransitionComplete()
        {
            SetInteractable(false);
            SetVisible(false);
        }
    }
}
