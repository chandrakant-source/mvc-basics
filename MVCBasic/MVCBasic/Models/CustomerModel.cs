namespace MVCBasic.Models
{
    public class CustomerModel
    {
        #region Properties

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        #endregion
        #region Other Properties
        public string ActionMethod { get; set; }
        #endregion
    }
}