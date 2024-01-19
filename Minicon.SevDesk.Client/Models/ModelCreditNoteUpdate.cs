/* 
 * sevDesk API
 *
 * <b>Contact:</b> To contact our support click <a href='https://landing.sevdesk.de/service-support-center-technik'>here</a><br><br>   # General information  Welcome to our API!<br>  sevDesk offers you the possibility of retrieving data using an interface, namely the sevDesk API, and making changes without having to use the web UI. The sevDesk interface is a REST-Full API. All sevDesk data and functions that are used in the web UI can also be controlled through the API.   # Cross-Origin Resource Sharing  This API features Cross-Origin Resource Sharing (CORS).<br>  It enables cross-domain communication from the browser.<br>  All responses have a wildcard same-origin which makes them completely public and accessible to everyone, including any code on any site.    # Embedding resources  When retrieving resources by using this API, you might encounter nested resources in the resources you requested.<br>  For example, an invoice always contains a contact, of which you can see the ID and the object name.<br>  This API gives you the possibility to embed these resources completely into the resources you originally requested.<br>  Taking our invoice example, this would mean, that you would not only see the ID and object name of a contact, but rather the complete contact resource.    To embed resources, all you need to do is to add the query parameter 'embed' to your GET request.<br>  As values, you can provide the name of the nested resource.<br>  Multiple nested resources are also possible by providing multiple names, separated by a comma.    # Authentication and Authorization  The sevDesk API uses a token authentication to authorize calls. For this purpose every sevDesk administrator has one API token, which is a <b>hexadecimal string</b> containing <b>32 characters</b>. The following clip shows where you can find the API token if this is your first time with our API.<br><br> <video src='OpenAPI/img/findingTheApiToken.mp4' controls width='640' height='360'> Ihr Browser kann dieses Video nicht wiedergeben.<br/> Dieses Video zeigt wie sie Ihr sevDesk API Token finden. </video> <br> The token will be needed in every request that you want to send and needs to be attached to the request url as a <b>Query Parameter</b><br> or provided as a value of an <b>Authorization Header</b>.<br> For security reasons, we suggest putting the API Token in the Authorization Header and not in the query string.<br> However, in the request examples in this documentation, we will keep it in the query string, as it is easier for you to copy them and try them yourself.<br> The following url is an example that shows where your token needs to be placed as a query parameter.<br> In this case, we used some random API token. <ul> <li><span>ht</span>tps://my.sevdesk.de/api/v1/Contact?token=<span style='color:red'>b7794de0085f5cd00560f160f290af38</span></li> </ul> The next example shows the token in the Authorization Header. <ul> <li>\"Authorization\" :<span style='color:red'>\"b7794de0085f5cd00560f160f290af38\"</span></li> </ul> The api tokens have an infinite lifetime and, in other words, exist as long as the sevDesk user exists.<br> For this reason, the user should <b>NEVER</b> be deleted.<br> If really necessary, it is advisable to save the api token as we will <b>NOT</b> be able to retrieve it afterwards!<br> It is also possible to generate a new API token, for example, if you want to prevent the usage of your sevDesk account by other people who got your current API token.<br> To achieve this, you just need to click on the \"generate new\" symbol to the right of your token and confirm it with your password.  # API News  To never miss API news and updates again, subscribe to our <b>free API newsletter</b> and get all relevant information to keep your sevDesk software running smoothly. To subscribe, simply click <a href = 'https://landing.sevdesk.de/api-newsletter'><b>here</b></a> and confirm the email address to which we may send all updates relevant to you.  # API Requests  In our case, REST API requests need to be build by combining the following components. <table> <tr> <th><b>Component</b></th> <th><b>Description</b></th> </tr> <tr> <td>HTTP-Methods</td> <td> <ul> <li>GET (retrieve a resource)</li> <li>POST (create a resource)</li> <li>PUT (update a resource)</li> <li>DELETE (delete a resource)</li> </ul> </td> </tr> <tr> <td>URL of the API</td> <td><span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span></td> </tr> <tr> <td>URI of the resource</td> <td>The resource to query.<br>For example contacts in sevDesk:<br><br> <span style='color:red'>/Contact</span><br><br> Which will result in the following complete URL:<br><br> <span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span><span style='color:red'>/Contact</span> </td> </tr> <tr> <td>Query parameters</td> <td>Are attached by using the connectives <b>?</b> and <b>&</b> in the URL.<br></td> </tr> <tr> <td>Request headers</td> <td>Typical request headers are for example:<br> <div> <br> <ul> <li>Content-type</li> <li>Authorization</li> <li>Accept-Encoding</li> <li>User-Agent</li> <li>...</li> </ul> </div> </td> </tr> <tr> <td>Request body</td> <td>Mostly required in POST and PUT requests.<br> Often the request body contains json, in our case, it also accepts url-encoded data. </td> </tr> </table><br> <span style='color:red'>Note</span>: please pass a meaningful entry at the header \"User-Agent\". If the \"User-Agent\" is set meaningfully, we can offer better support in case of queries from customers.<br> An example how such a \"User-Agent\" can look like: \"Integration-name by abc\". <br><br> This is a sample request for retrieving existing contacts in sevDesk using curl:<br><br> <img src='OpenAPI/img/GETRequest.PNG' alt='Get Request' height='150'><br><br> As you can see, the request contains all the components mentioned above.<br> It's HTTP method is GET, it has a correct endpoint (<span style='color: #2aa198'>ht</span><span style='color: #2aa198'>tps://my.sevdesk.de/api/v1</span><span style='color:red'>/Contact</span>), query parameters like <b>token</b> and additional <b>header</b> information!<br><br> <b>Query Parameters</b><br><br> As you might have seen in the sample request above, there are several other parameters besides \"token\", located in the url.<br> Those are mostly optional but prove to be very useful for a lot of requests as they can limit, extend, sort or filter the data you will get as a response.<br><br> These are the three most used query parameter for the sevDesk API. <table> <tr> <th><b>Parameter</b></th> <th><b>Description</b></th> </tr> <tr> <td>limit</td> <td>Limits the number of entries that are returned.<br> Most useful in GET requests which will most likely deliver big sets of data like country or currency lists.<br> In this case, you can bypass the default limitation on returned entries by providing a high number. </td> </tr> <tr> <td>offset</td> <td>Specifies a certain offset for the data that will be returned.<br> As an example, you can specify \"offset=2\" if you want all entries except for the first two.</td> </tr> <tr> <td>embed</td> <td>Will extend some of the returned data.<br> A brief example can be found below.</td> </tr> </table> This is an example for the usage of the embed parameter.<br> The following first request will return all company contact entries in sevDesk up to a limit of 100 without any additional information and no offset.<br><br> <img src='OpenAPI/img/ContactQueryWithoutEmbed.PNG' width='900' height='850'><br><br> Now have a look at the category attribute located in the response.<br> Naturally, it just contains the id and the object name of the object but no further information.<br> We will now use the parameter embed with the value \"category\".<br><br> <img src='OpenAPI/img/ContactQueryWithEmbed.PNG' width='900' height='850'><br><br> As you can see, the category object is now extended and shows all the attributes and their corresponding values.<br><br> There are lot of other query parameters that can be used to filter the returned data for objects that match a certain pattern, however, those will not be mentioned here and instead can be found at the detail documentation of the most used API endpoints like contact, invoice or voucher.<br><br> <b>Request Headers</b><br><br> The HTTP request (response) headers allow the client as well as the server to pass additional information with the request.<br> They transfer the parameters and arguments which are important for transmitting data over HTTP.<br> Three headers which are useful / necessary when using the sevDesk API are \"Authorization, \"Accept\" and \"Content-type\".<br> Underneath is a brief description of why and how they should be used.<br><br> <b>Authorization</b><br><br> Can be used if you want to provide your API token in the header instead of having it in the url. <ul> <li>Authorization:<span style='color:red'>yourApiToken</span></li> </ul> <b>Accept</b><br><br> Specifies the format of the response.<br> Required for operations with a response body. <ul> <li>Accept:application/<span style='color:red'>format</span> </li> </ul> In our case, <code><span style='color:red'>format</span></code> could be replaced with <code>json</code> or <code>xml</code><br><br> <b>Content-type</b><br><br> Specifies which format is used in the request.<br> Is required for operations with a request body. <ul> <li>Content-type:application/<span style='color:red'>format</span></li> </ul> In our case,<code><span style='color:red'>format</span></code>could be replaced with <code>json</code> or <code>x-www-form-urlencoded</code> <br><br><b>API Responses</b><br><br> HTTP status codes<br> When calling the sevDesk API it is very likely that you will get a HTTP status code in the response.<br> Some API calls will also return JSON response bodies which will contain information about the resource.<br> Each status code which is returned will either be a <b>success</b> code or an <b>error</b> code.<br><br> Success codes <table> <tr> <th><b>Status code</b></th> <th><b>Description</b></th> </tr> <tr> <td><code>200 OK</code></td> <td>The request was successful</td> </tr> <tr> <td><code>201 Created</code></td> <td>Most likely to be found in the response of a <b>POST</b> request.<br> This code indicates that the desired resource was successfully created.</td> </tr> </table> <br>Error codes <table> <tr> <th><b>Status code</b></th> <th><b>Description</b></th> </tr> <tr> <td><code>400 Bad request</code></td> <td>The request you sent is most likely syntactically incorrect.<br> You should check if the parameters in the request body or the url are correct.</td> </tr> <tr> <td><code>401 Unauthorized</code></td> <td>The authentication failed.<br> Most likely caused by a missing or wrong API token.</td> </tr> <tr> <td><code>403 Forbidden</code></td> <td>You do not have the permission the access the resource which is requested.</td> </tr> <tr> <td><code>404 Not found</code></td> <td>The resource you specified does not exist.</td> </tr> <tr> <td><code>500 Internal server error</code></td> <td>An internal server error has occurred.<br> Normally this means that something went wrong on our side.<br> However, sometimes this error will appear if we missed to catch an error which is normally a 400 status code! </td> </tr> </table>  # Your First Request  After reading the introduction to our API, you should now be able to make your first call.<br> For testing our API, we would always recommend to create a trial account for sevDesk to prevent unwanted changes to your main account.<br> A trial account will be in the highest tariff (materials management), so every sevDesk function can be tested! <br><br>To start testing we would recommend one of the following tools: <ul> <li><a href='https://www.getpostman.com/'>Postman</a></li> <li><a href='https://curl.haxx.se/download.html'>cURL</a></li> </ul> This example will illustrate your first request, which is creating a new Contact in sevDesk.<br> <ol> <li>Download <a href='https://www.getpostman.com/'><b>Postman</b></a> for your desired system and start the application</li> <li>Enter <span><b>ht</span>tps://my.sevdesk.de/api/v1/Contact</b> as the url</li> <li>Use the connective <b>?</b> to append <b>token=</b> to the end of the url, or create an authorization header. Insert your API token as the value</li> <li>For this test, select <b>POST</b> as the HTTP method</li> <li>Go to <b>Headers</b> and enter the key-value pair <b>Content-type</b> + <b>application/x-www-form-urlencoded</b><br> As an alternative, you can just go to <b>Body</b> and select <b>x-www-form-urlencoded</b></li> <li>Now go to <b>Body</b> (if you are not there yet) and enter the key-value pairs as shown in the following picture<br><br> <img src='OpenAPI/img/FirstRequestPostman.PNG' width='900'><br><br></li> <li>Click on <b>Send</b>. Your response should now look like this:<br><br> <img src='OpenAPI/img/FirstRequestResponse.PNG' width='900'></li> </ol> As you can see, a successful response in this case returns a JSON-formatted response body containing the contact you just created.<br> For keeping it simple, this was only a minimal example of creating a contact.<br> There are however numerous combinations of parameters that you can provide which add information to your contact.
 *
 * OpenAPI spec version: 2.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Minicon.SevDesk.Client.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     creditNote model
/// </summary>
[DataContract]
public class ModelCreditNoteUpdate : IEquatable<ModelCreditNoteUpdate>, IValidatableObject
{
	/// <summary>
	///     Type which was used to send the creditNote. IMPORTANT: Please refer to the creditNote section of the       *
	///     API-Overview to understand how this attribute can be used before using it!
	/// </summary>
	/// <value>
	///     Type which was used to send the creditNote. IMPORTANT: Please refer to the creditNote section of the       *
	///     API-Overview to understand how this attribute can be used before using it!
	/// </value>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum SendTypeEnum
	{
		/// <summary>
		///     Enum VPR for value: VPR
		/// </summary>
		[EnumMember(Value = "VPR")] VPR = 1,

		/// <summary>
		///     Enum VPDF for value: VPDF
		/// </summary>
		[EnumMember(Value = "VPDF")] VPDF = 2,

		/// <summary>
		///     Enum VM for value: VM
		/// </summary>
		[EnumMember(Value = "VM")] VM = 3,

		/// <summary>
		///     Enum VP for value: VP
		/// </summary>
		[EnumMember(Value = "VP")] VP = 4
	}

	/// <summary>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-credit-notes
	///     &#x27;&gt;status of credit note&lt;/a&gt;      to see what the different status codes mean
	/// </summary>
	/// <value>
	///     Please have a look in       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-credit-notes&#x27;&gt;status of credit note&lt;/a&gt;      to
	///     see what the different status codes mean
	/// </value>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum StatusEnum
	{
		/// <summary>
		///     Enum _100 for value: 100
		/// </summary>
		[EnumMember(Value = "100")] _100 = 1,

		/// <summary>
		///     Enum _200 for value: 200
		/// </summary>
		[EnumMember(Value = "200")] _200 = 2,

		/// <summary>
		///     Enum _1000 for value: 1000
		/// </summary>
		[EnumMember(Value = "1000")] _1000 = 3
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="ModelCreditNoteUpdate" /> class.
	/// </summary>
	/// <param name="creditNoteNumber">The creditNote number.</param>
	/// <param name="contact">contact.</param>
	/// <param name="creditNoteDate">Needs to be provided as timestamp or dd.mm.yyyy.</param>
	/// <param name="status">
	///     Please have a look in       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-credit-notes&#x27;&gt;status of credit note&lt;/a&gt;      to
	///     see what the different status codes mean.
	/// </param>
	/// <param name="header">Normally consist of prefix plus the creditNote number.</param>
	/// <param name="headText">Certain html tags can be used here to format your text.</param>
	/// <param name="footText">Certain html tags can be used here to format your text.</param>
	/// <param name="addressCountry">addressCountry.</param>
	/// <param name="createUser">createUser.</param>
	/// <param name="sevClient">sevClient.</param>
	/// <param name="deliveryTerms">Delivery terms of the creditNote.</param>
	/// <param name="deliveryDate">Timestamp. This can also be a date range if you also use the attribute deliveryDateUntil.</param>
	/// <param name="paymentTerms">Payment terms of the creditNote.</param>
	/// <param name="version">
	///     Version of the creditNote.&lt;br&gt;      Can be used if you have multiple drafts for the same
	///     creditNote.&lt;br&gt;      Should start with 0.
	/// </param>
	/// <param name="smallSettlement">
	///     Defines if the client uses the small settlement scheme.      If yes, the creditNote must
	///     not contain any vat.
	/// </param>
	/// <param name="contactPerson">contactPerson.</param>
	/// <param name="taxRate">Is overwritten by creditNote position tax rates.</param>
	/// <param name="taxSet">taxSet.</param>
	/// <param name="taxText">A common tax text would be &#x27;Umsatzsteuer 19%&#x27;.</param>
	/// <param name="taxType">
	///     Tax type of the creditNote. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu -
	///     Steuerfreie innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des
	///     Leistungsempfängers (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT
	///     according to §19 1 UStG Tax rates are heavily connected to the tax type used..
	/// </param>
	/// <param name="creditNoteType">
	///     Type of the creditNote. For more information on the different types, check      &lt;a href
	///     &#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-credit-notes&#x27;&gt;this&lt;/a&gt;  .
	/// </param>
	/// <param name="sendDate">The date the creditNote was sent to the customer.</param>
	/// <param name="address">
	///     Complete address of the recipient including name, street, city, zip and country.&lt;br&gt;
	///     Line breaks can be used and will be displayed on the invoice pdf..
	/// </param>
	/// <param name="currency">Currency used in the creditNote. Needs to be currency code according to ISO-4217.</param>
	/// <param name="customerInternalNote">
	///     Internal note of the customer. Contains data entered into field &#x27;
	///     Referenz/Bestellnummer&#x27;.
	/// </param>
	/// <param name="showNet">If true, the net amount of each position will be shown on the creditNote. Otherwise gross amount.</param>
	/// <param name="sendType">
	///     Type which was used to send the creditNote. IMPORTANT: Please refer to the creditNote section of
	///     the       *     API-Overview to understand how this attribute can be used before using it!.
	/// </param>
	public ModelCreditNoteUpdate(string creditNoteNumber = default, ModelCreditNoteUpdateContact contact = default,
		DateTime? creditNoteDate = default, StatusEnum? status = default, string header = default,
		string headText = default, string footText = default, ModelCreditNoteAddressCountry addressCountry = default,
		ModelCreditNoteCreateUser createUser = default, ModelCreditNoteSevClient sevClient = default,
		string deliveryTerms = default, DateTime? deliveryDate = default, string paymentTerms = default,
		int? version = default, bool? smallSettlement = default,
		ModelCreditNoteUpdateContactPerson contactPerson = default, float? taxRate = default,
		ModelCreditNoteTaxSet taxSet = default, string taxText = default, string taxType = default,
		string creditNoteType = default, DateTime? sendDate = default, string address = default,
		string currency = default, string customerInternalNote = default, bool? showNet = default,
		SendTypeEnum? sendType = default)
	{
		CreditNoteNumber = creditNoteNumber;
		Contact = contact;
		CreditNoteDate = creditNoteDate;
		Status = status;
		Header = header;
		HeadText = headText;
		FootText = footText;
		AddressCountry = addressCountry;
		CreateUser = createUser;
		SevClient = sevClient;
		DeliveryTerms = deliveryTerms;
		DeliveryDate = deliveryDate;
		PaymentTerms = paymentTerms;
		Version = version;
		SmallSettlement = smallSettlement;
		ContactPerson = contactPerson;
		TaxRate = taxRate;
		TaxSet = taxSet;
		TaxText = taxText;
		TaxType = taxType;
		CreditNoteType = creditNoteType;
		SendDate = sendDate;
		Address = address;
		Currency = currency;
		CustomerInternalNote = customerInternalNote;
		ShowNet = showNet;
		SendType = sendType;
	}

	/// <summary>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-credit-notes
	///     &#x27;&gt;status of credit note&lt;/a&gt;      to see what the different status codes mean
	/// </summary>
	/// <value>
	///     Please have a look in       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-credit-notes&#x27;&gt;status of credit note&lt;/a&gt;      to
	///     see what the different status codes mean
	/// </value>
	[DataMember(Name = "status", EmitDefaultValue = false)]
	public StatusEnum? Status { get; set; }

	/// <summary>
	///     Type which was used to send the creditNote. IMPORTANT: Please refer to the creditNote section of the       *
	///     API-Overview to understand how this attribute can be used before using it!
	/// </summary>
	/// <value>
	///     Type which was used to send the creditNote. IMPORTANT: Please refer to the creditNote section of the       *
	///     API-Overview to understand how this attribute can be used before using it!
	/// </value>
	[DataMember(Name = "sendType", EmitDefaultValue = false)]
	public SendTypeEnum? SendType { get; set; }

	/// <summary>
	///     The creditNote id
	/// </summary>
	/// <value>The creditNote id</value>
	[DataMember(Name = "id", EmitDefaultValue = false)]
	public int? Id { get; private set; }

	/// <summary>
	///     The creditNote object name
	/// </summary>
	/// <value>The creditNote object name</value>
	[DataMember(Name = "objectName", EmitDefaultValue = false)]
	public string ObjectName { get; private set; }

	/// <summary>
	///     Date of creditNote creation
	/// </summary>
	/// <value>Date of creditNote creation</value>
	[DataMember(Name = "create", EmitDefaultValue = false)]
	public DateTime? Create { get; private set; }

	/// <summary>
	///     Date of last creditNote update
	/// </summary>
	/// <value>Date of last creditNote update</value>
	[DataMember(Name = "update", EmitDefaultValue = false)]
	public DateTime? Update { get; private set; }

	/// <summary>
	///     The creditNote number
	/// </summary>
	/// <value>The creditNote number</value>
	[DataMember(Name = "creditNoteNumber", EmitDefaultValue = false)]
	public string CreditNoteNumber { get; set; }

	/// <summary>
	///     Gets or Sets Contact
	/// </summary>
	[DataMember(Name = "contact", EmitDefaultValue = false)]
	public ModelCreditNoteUpdateContact Contact { get; set; }

	/// <summary>
	///     Needs to be provided as timestamp or dd.mm.yyyy
	/// </summary>
	/// <value>Needs to be provided as timestamp or dd.mm.yyyy</value>
	[DataMember(Name = "creditNoteDate", EmitDefaultValue = false)]
	public DateTime? CreditNoteDate { get; set; }


	/// <summary>
	///     Normally consist of prefix plus the creditNote number
	/// </summary>
	/// <value>Normally consist of prefix plus the creditNote number</value>
	[DataMember(Name = "header", EmitDefaultValue = false)]
	public string Header { get; set; }

	/// <summary>
	///     Certain html tags can be used here to format your text
	/// </summary>
	/// <value>Certain html tags can be used here to format your text</value>
	[DataMember(Name = "headText", EmitDefaultValue = false)]
	public string HeadText { get; set; }

	/// <summary>
	///     Certain html tags can be used here to format your text
	/// </summary>
	/// <value>Certain html tags can be used here to format your text</value>
	[DataMember(Name = "footText", EmitDefaultValue = false)]
	public string FootText { get; set; }

	/// <summary>
	///     Gets or Sets AddressCountry
	/// </summary>
	[DataMember(Name = "addressCountry", EmitDefaultValue = false)]
	public ModelCreditNoteAddressCountry AddressCountry { get; set; }

	/// <summary>
	///     Gets or Sets CreateUser
	/// </summary>
	[DataMember(Name = "createUser", EmitDefaultValue = false)]
	public ModelCreditNoteCreateUser CreateUser { get; set; }

	/// <summary>
	///     Gets or Sets SevClientReference
	/// </summary>
	[DataMember(Name = "sevClient", EmitDefaultValue = false)]
	public ModelCreditNoteSevClient SevClient { get; set; }

	/// <summary>
	///     Delivery terms of the creditNote
	/// </summary>
	/// <value>Delivery terms of the creditNote</value>
	[DataMember(Name = "deliveryTerms", EmitDefaultValue = false)]
	public string DeliveryTerms { get; set; }

	/// <summary>
	///     Timestamp. This can also be a date range if you also use the attribute deliveryDateUntil
	/// </summary>
	/// <value>Timestamp. This can also be a date range if you also use the attribute deliveryDateUntil</value>
	[DataMember(Name = "deliveryDate", EmitDefaultValue = false)]
	public DateTime? DeliveryDate { get; set; }

	/// <summary>
	///     Payment terms of the creditNote
	/// </summary>
	/// <value>Payment terms of the creditNote</value>
	[DataMember(Name = "paymentTerms", EmitDefaultValue = false)]
	public string PaymentTerms { get; set; }

	/// <summary>
	///     Version of the creditNote.&lt;br&gt;      Can be used if you have multiple drafts for the same creditNote.&lt;br
	///     &gt;      Should start with 0
	/// </summary>
	/// <value>
	///     Version of the creditNote.&lt;br&gt;      Can be used if you have multiple drafts for the same creditNote.&lt;br
	///     &gt;      Should start with 0
	/// </value>
	[DataMember(Name = "version", EmitDefaultValue = false)]
	public int? Version { get; set; }

	/// <summary>
	///     Defines if the client uses the small settlement scheme.      If yes, the creditNote must not contain any vat
	/// </summary>
	/// <value>Defines if the client uses the small settlement scheme.      If yes, the creditNote must not contain any vat</value>
	[DataMember(Name = "smallSettlement", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? SmallSettlement { get; set; }

	/// <summary>
	///     Gets or Sets ContactPerson
	/// </summary>
	[DataMember(Name = "contactPerson", EmitDefaultValue = false)]
	public ModelCreditNoteUpdateContactPerson ContactPerson { get; set; }

	/// <summary>
	///     Is overwritten by creditNote position tax rates
	/// </summary>
	/// <value>Is overwritten by creditNote position tax rates</value>
	[DataMember(Name = "taxRate", EmitDefaultValue = false)]
	public float? TaxRate { get; set; }

	/// <summary>
	///     Gets or Sets TaxSet
	/// </summary>
	[DataMember(Name = "taxSet", EmitDefaultValue = false)]
	public ModelCreditNoteTaxSet TaxSet { get; set; }

	/// <summary>
	///     A common tax text would be &#x27;Umsatzsteuer 19%&#x27;
	/// </summary>
	/// <value>A common tax text would be &#x27;Umsatzsteuer 19%&#x27;</value>
	[DataMember(Name = "taxText", EmitDefaultValue = false)]
	public string TaxText { get; set; }

	/// <summary>
	///     Tax type of the creditNote. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu - Steuerfreie
	///     innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des Leistungsempfängers
	///     (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT according to §19 1 UStG
	///     Tax rates are heavily connected to the tax type used.
	/// </summary>
	/// <value>
	///     Tax type of the creditNote. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu - Steuerfreie
	///     innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des Leistungsempfängers
	///     (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT according to §19 1 UStG
	///     Tax rates are heavily connected to the tax type used.
	/// </value>
	[DataMember(Name = "taxType", EmitDefaultValue = false)]
	public string TaxType { get; set; }

	/// <summary>
	///     Type of the creditNote. For more information on the different types, check      &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-credit-notes&#x27;&gt;this&lt;/a&gt;
	/// </summary>
	/// <value>
	///     Type of the creditNote. For more information on the different types, check      &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-credit-notes&#x27;&gt;this&lt;/a&gt;
	/// </value>
	[DataMember(Name = "creditNoteType", EmitDefaultValue = false)]
	public string CreditNoteType { get; set; }

	/// <summary>
	///     The date the creditNote was sent to the customer
	/// </summary>
	/// <value>The date the creditNote was sent to the customer</value>
	[DataMember(Name = "sendDate", EmitDefaultValue = false)]
	public DateTime? SendDate { get; set; }

	/// <summary>
	///     Complete address of the recipient including name, street, city, zip and country.&lt;br&gt;       Line breaks can be
	///     used and will be displayed on the invoice pdf.
	/// </summary>
	/// <value>
	///     Complete address of the recipient including name, street, city, zip and country.&lt;br&gt;       Line breaks can
	///     be used and will be displayed on the invoice pdf.
	/// </value>
	[DataMember(Name = "address", EmitDefaultValue = false)]
	public string Address { get; set; }

	/// <summary>
	///     Currency used in the creditNote. Needs to be currency code according to ISO-4217
	/// </summary>
	/// <value>Currency used in the creditNote. Needs to be currency code according to ISO-4217</value>
	[DataMember(Name = "currency", EmitDefaultValue = false)]
	public string Currency { get; set; }

	/// <summary>
	///     Net sum of the creditNote
	/// </summary>
	/// <value>Net sum of the creditNote</value>
	[DataMember(Name = "sumNet", EmitDefaultValue = false)]
	public float? SumNet { get; private set; }

	/// <summary>
	///     Tax sum of the creditNote
	/// </summary>
	/// <value>Tax sum of the creditNote</value>
	[DataMember(Name = "sumTax", EmitDefaultValue = false)]
	public float? SumTax { get; private set; }

	/// <summary>
	///     Gross sum of the creditNote
	/// </summary>
	/// <value>Gross sum of the creditNote</value>
	[DataMember(Name = "sumGross", EmitDefaultValue = false)]
	public float? SumGross { get; private set; }

	/// <summary>
	///     Sum of all discounts in the creditNote
	/// </summary>
	/// <value>Sum of all discounts in the creditNote</value>
	[DataMember(Name = "sumDiscounts", EmitDefaultValue = false)]
	public float? SumDiscounts { get; private set; }

	/// <summary>
	///     Net sum of the creditNote in the foreign currency
	/// </summary>
	/// <value>Net sum of the creditNote in the foreign currency</value>
	[DataMember(Name = "sumNetForeignCurrency", EmitDefaultValue = false)]
	public float? SumNetForeignCurrency { get; private set; }

	/// <summary>
	///     Tax sum of the creditNote in the foreign currency
	/// </summary>
	/// <value>Tax sum of the creditNote in the foreign currency</value>
	[DataMember(Name = "sumTaxForeignCurrency", EmitDefaultValue = false)]
	public float? SumTaxForeignCurrency { get; private set; }

	/// <summary>
	///     Gross sum of the creditNote in the foreign currency
	/// </summary>
	/// <value>Gross sum of the creditNote in the foreign currency</value>
	[DataMember(Name = "sumGrossForeignCurrency", EmitDefaultValue = false)]
	public float? SumGrossForeignCurrency { get; private set; }

	/// <summary>
	///     Discounts sum of the creditNote in the foreign currency
	/// </summary>
	/// <value>Discounts sum of the creditNote in the foreign currency</value>
	[DataMember(Name = "sumDiscountsForeignCurrency", EmitDefaultValue = false)]
	public float? SumDiscountsForeignCurrency { get; private set; }

	/// <summary>
	///     Internal note of the customer. Contains data entered into field &#x27;Referenz/Bestellnummer&#x27;
	/// </summary>
	/// <value>Internal note of the customer. Contains data entered into field &#x27;Referenz/Bestellnummer&#x27;</value>
	[DataMember(Name = "customerInternalNote", EmitDefaultValue = false)]
	public string CustomerInternalNote { get; set; }

	/// <summary>
	///     If true, the net amount of each position will be shown on the creditNote. Otherwise gross amount
	/// </summary>
	/// <value>If true, the net amount of each position will be shown on the creditNote. Otherwise gross amount</value>
	[DataMember(Name = "showNet", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? ShowNet { get; set; }

	/// <summary>
	///     Returns true if ModelCreditNoteUpdate instances are equal
	/// </summary>
	/// <param name="input">Instance of ModelCreditNoteUpdate to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(ModelCreditNoteUpdate input)
	{
		if (input == null)
		{
			return false;
		}

		return
			(
				Id == input.Id ||
				(Id != null &&
				 Id.Equals(input.Id))
			) &&
			(
				ObjectName == input.ObjectName ||
				(ObjectName != null &&
				 ObjectName.Equals(input.ObjectName))
			) &&
			(
				Create == input.Create ||
				(Create != null &&
				 Create.Equals(input.Create))
			) &&
			(
				Update == input.Update ||
				(Update != null &&
				 Update.Equals(input.Update))
			) &&
			(
				CreditNoteNumber == input.CreditNoteNumber ||
				(CreditNoteNumber != null &&
				 CreditNoteNumber.Equals(input.CreditNoteNumber))
			) &&
			(
				Contact == input.Contact ||
				(Contact != null &&
				 Contact.Equals(input.Contact))
			) &&
			(
				CreditNoteDate == input.CreditNoteDate ||
				(CreditNoteDate != null &&
				 CreditNoteDate.Equals(input.CreditNoteDate))
			) &&
			(
				Status == input.Status ||
				(Status != null &&
				 Status.Equals(input.Status))
			) &&
			(
				Header == input.Header ||
				(Header != null &&
				 Header.Equals(input.Header))
			) &&
			(
				HeadText == input.HeadText ||
				(HeadText != null &&
				 HeadText.Equals(input.HeadText))
			) &&
			(
				FootText == input.FootText ||
				(FootText != null &&
				 FootText.Equals(input.FootText))
			) &&
			(
				AddressCountry == input.AddressCountry ||
				(AddressCountry != null &&
				 AddressCountry.Equals(input.AddressCountry))
			) &&
			(
				CreateUser == input.CreateUser ||
				(CreateUser != null &&
				 CreateUser.Equals(input.CreateUser))
			) &&
			(
				SevClient == input.SevClient ||
				(SevClient != null &&
				 SevClient.Equals(input.SevClient))
			) &&
			(
				DeliveryTerms == input.DeliveryTerms ||
				(DeliveryTerms != null &&
				 DeliveryTerms.Equals(input.DeliveryTerms))
			) &&
			(
				DeliveryDate == input.DeliveryDate ||
				(DeliveryDate != null &&
				 DeliveryDate.Equals(input.DeliveryDate))
			) &&
			(
				PaymentTerms == input.PaymentTerms ||
				(PaymentTerms != null &&
				 PaymentTerms.Equals(input.PaymentTerms))
			) &&
			(
				Version == input.Version ||
				(Version != null &&
				 Version.Equals(input.Version))
			) &&
			(
				SmallSettlement == input.SmallSettlement ||
				(SmallSettlement != null &&
				 SmallSettlement.Equals(input.SmallSettlement))
			) &&
			(
				ContactPerson == input.ContactPerson ||
				(ContactPerson != null &&
				 ContactPerson.Equals(input.ContactPerson))
			) &&
			(
				TaxRate == input.TaxRate ||
				(TaxRate != null &&
				 TaxRate.Equals(input.TaxRate))
			) &&
			(
				TaxSet == input.TaxSet ||
				(TaxSet != null &&
				 TaxSet.Equals(input.TaxSet))
			) &&
			(
				TaxText == input.TaxText ||
				(TaxText != null &&
				 TaxText.Equals(input.TaxText))
			) &&
			(
				TaxType == input.TaxType ||
				(TaxType != null &&
				 TaxType.Equals(input.TaxType))
			) &&
			(
				CreditNoteType == input.CreditNoteType ||
				(CreditNoteType != null &&
				 CreditNoteType.Equals(input.CreditNoteType))
			) &&
			(
				SendDate == input.SendDate ||
				(SendDate != null &&
				 SendDate.Equals(input.SendDate))
			) &&
			(
				Address == input.Address ||
				(Address != null &&
				 Address.Equals(input.Address))
			) &&
			(
				Currency == input.Currency ||
				(Currency != null &&
				 Currency.Equals(input.Currency))
			) &&
			(
				SumNet == input.SumNet ||
				(SumNet != null &&
				 SumNet.Equals(input.SumNet))
			) &&
			(
				SumTax == input.SumTax ||
				(SumTax != null &&
				 SumTax.Equals(input.SumTax))
			) &&
			(
				SumGross == input.SumGross ||
				(SumGross != null &&
				 SumGross.Equals(input.SumGross))
			) &&
			(
				SumDiscounts == input.SumDiscounts ||
				(SumDiscounts != null &&
				 SumDiscounts.Equals(input.SumDiscounts))
			) &&
			(
				SumNetForeignCurrency == input.SumNetForeignCurrency ||
				(SumNetForeignCurrency != null &&
				 SumNetForeignCurrency.Equals(input.SumNetForeignCurrency))
			) &&
			(
				SumTaxForeignCurrency == input.SumTaxForeignCurrency ||
				(SumTaxForeignCurrency != null &&
				 SumTaxForeignCurrency.Equals(input.SumTaxForeignCurrency))
			) &&
			(
				SumGrossForeignCurrency == input.SumGrossForeignCurrency ||
				(SumGrossForeignCurrency != null &&
				 SumGrossForeignCurrency.Equals(input.SumGrossForeignCurrency))
			) &&
			(
				SumDiscountsForeignCurrency == input.SumDiscountsForeignCurrency ||
				(SumDiscountsForeignCurrency != null &&
				 SumDiscountsForeignCurrency.Equals(input.SumDiscountsForeignCurrency))
			) &&
			(
				CustomerInternalNote == input.CustomerInternalNote ||
				(CustomerInternalNote != null &&
				 CustomerInternalNote.Equals(input.CustomerInternalNote))
			) &&
			(
				ShowNet == input.ShowNet ||
				(ShowNet != null &&
				 ShowNet.Equals(input.ShowNet))
			) &&
			(
				SendType == input.SendType ||
				(SendType != null &&
				 SendType.Equals(input.SendType))
			);
	}

	/// <summary>
	///     To validate all properties of the instance
	/// </summary>
	/// <param name="validationContext">Validation context</param>
	/// <returns>Validation Result</returns>
	IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
	{
		yield break;
	}


	/// <summary>
	///     Returns the string presentation of the object
	/// </summary>
	/// <returns>String presentation of the object</returns>
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.Append("class ModelCreditNoteUpdate {\n");
		sb.Append("  Id: ").Append(Id).Append("\n");
		sb.Append("  ObjectName: ").Append(ObjectName).Append("\n");
		sb.Append("  Create: ").Append(Create).Append("\n");
		sb.Append("  Update: ").Append(Update).Append("\n");
		sb.Append("  CreditNoteNumber: ").Append(CreditNoteNumber).Append("\n");
		sb.Append("  Contact: ").Append(Contact).Append("\n");
		sb.Append("  CreditNoteDate: ").Append(CreditNoteDate).Append("\n");
		sb.Append("  Status: ").Append(Status).Append("\n");
		sb.Append("  Header: ").Append(Header).Append("\n");
		sb.Append("  HeadText: ").Append(HeadText).Append("\n");
		sb.Append("  FootText: ").Append(FootText).Append("\n");
		sb.Append("  AddressCountry: ").Append(AddressCountry).Append("\n");
		sb.Append("  CreateUser: ").Append(CreateUser).Append("\n");
		sb.Append("  SevClientReference: ").Append(SevClient).Append("\n");
		sb.Append("  DeliveryTerms: ").Append(DeliveryTerms).Append("\n");
		sb.Append("  DeliveryDate: ").Append(DeliveryDate).Append("\n");
		sb.Append("  PaymentTerms: ").Append(PaymentTerms).Append("\n");
		sb.Append("  Version: ").Append(Version).Append("\n");
		sb.Append("  SmallSettlement: ").Append(SmallSettlement).Append("\n");
		sb.Append("  ContactPerson: ").Append(ContactPerson).Append("\n");
		sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
		sb.Append("  TaxSet: ").Append(TaxSet).Append("\n");
		sb.Append("  TaxText: ").Append(TaxText).Append("\n");
		sb.Append("  TaxType: ").Append(TaxType).Append("\n");
		sb.Append("  CreditNoteType: ").Append(CreditNoteType).Append("\n");
		sb.Append("  SendDate: ").Append(SendDate).Append("\n");
		sb.Append("  Address: ").Append(Address).Append("\n");
		sb.Append("  Currency: ").Append(Currency).Append("\n");
		sb.Append("  SumNet: ").Append(SumNet).Append("\n");
		sb.Append("  SumTax: ").Append(SumTax).Append("\n");
		sb.Append("  SumGross: ").Append(SumGross).Append("\n");
		sb.Append("  SumDiscounts: ").Append(SumDiscounts).Append("\n");
		sb.Append("  SumNetForeignCurrency: ").Append(SumNetForeignCurrency).Append("\n");
		sb.Append("  SumTaxForeignCurrency: ").Append(SumTaxForeignCurrency).Append("\n");
		sb.Append("  SumGrossForeignCurrency: ").Append(SumGrossForeignCurrency).Append("\n");
		sb.Append("  SumDiscountsForeignCurrency: ").Append(SumDiscountsForeignCurrency).Append("\n");
		sb.Append("  CustomerInternalNote: ").Append(CustomerInternalNote).Append("\n");
		sb.Append("  ShowNet: ").Append(ShowNet).Append("\n");
		sb.Append("  SendType: ").Append(SendType).Append("\n");
		sb.Append("}\n");
		return sb.ToString();
	}

	/// <summary>
	///     Returns the JSON string presentation of the object
	/// </summary>
	/// <returns>JSON string presentation of the object</returns>
	public virtual string ToJson()
	{
		return JsonConvert.SerializeObject(this, Formatting.Indented);
	}

	/// <summary>
	///     Returns true if objects are equal
	/// </summary>
	/// <param name="input">Object to be compared</param>
	/// <returns>Boolean</returns>
	public override bool Equals(object input)
	{
		return Equals(input as ModelCreditNoteUpdate);
	}

	/// <summary>
	///     Gets the hash code
	/// </summary>
	/// <returns>Hash code</returns>
	public override int GetHashCode()
	{
		unchecked // Overflow is fine, just wrap
		{
			int hashCode = 41;
			if (Id != null)
			{
				hashCode = hashCode * 59 + Id.GetHashCode();
			}

			if (ObjectName != null)
			{
				hashCode = hashCode * 59 + ObjectName.GetHashCode();
			}

			if (Create != null)
			{
				hashCode = hashCode * 59 + Create.GetHashCode();
			}

			if (Update != null)
			{
				hashCode = hashCode * 59 + Update.GetHashCode();
			}

			if (CreditNoteNumber != null)
			{
				hashCode = hashCode * 59 + CreditNoteNumber.GetHashCode();
			}

			if (Contact != null)
			{
				hashCode = hashCode * 59 + Contact.GetHashCode();
			}

			if (CreditNoteDate != null)
			{
				hashCode = hashCode * 59 + CreditNoteDate.GetHashCode();
			}

			if (Status != null)
			{
				hashCode = hashCode * 59 + Status.GetHashCode();
			}

			if (Header != null)
			{
				hashCode = hashCode * 59 + Header.GetHashCode();
			}

			if (HeadText != null)
			{
				hashCode = hashCode * 59 + HeadText.GetHashCode();
			}

			if (FootText != null)
			{
				hashCode = hashCode * 59 + FootText.GetHashCode();
			}

			if (AddressCountry != null)
			{
				hashCode = hashCode * 59 + AddressCountry.GetHashCode();
			}

			if (CreateUser != null)
			{
				hashCode = hashCode * 59 + CreateUser.GetHashCode();
			}

			if (SevClient != null)
			{
				hashCode = hashCode * 59 + SevClient.GetHashCode();
			}

			if (DeliveryTerms != null)
			{
				hashCode = hashCode * 59 + DeliveryTerms.GetHashCode();
			}

			if (DeliveryDate != null)
			{
				hashCode = hashCode * 59 + DeliveryDate.GetHashCode();
			}

			if (PaymentTerms != null)
			{
				hashCode = hashCode * 59 + PaymentTerms.GetHashCode();
			}

			if (Version != null)
			{
				hashCode = hashCode * 59 + Version.GetHashCode();
			}

			if (SmallSettlement != null)
			{
				hashCode = hashCode * 59 + SmallSettlement.GetHashCode();
			}

			if (ContactPerson != null)
			{
				hashCode = hashCode * 59 + ContactPerson.GetHashCode();
			}

			if (TaxRate != null)
			{
				hashCode = hashCode * 59 + TaxRate.GetHashCode();
			}

			if (TaxSet != null)
			{
				hashCode = hashCode * 59 + TaxSet.GetHashCode();
			}

			if (TaxText != null)
			{
				hashCode = hashCode * 59 + TaxText.GetHashCode();
			}

			if (TaxType != null)
			{
				hashCode = hashCode * 59 + TaxType.GetHashCode();
			}

			if (CreditNoteType != null)
			{
				hashCode = hashCode * 59 + CreditNoteType.GetHashCode();
			}

			if (SendDate != null)
			{
				hashCode = hashCode * 59 + SendDate.GetHashCode();
			}

			if (Address != null)
			{
				hashCode = hashCode * 59 + Address.GetHashCode();
			}

			if (Currency != null)
			{
				hashCode = hashCode * 59 + Currency.GetHashCode();
			}

			if (SumNet != null)
			{
				hashCode = hashCode * 59 + SumNet.GetHashCode();
			}

			if (SumTax != null)
			{
				hashCode = hashCode * 59 + SumTax.GetHashCode();
			}

			if (SumGross != null)
			{
				hashCode = hashCode * 59 + SumGross.GetHashCode();
			}

			if (SumDiscounts != null)
			{
				hashCode = hashCode * 59 + SumDiscounts.GetHashCode();
			}

			if (SumNetForeignCurrency != null)
			{
				hashCode = hashCode * 59 + SumNetForeignCurrency.GetHashCode();
			}

			if (SumTaxForeignCurrency != null)
			{
				hashCode = hashCode * 59 + SumTaxForeignCurrency.GetHashCode();
			}

			if (SumGrossForeignCurrency != null)
			{
				hashCode = hashCode * 59 + SumGrossForeignCurrency.GetHashCode();
			}

			if (SumDiscountsForeignCurrency != null)
			{
				hashCode = hashCode * 59 + SumDiscountsForeignCurrency.GetHashCode();
			}

			if (CustomerInternalNote != null)
			{
				hashCode = hashCode * 59 + CustomerInternalNote.GetHashCode();
			}

			if (ShowNet != null)
			{
				hashCode = hashCode * 59 + ShowNet.GetHashCode();
			}

			if (SendType != null)
			{
				hashCode = hashCode * 59 + SendType.GetHashCode();
			}

			return hashCode;
		}
	}
}
