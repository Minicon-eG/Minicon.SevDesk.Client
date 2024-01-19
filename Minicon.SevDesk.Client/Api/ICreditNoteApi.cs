using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICreditNoteApi
{
	/// <summary>
	///     Book a credit note
	/// </summary>
	/// <remarks>
	///     Booking the credit note with a transaction is probably the most important part in the bookkeeping process.&lt;br
	///     &gt; There are several ways on correctly booking a credit note, all by using the same endpoint.&lt;br&gt;
	///     Conveniently, the booking process is exactly the same as the process for invoices and vouchers.&lt;br&gt; For this
	///     reason, you can have a look at it in the &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-book-an-invoice&#x27;&gt;invoice chapter&lt;/a&gt; and all you need to do is
	///     to change \&quot;Invoice\&quot; into \&quot;CreditNote\&quot; in the URL.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to book</param>
	/// <param name="body">Booking data (optional)</param>
	/// <returns>Task of InlineResponse2008</returns>
	Task<InlineResponse2008> BookCreditNoteAsync(int? creditNoteId, CreditNoteIdBookAmountBody body = null);

	/// <summary>
	///     Create a new creditNote
	/// </summary>
	/// <remarks>
	///     The list of parameters starts with the credit note array.&lt;br&gt; This array contains all required attributes for
	///     a complete credit note.&lt;br&gt; Most of the attributes are covered in the credit note attribute list, there are
	///     only two parameters standing out, namely &lt;b&gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;.&lt;br&gt;
	///     These are just needed for our system and you always need to provide them.&lt;br&gt; The list of parameters then
	///     continues with the credit note position array.&lt;br&gt; With this array you have the possibility to add multiple
	///     positions at once.&lt;br&gt; In the example it only contains one position, again together with the parameters &lt;b
	///     &gt;mapAll&lt;/b&gt; and &lt;b&gt;objectName&lt;/b&gt;, however, you can add more credit note positions by
	///     extending the array.&lt;br&gt; So if you wanted to add another position, you would add the same list of parameters
	///     with an incremented array index of \&quot;1\&quot; instead of \&quot;0\&quot;.&lt;br&gt;&lt;br&gt; The list ends
	///     with the five parameters creditNotePosDelete, discountSave, discountDelete, takeDefaultAddress and forCashRegister.
	///     &lt;br&gt; They only play a minor role if you only want to create a credit note but we will shortly explain what
	///     they can do.&lt;br&gt; With creditNotePosDelete you have to option to delete credit note positions as this request
	///     can also be used to update credit notes.&lt;br&gt; Both discount parameters are deprecated and have no use for
	///     credit notes, however they need to be provided in case you want to use the following two parameters.&lt;br&gt; With
	///     takeDefaultAddress you can specify that the first address of the contact you are using for the credit note is taken
	///     for the credit note address attribute automatically, so you don&#x27;t need to provide the address yourself.&lt;br
	///     &gt; Finally, the forCashRegister parameter needs to be set to &lt;b&gt;true&lt;/b&gt; if your credit note is to be
	///     booked on the cash register.&lt;br&gt; If you want to know more about these parameters, for example if you want to
	///     use this request to update credit notes, feel free to contact our support.&lt;br&gt; Finally, after covering all
	///     parameters, they only important information left, is that the order of the last five attributes always needs to be
	///     kept.&lt;br&gt; You will also always need to provide all of them, as otherwise the request won&#x27;t work
	///     properly.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the credit note model! (optional)
	/// </param>
	/// <returns>Task of SaveCreditNoteResponse</returns>
	Task<SaveCreditNoteResponse> CreatecreditNoteAsync(SaveCreditNote body = null);

	/// <summary>
	///     Retrieve pdf document of a credit note
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of a credit note with additional metadata.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the credit note. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the credit note. (optional)</param>
	/// <returns>Task of CreditNoteGetPdfResponse</returns>
	Task<CreditNoteGetPdfResponse> CreditNoteGetPdfAsync(int? creditNoteId, bool? download = null,
		bool? preventSendBy = null);

	/// <summary>
	///     Mark credit note as sent
	/// </summary>
	/// <remarks>
	///     Marks an credit note as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of InlineResponse20032</returns>
	Task<InlineResponse20032> CreditNoteSendByAsync(int? creditNoteId, CreditNoteIdSendByBody body = null);

	/// <summary>
	///     Deletes an creditNote
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">Id of creditNote resource to delete</param>
	/// <returns>Task of InlineResponse2005</returns>
	Task<InlineResponse2005> DeletecreditNoteAsync(int? creditNoteId);

	/// <summary>
	///     Retrieve CreditNote
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the CreditNote (optional)</param>
	/// <param name="creditNoteNumber">Retrieve all CreditNotes with this creditNote number (optional)</param>
	/// <param name="startDate">Retrieve all CreditNotes with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all CreditNotes with a date equal or lower (optional)</param>
	/// <param name="contactId">
	///     Retrieve all CreditNotes with this contact. Must be provided with contact[objectName]
	///     (optional)
	/// </param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of InlineResponse2005</returns>
	Task<InlineResponse2005> GetCreditNotesAsync(string status = null, string creditNoteNumber = null,
		int? startDate = null, int? endDate = null, int? contactId = null, string contactObjectName = null);


	/// <summary>
	///     Find creditNote by ID
	/// </summary>
	/// <remarks>
	///     Returns a single creditNote
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of creditNote to return</param>
	/// <returns>Task of InlineResponse2005</returns>
	Task<InlineResponse2005> GetcreditNoteByIdAsync(int? creditNoteId);

	/// <summary>
	///     Send credit note by printing
	/// </summary>
	/// <remarks>
	///     Sending a credit note to end-customers is an important part of the bookkeeping process.&lt;br&gt; Depending on the
	///     way you want to send the credit note, you need to use different endpoints.&lt;br&gt; Let&#x27;s start with just
	///     printing out the credit note, meaning we only need to render the pdf.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of creditNote to return</param>
	/// <param name="sendType">the type you want to print.</param>
	/// <returns>Task of InlineResponse2005</returns>
	Task<InlineResponse2005> SendCreditNoteByPrintingAsync(int? creditNoteId, string sendType);

	/// <summary>
	///     Send credit note via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified credit note to a customer via email.&lt;br&gt;      This will automatically mark
	///     the credit note as sent.&lt;br&gt;      Please note, that in production an credit note is not allowed to be changed
	///     after this happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of InlineResponse2005</returns>
	Task<InlineResponse2005> SendCreditNoteViaEMailAsync(int? creditNoteId, CreditNoteIdSendViaEmailBody body = null);

	/// <summary>
	///     Update an existing creditNote
	/// </summary>
	/// <remarks>
	///     Update a creditNote
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of creditNote to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse2005</returns>
	Task<InlineResponse2005> UpdatecreditNoteAsync(int? creditNoteId, ModelCreditNoteUpdate body = null);
}
