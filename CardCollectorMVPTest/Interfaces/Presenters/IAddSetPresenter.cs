using CardCollectorMVPTest.Interfaces.Views;

namespace CardCollectorMVPTest.Interfaces.Presenters
{
    public interface IAddSetPresenter
    {
        void CreateSet();
        void CancelCreateSet();
        void SetView(IAddSetView View);
    }
}
