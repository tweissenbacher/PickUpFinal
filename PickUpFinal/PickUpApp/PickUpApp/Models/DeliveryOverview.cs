using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PickUpApp.Models
{
    internal class DeliveryOverview
    {
        
        private List<Delivery> deliveries;

        public DeliveryOverview()
        {
            this.deliveries = new List<Delivery>();
        }

        public void Add (Delivery delivery) {
            deliveries.Add(delivery);
        }

        public void Remove(Delivery delivery)
        {
            deliveries.Remove(delivery);
        }

        //filters for deliveries after date which returns a new List
        public List<Delivery> FilterByDate(DateTime date) {
            List<Delivery> deliveriesDate = new List<Delivery>(); 
            foreach (Delivery delivery in deliveries)
            {
                if (delivery.EstimatedDelivery >= date)
                {
                    deliveriesDate.Add(delivery);
                }
            }
            return deliveriesDate;
        }

        //filters for deliveries by status
        public List<Delivery> FilterByStatus(Status status) {
            List<Delivery> deliveriesStatus = new List<Delivery>(); 
            foreach (Delivery delivery in deliveries)
            {
                if (delivery.Status == status)
                {
                    deliveriesStatus.Add(delivery);
                }
            }
            return deliveriesStatus;
        }
    }
}
