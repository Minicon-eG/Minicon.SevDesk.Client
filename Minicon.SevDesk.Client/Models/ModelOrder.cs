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
///     Order model
/// </summary>
[DataContract]
public class ModelOrder : IEquatable<ModelOrder>, IValidatableObject
{
	/// <summary>
	///     Type of the order. For more information on the different types, check      &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-orders&#x27;&gt;this&lt;/a&gt;
	/// </summary>
	/// <value>
	///     Type of the order. For more information on the different types, check      &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-orders&#x27;&gt;this&lt;/a&gt;
	/// </value>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum OrderTypeEnum
	{
		/// <summary>
		///     Enum AN for value: AN
		/// </summary>
		[EnumMember(Value = "AN")] AN = 1,

		/// <summary>
		///     Enum AB for value: AB
		/// </summary>
		[EnumMember(Value = "AB")] AB = 2,

		/// <summary>
		///     Enum LI for value: LI
		/// </summary>
		[EnumMember(Value = "LI")] LI = 3
	}

	/// <summary>
	///     Type which was used to send the order. IMPORTANT: Please refer to the order section of the       *     API-Overview
	///     to understand how this attribute can be used before using it!
	/// </summary>
	/// <value>
	///     Type which was used to send the order. IMPORTANT: Please refer to the order section of the       *
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
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-orders&#x27;
	///     &gt;status of orders&lt;/a&gt;      to see what the different status codes mean
	/// </summary>
	/// <value>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-orders
	///     &#x27;&gt;status of orders&lt;/a&gt;      to see what the different status codes mean
	/// </value>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum StatusEnum
	{
		/// <summary>
		///     Enum NUMBER_100 for value: 100
		/// </summary>
		[EnumMember(Value = "100")] NUMBER_100 = 1,

		/// <summary>
		///     Enum NUMBER_200 for value: 200
		/// </summary>
		[EnumMember(Value = "200")] NUMBER_200 = 2,

		/// <summary>
		///     Enum NUMBER_300 for value: 300
		/// </summary>
		[EnumMember(Value = "300")] NUMBER_300 = 3,

		/// <summary>
		///     Enum NUMBER_500 for value: 500
		/// </summary>
		[EnumMember(Value = "500")] NUMBER_500 = 4,

		/// <summary>
		///     Enum NUMBER_750 for value: 750
		/// </summary>
		[EnumMember(Value = "750")] NUMBER_750 = 5,

		/// <summary>
		///     Enum NUMBER_1000 for value: 1000
		/// </summary>
		[EnumMember(Value = "1000")] NUMBER_1000 = 6
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="ModelOrder" /> class.
	/// </summary>
	/// <param name="objectName">The order object name.</param>
	/// <param name="mapAll">mapAll (required).</param>
	/// <param name="orderNumber">The order number (required).</param>
	/// <param name="contact">contact (required).</param>
	/// <param name="orderDate">Needs to be provided as timestamp or dd.mm.yyyy (required).</param>
	/// <param name="status">
	///     Please have a look in       &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-orders&#x27;&gt;status of orders&lt;/a&gt;      to see what the
	///     different status codes mean (required).
	/// </param>
	/// <param name="header">Normally consist of prefix plus the order number (required).</param>
	/// <param name="headText">Certain html tags can be used here to format your text.</param>
	/// <param name="footText">Certain html tags can be used here to format your text.</param>
	/// <param name="addressCountry">addressCountry (required).</param>
	/// <param name="deliveryTerms">Delivery terms of the order.</param>
	/// <param name="paymentTerms">Payment terms of the order.</param>
	/// <param name="version">
	///     Version of the order.&lt;br&gt;      Can be used if you have multiple drafts for the same order.
	///     &lt;br&gt;      Should start with 0 (required).
	/// </param>
	/// <param name="smallSettlement">
	///     Defines if the client uses the small settlement scheme.      If yes, the order must not
	///     contain any vat.
	/// </param>
	/// <param name="contactPerson">contactPerson (required).</param>
	/// <param name="taxRate">Is overwritten by order position tax rates (required).</param>
	/// <param name="taxSet">taxSet.</param>
	/// <param name="taxText">A common tax text would be &#x27;Umsatzsteuer 19%&#x27; (required).</param>
	/// <param name="taxType">
	///     Tax type of the order. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu -
	///     Steuerfreie innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des
	///     Leistungsempfängers (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT
	///     according to §19 1 UStG Tax rates are heavily connected to the tax type used. (required).
	/// </param>
	/// <param name="orderType">
	///     Type of the order. For more information on the different types, check      &lt;a href&#x3D;
	///     &#x27;https://api.sevdesk.de/#section/Types-and-status-of-orders&#x27;&gt;this&lt;/a&gt;   .
	/// </param>
	/// <param name="sendDate">The date the order was sent to the customer.</param>
	/// <param name="address">
	///     Complete address of the recipient including name, street, city, zip and country.&lt;br&gt;
	///     Line breaks can be used and will be displayed on the invoice pdf..
	/// </param>
	/// <param name="currency">Currency used in the order. Needs to be currency code according to ISO-4217 (required).</param>
	/// <param name="customerInternalNote">
	///     Internal note of the customer. Contains data entered into field &#x27;
	///     Referenz/Bestellnummer&#x27;.
	/// </param>
	/// <param name="showNet">If true, the net amount of each position will be shown on the order. Otherwise gross amount.</param>
	/// <param name="sendType">
	///     Type which was used to send the order. IMPORTANT: Please refer to the order section of the
	///     *     API-Overview to understand how this attribute can be used before using it!.
	/// </param>
	/// <param name="origin">origin.</param>
	public ModelOrder(string objectName = default, bool? mapAll = default, string orderNumber = default,
		ModelOrderContact contact = default, DateTime? orderDate = default, StatusEnum status = default,
		string header = default, string headText = default, string footText = default,
		ModelOrderAddressCountry addressCountry = default, string deliveryTerms = default,
		string paymentTerms = default, int? version = default, bool? smallSettlement = default,
		ModelOrderContactPerson contactPerson = default, decimal? taxRate = default, ModelOrderTaxSet taxSet = default,
		string taxText = default, string taxType = default, OrderTypeEnum? orderType = default,
		DateTime? sendDate = default, string address = default, string currency = default,
		string customerInternalNote = default, bool? showNet = default, SendTypeEnum? sendType = default,
		ModelOrderOrigin origin = default)
	{
		// to ensure "mapAll" is required (not null)
		if (mapAll == null)
		{
			throw new InvalidDataException("mapAll is a required property for ModelOrder and cannot be null");
		}

		MapAll = mapAll;
		// to ensure "orderNumber" is required (not null)
		if (orderNumber == null)
		{
			throw new InvalidDataException("orderNumber is a required property for ModelOrder and cannot be null");
		}

		OrderNumber = orderNumber;
		// to ensure "contact" is required (not null)
		if (contact == null)
		{
			throw new InvalidDataException("contact is a required property for ModelOrder and cannot be null");
		}

		Contact = contact;
		// to ensure "orderDate" is required (not null)
		if (orderDate == null)
		{
			throw new InvalidDataException("orderDate is a required property for ModelOrder and cannot be null");
		}

		OrderDate = orderDate;
		// to ensure "status" is required (not null)
		if (status == null)
		{
			throw new InvalidDataException("status is a required property for ModelOrder and cannot be null");
		}

		Status = status;
		// to ensure "header" is required (not null)
		if (header == null)
		{
			throw new InvalidDataException("header is a required property for ModelOrder and cannot be null");
		}

		Header = header;
		// to ensure "addressCountry" is required (not null)
		if (addressCountry == null)
		{
			throw new InvalidDataException("addressCountry is a required property for ModelOrder and cannot be null");
		}

		AddressCountry = addressCountry;
		// to ensure "version" is required (not null)
		if (version == null)
		{
			throw new InvalidDataException("version is a required property for ModelOrder and cannot be null");
		}

		Version = version;
		// to ensure "contactPerson" is required (not null)
		if (contactPerson == null)
		{
			throw new InvalidDataException("contactPerson is a required property for ModelOrder and cannot be null");
		}

		ContactPerson = contactPerson;
		// to ensure "taxRate" is required (not null)
		if (taxRate == null)
		{
			throw new InvalidDataException("taxRate is a required property for ModelOrder and cannot be null");
		}

		TaxRate = taxRate;
		// to ensure "taxText" is required (not null)
		if (taxText == null)
		{
			throw new InvalidDataException("taxText is a required property for ModelOrder and cannot be null");
		}

		TaxText = taxText;
		// to ensure "taxType" is required (not null)
		if (taxType == null)
		{
			throw new InvalidDataException("taxType is a required property for ModelOrder and cannot be null");
		}

		TaxType = taxType;
		// to ensure "currency" is required (not null)
		if (currency == null)
		{
			throw new InvalidDataException("currency is a required property for ModelOrder and cannot be null");
		}

		Currency = currency;
		ObjectName = objectName;
		HeadText = headText;
		FootText = footText;
		DeliveryTerms = deliveryTerms;
		PaymentTerms = paymentTerms;
		SmallSettlement = smallSettlement;
		TaxSet = taxSet;
		OrderType = orderType;
		SendDate = sendDate;
		Address = address;
		CustomerInternalNote = customerInternalNote;
		ShowNet = showNet;
		SendType = sendType;
		Origin = origin;
	}

	/// <summary>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-orders&#x27;
	///     &gt;status of orders&lt;/a&gt;      to see what the different status codes mean
	/// </summary>
	/// <value>
	///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-orders
	///     &#x27;&gt;status of orders&lt;/a&gt;      to see what the different status codes mean
	/// </value>
	[DataMember(Name = "status", EmitDefaultValue = false)]
	public StatusEnum Status { get; set; }

	/// <summary>
	///     Type of the order. For more information on the different types, check      &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-orders&#x27;&gt;this&lt;/a&gt;
	/// </summary>
	/// <value>
	///     Type of the order. For more information on the different types, check      &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/Types-and-status-of-orders&#x27;&gt;this&lt;/a&gt;
	/// </value>
	[DataMember(Name = "orderType", EmitDefaultValue = false)]
	public OrderTypeEnum? OrderType { get; set; }

	/// <summary>
	///     Type which was used to send the order. IMPORTANT: Please refer to the order section of the       *     API-Overview
	///     to understand how this attribute can be used before using it!
	/// </summary>
	/// <value>
	///     Type which was used to send the order. IMPORTANT: Please refer to the order section of the       *
	///     API-Overview to understand how this attribute can be used before using it!
	/// </value>
	[DataMember(Name = "sendType", EmitDefaultValue = false)]
	public SendTypeEnum? SendType { get; set; }

	/// <summary>
	///     The order id
	/// </summary>
	/// <value>The order id</value>
	[DataMember(Name = "id", EmitDefaultValue = false)]
	public int? Id { get; private set; }

	/// <summary>
	///     The order object name
	/// </summary>
	/// <value>The order object name</value>
	[DataMember(Name = "objectName", EmitDefaultValue = false)]
	public string ObjectName { get; set; }

	/// <summary>
	///     Gets or Sets MapAll
	/// </summary>
	[DataMember(Name = "mapAll", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? MapAll { get; set; }

	/// <summary>
	///     Date of order creation
	/// </summary>
	/// <value>Date of order creation</value>
	[DataMember(Name = "create", EmitDefaultValue = false)]
	public DateTime? Create { get; private set; }

	/// <summary>
	///     Date of last order update
	/// </summary>
	/// <value>Date of last order update</value>
	[DataMember(Name = "update", EmitDefaultValue = false)]
	public DateTime? Update { get; private set; }

	/// <summary>
	///     The order number
	/// </summary>
	/// <value>The order number</value>
	[DataMember(Name = "orderNumber", EmitDefaultValue = false)]
	public string OrderNumber { get; set; }

	/// <summary>
	///     Gets or Sets Contact
	/// </summary>
	[DataMember(Name = "contact", EmitDefaultValue = false)]
	public ModelOrderContact Contact { get; set; }

	/// <summary>
	///     Needs to be provided as timestamp or dd.mm.yyyy
	/// </summary>
	/// <value>Needs to be provided as timestamp or dd.mm.yyyy</value>
	[DataMember(Name = "orderDate", EmitDefaultValue = false)]
	public DateTime? OrderDate { get; set; }


	/// <summary>
	///     Normally consist of prefix plus the order number
	/// </summary>
	/// <value>Normally consist of prefix plus the order number</value>
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
	public ModelOrderAddressCountry AddressCountry { get; set; }

	/// <summary>
	///     Delivery terms of the order
	/// </summary>
	/// <value>Delivery terms of the order</value>
	[DataMember(Name = "deliveryTerms", EmitDefaultValue = false)]
	public string DeliveryTerms { get; set; }

	/// <summary>
	///     Payment terms of the order
	/// </summary>
	/// <value>Payment terms of the order</value>
	[DataMember(Name = "paymentTerms", EmitDefaultValue = false)]
	public string PaymentTerms { get; set; }

	/// <summary>
	///     Version of the order.&lt;br&gt;      Can be used if you have multiple drafts for the same order.&lt;br&gt;
	///     Should start with 0
	/// </summary>
	/// <value>
	///     Version of the order.&lt;br&gt;      Can be used if you have multiple drafts for the same order.&lt;br&gt;
	///     Should start with 0
	/// </value>
	[DataMember(Name = "version", EmitDefaultValue = false)]
	public int? Version { get; set; }

	/// <summary>
	///     Defines if the client uses the small settlement scheme.      If yes, the order must not contain any vat
	/// </summary>
	/// <value>Defines if the client uses the small settlement scheme.      If yes, the order must not contain any vat</value>
	[DataMember(Name = "smallSettlement", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? SmallSettlement { get; set; }

	/// <summary>
	///     Gets or Sets ContactPerson
	/// </summary>
	[DataMember(Name = "contactPerson", EmitDefaultValue = false)]
	public ModelOrderContactPerson ContactPerson { get; set; }

	/// <summary>
	///     Is overwritten by order position tax rates
	/// </summary>
	/// <value>Is overwritten by order position tax rates</value>
	[DataMember(Name = "taxRate", EmitDefaultValue = false)]
	public decimal? TaxRate { get; set; }

	/// <summary>
	///     Gets or Sets TaxSet
	/// </summary>
	[DataMember(Name = "taxSet", EmitDefaultValue = false)]
	public ModelOrderTaxSet TaxSet { get; set; }

	/// <summary>
	///     A common tax text would be &#x27;Umsatzsteuer 19%&#x27;
	/// </summary>
	/// <value>A common tax text would be &#x27;Umsatzsteuer 19%&#x27;</value>
	[DataMember(Name = "taxText", EmitDefaultValue = false)]
	public string TaxText { get; set; }

	/// <summary>
	///     Tax type of the order. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu - Steuerfreie
	///     innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des Leistungsempfängers
	///     (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT according to §19 1 UStG
	///     Tax rates are heavily connected to the tax type used.
	/// </summary>
	/// <value>
	///     Tax type of the order. There are four tax types: 1. default - Umsatzsteuer ausweisen 2. eu - Steuerfreie
	///     innergemeinschaftliche Lieferung (Europäische Union) 3. noteu - Steuerschuldnerschaft des Leistungsempfängers
	///     (außerhalb EU, z. B. Schweiz) 4. custom - Using custom tax set 5. ss - Not subject to VAT according to §19 1 UStG
	///     Tax rates are heavily connected to the tax type used.
	/// </value>
	[DataMember(Name = "taxType", EmitDefaultValue = false)]
	public string TaxType { get; set; }


	/// <summary>
	///     The date the order was sent to the customer
	/// </summary>
	/// <value>The date the order was sent to the customer</value>
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
	///     Currency used in the order. Needs to be currency code according to ISO-4217
	/// </summary>
	/// <value>Currency used in the order. Needs to be currency code according to ISO-4217</value>
	[DataMember(Name = "currency", EmitDefaultValue = false)]
	public string Currency { get; set; }

	/// <summary>
	///     Internal note of the customer. Contains data entered into field &#x27;Referenz/Bestellnummer&#x27;
	/// </summary>
	/// <value>Internal note of the customer. Contains data entered into field &#x27;Referenz/Bestellnummer&#x27;</value>
	[DataMember(Name = "customerInternalNote", EmitDefaultValue = false)]
	public string CustomerInternalNote { get; set; }

	/// <summary>
	///     If true, the net amount of each position will be shown on the order. Otherwise gross amount
	/// </summary>
	/// <value>If true, the net amount of each position will be shown on the order. Otherwise gross amount</value>
	[DataMember(Name = "showNet", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? ShowNet { get; set; }


	/// <summary>
	///     Gets or Sets Origin
	/// </summary>
	[DataMember(Name = "origin", EmitDefaultValue = false)]
	public ModelOrderOrigin Origin { get; set; }

	/// <summary>
	///     Returns true if ModelOrder instances are equal
	/// </summary>
	/// <param name="input">Instance of ModelOrder to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(ModelOrder input)
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
				MapAll == input.MapAll ||
				(MapAll != null &&
				 MapAll.Equals(input.MapAll))
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
				OrderNumber == input.OrderNumber ||
				(OrderNumber != null &&
				 OrderNumber.Equals(input.OrderNumber))
			) &&
			(
				Contact == input.Contact ||
				(Contact != null &&
				 Contact.Equals(input.Contact))
			) &&
			(
				OrderDate == input.OrderDate ||
				(OrderDate != null &&
				 OrderDate.Equals(input.OrderDate))
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
				DeliveryTerms == input.DeliveryTerms ||
				(DeliveryTerms != null &&
				 DeliveryTerms.Equals(input.DeliveryTerms))
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
				OrderType == input.OrderType ||
				(OrderType != null &&
				 OrderType.Equals(input.OrderType))
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
			) &&
			(
				Origin == input.Origin ||
				(Origin != null &&
				 Origin.Equals(input.Origin))
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
		sb.Append("class ModelOrder {\n");
		sb.Append("  Id: ").Append(Id).Append("\n");
		sb.Append("  ObjectName: ").Append(ObjectName).Append("\n");
		sb.Append("  MapAll: ").Append(MapAll).Append("\n");
		sb.Append("  Create: ").Append(Create).Append("\n");
		sb.Append("  Update: ").Append(Update).Append("\n");
		sb.Append("  OrderNumber: ").Append(OrderNumber).Append("\n");
		sb.Append("  Contact: ").Append(Contact).Append("\n");
		sb.Append("  OrderDate: ").Append(OrderDate).Append("\n");
		sb.Append("  Status: ").Append(Status).Append("\n");
		sb.Append("  Header: ").Append(Header).Append("\n");
		sb.Append("  HeadText: ").Append(HeadText).Append("\n");
		sb.Append("  FootText: ").Append(FootText).Append("\n");
		sb.Append("  AddressCountry: ").Append(AddressCountry).Append("\n");
		sb.Append("  DeliveryTerms: ").Append(DeliveryTerms).Append("\n");
		sb.Append("  PaymentTerms: ").Append(PaymentTerms).Append("\n");
		sb.Append("  Version: ").Append(Version).Append("\n");
		sb.Append("  SmallSettlement: ").Append(SmallSettlement).Append("\n");
		sb.Append("  ContactPerson: ").Append(ContactPerson).Append("\n");
		sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
		sb.Append("  TaxSet: ").Append(TaxSet).Append("\n");
		sb.Append("  TaxText: ").Append(TaxText).Append("\n");
		sb.Append("  TaxType: ").Append(TaxType).Append("\n");
		sb.Append("  OrderType: ").Append(OrderType).Append("\n");
		sb.Append("  SendDate: ").Append(SendDate).Append("\n");
		sb.Append("  Address: ").Append(Address).Append("\n");
		sb.Append("  Currency: ").Append(Currency).Append("\n");
		sb.Append("  CustomerInternalNote: ").Append(CustomerInternalNote).Append("\n");
		sb.Append("  ShowNet: ").Append(ShowNet).Append("\n");
		sb.Append("  SendType: ").Append(SendType).Append("\n");
		sb.Append("  Origin: ").Append(Origin).Append("\n");
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
		return Equals(input as ModelOrder);
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

			if (MapAll != null)
			{
				hashCode = hashCode * 59 + MapAll.GetHashCode();
			}

			if (Create != null)
			{
				hashCode = hashCode * 59 + Create.GetHashCode();
			}

			if (Update != null)
			{
				hashCode = hashCode * 59 + Update.GetHashCode();
			}

			if (OrderNumber != null)
			{
				hashCode = hashCode * 59 + OrderNumber.GetHashCode();
			}

			if (Contact != null)
			{
				hashCode = hashCode * 59 + Contact.GetHashCode();
			}

			if (OrderDate != null)
			{
				hashCode = hashCode * 59 + OrderDate.GetHashCode();
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

			if (DeliveryTerms != null)
			{
				hashCode = hashCode * 59 + DeliveryTerms.GetHashCode();
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

			if (OrderType != null)
			{
				hashCode = hashCode * 59 + OrderType.GetHashCode();
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

			if (Origin != null)
			{
				hashCode = hashCode * 59 + Origin.GetHashCode();
			}

			return hashCode;
		}
	}
}
