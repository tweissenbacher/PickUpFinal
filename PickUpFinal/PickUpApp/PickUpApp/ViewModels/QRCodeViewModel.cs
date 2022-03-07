using System;
using System.Collections.Generic;
using System.Text;

namespace PickUpApp.ViewModels
{
    public class QRCodeViewModel : BaseViewModel
    {
        public string delId;
        public QRCodeViewModel(string ID)
        {
            delId = ID;
        }
        public string deliveryId
        {
            get
            {
                return delId;
            }
            set
            {
                delId = value;

            }
        }
    }
}
