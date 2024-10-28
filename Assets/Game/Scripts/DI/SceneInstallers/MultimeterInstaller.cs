using UnityEngine;
using Zenject;

using MultimeterExample.Scripts.Components;

namespace MultimeterExample.Scripts.DI
{
    public class MultimeterInstaller : MonoInstaller
    {
        [SerializeField] private MultimeterController _multimeterController;
        [SerializeField] private MultimeterModel      _multimeterModel;
        [SerializeField] private MultimeterView       _multimeterView;

        public override void InstallBindings()
        {
            Container.BindInstance<MultimeterController>(_multimeterController).NonLazy();
            Container.BindInstance<MultimeterModel>(_multimeterModel).NonLazy();
            Container.BindInstance<MultimeterView>(_multimeterView).NonLazy();
        }
    }
}