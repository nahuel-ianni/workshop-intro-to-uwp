namespace AdaptiveTriggers.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Windows.UI.Xaml.Media.Imaging.BitmapImage Photo { get; set; }

        public string FullName => $"{LastName}, {Name}";

        public Contact (string name, string lastName, string phoneNumber = "123-456-789")
        {
            this.Name = name;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;

            var imageUri = "ms-appx:///Assets/Puppy.jpg";
            this.Photo = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new System.Uri(imageUri));
        }
    }
}
