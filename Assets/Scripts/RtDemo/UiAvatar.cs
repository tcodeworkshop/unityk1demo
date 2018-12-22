using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class UiAvatar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Canvas AnimatingView;
        public CanvasGroup AnimatingViewCanvasGroup;
        public RectTransform AnimatingViewTransform;

        public GameObject ModelPrefab;
        public GameObject AvatarChamber;
        public Transform ModelRoot;

        private GameObject _model;
        
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            _model = Instantiate(ModelPrefab);
            foreach (var renderer in _model.GetComponentsInChildren<Renderer>())
            {
                renderer.gameObject.layer = LayerMask.NameToLayer("Avatar");
            }
            _model.transform.SetParent(ModelRoot, false);

            AnimatingView.gameObject.SetActive(true);
            AvatarChamber.SetActive(true);

            AnimatingViewCanvasGroup.alpha = 0.5f;
            AnimatingViewCanvasGroup.DOKill();
            AnimatingViewCanvasGroup.DOFade(1, 0.2f);

            AnimatingViewTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            AnimatingViewTransform.DOKill();
            AnimatingViewTransform.DOScale(1, 0.2f);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            Destroy(_model);
            AnimatingViewCanvasGroup.DOKill();
            AnimatingViewCanvasGroup.DOFade(0, 0.1f)
                .OnComplete(() =>
                {
                    AnimatingView.gameObject.SetActive(false);
                });

            AnimatingViewTransform.DOKill();
            AnimatingViewTransform.DOScale(0.01f, 0.1f);
        }
    }
}
