using System.ComponentModel.DataAnnotations;

namespace OtherPeopleRecordsWeb.Entities
{
	public class ContactFormModel
	{
		[Required(ErrorMessage = "El nombre es obligatorio")]
		[StringLength(100, ErrorMessage = "El nombre no debe exceder los 100 caracteres")]
		public string Name { get; set; }

		[Required(ErrorMessage = "El correo electrónico es obligatorio")]
		[EmailAddress(ErrorMessage = "Debe ser una dirección de correo electrónico válida")]
		public string Email { get; set; }

		[Required(ErrorMessage = "El mensaje es obligatorio")]
		[StringLength(500, ErrorMessage = "El mensaje no debe exceder los 500 caracteres")]
		public string Message { get; set; }
	}

}
