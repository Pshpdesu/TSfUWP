using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace CustomComponents.MasterDetail
{
    public interface IMasterDetail
    {
        Task SetMasterAsync(UIElement newMaster);
        void SetMaster(UIElement newDetails);
        Task SetDetailsAsync(UIElement newDetails);
        void SetDetails(UIElement newDetails);

    }
}
