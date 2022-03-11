using QRCoder;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PickUpApp.Models
{
    public class Delivery
    {
        private string id;

        private Person sender;
        private string receiver;
        private string weight;
        private Size size;
        private Status status;
        private Location location;
        private DateTime estimatedDelivery;

        private Person detour;
        private string signatureReleaseAuthorization;

        public Delivery(string id, Person sender, string receiver, string weight, Size size, Status status, Location location, DateTime estimatedDelivery, Person detour = null, string signatureReleaseAuthorization = "")
        {
            this.id = id;
            this.sender = sender;

            this.receiver = receiver;
            this.weight = weight;
            this.size = size;

            this.status = status;
            this.location = location;
            this.estimatedDelivery = estimatedDelivery;
            this.detour = detour;
            this.signatureReleaseAuthorization = signatureReleaseAuthorization;
        }

        public string Id { get => id; set => id = value; }
        public Person Sender { get => sender; set => sender = value; }
        public string Receiver { get => receiver; set => receiver = value; }
        public string Weight { get => weight; set => weight = value; }

        public Location Location { get => location; set => location = value; }
        public DateTime EstimatedDelivery { get => estimatedDelivery; set => estimatedDelivery = value; }

        public Size Size { get => size; set => size = value; }
        public Status Status { get => status; set => status = value; }
        public Person Detour { get => detour; set => detour = value; }
        public string SignatureReleaseAuthorization { get => signatureReleaseAuthorization; set => signatureReleaseAuthorization = value; }


    }
}