using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCollectorMVPTest.Presenters
{
    public abstract class BasePresenter<TView> where TView : class
    {
        private TView view;

        protected void SetView(TView view)
        {
            this.view = view;
        }

        public TView View
        {
            get
            {
                return view;
            }
        }
    }
}
