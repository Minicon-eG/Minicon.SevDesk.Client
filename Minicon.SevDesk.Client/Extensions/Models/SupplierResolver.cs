using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions.Models;

public sealed class SupplierResolver : ISupplierResolver
{
	private readonly IContactApi _contactApi;

	public SupplierResolver(IContactApi contactApi)
	{
		_contactApi = contactApi;
	}

	public async Task<string> SupplierAsync(ModelVoucherSupplier supplier)
	{
		// Assuming that IContactApi has a GetContactById method that returns a Contact object.
		GetContactResponse contact = await _contactApi.GetContactByIdAsync(supplier.Id);

		// Assuming that the Contact object has a Name property.
		return contact.Objects.Single().Name;
	}

	public async Task<string> SupplierAsync(ModelVoucherResponseSupplier supplier)
	{
		// Assuming that IContactApi has a GetContactByIdAsync method.
		GetContactResponse contact = await _contactApi.GetContactByIdAsync(supplier.Id.ToInt32());

		// Assuming that the Contact object has a Name property.
		return contact.Objects.Single().Name;
	}

	/* Implement this function */
	public async Task<ModelVoucherResponseSupplier?> SupplierAsync(string supplier)
	{
		// Assuming that IContactApi has a GetContactByNameAsync method that returns a Contact object.
		GetContactResponse contact = await _contactApi.GetContactsAsync(supplier);

		// If no contact is found, return null.
		if (contact.Objects.Count == 0)
		{
			return null;
		}

		ModelContactResponse? found = contact.Objects.SingleOrDefault(x => x.Name == supplier);

		if (found is null)
		{
			return null;
		}

		// Assuming that the Contact object has an Id and Name property.
		return new ModelVoucherResponseSupplier(found.Id, found.Name);
	}

	public Task<ModelVoucherSupplier> ToModelVoucherSupplierAsync(ModelVoucherResponseSupplier supplier)
	{
		if (int.TryParse(supplier.Id, out int id))
		{
			return Task.FromResult(new ModelVoucherSupplier(id, supplier.ObjectName));
		}

		throw new ArgumentException("The Id of the ModelVoucherResponseSupplier could not be converted to integer.");
	}
}
