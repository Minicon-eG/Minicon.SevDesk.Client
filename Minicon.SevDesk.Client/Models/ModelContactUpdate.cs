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
///     Contact model
/// </summary>
[DataContract]
public class ModelContactUpdate : IEquatable<ModelContactUpdate>, IValidatableObject
{
	/// <summary>
	///     Defines which tax regulation the contact is using.
	/// </summary>
	/// <value>Defines which tax regulation the contact is using.</value>
	[JsonConverter(typeof(StringEnumConverter))]
	public enum TaxTypeEnum
	{
		/// <summary>
		///     Enum Default for value: default
		/// </summary>
		[EnumMember(Value = "default")] Default = 1,

		/// <summary>
		///     Enum Eu for value: eu
		/// </summary>
		[EnumMember(Value = "eu")] Eu = 2,

		/// <summary>
		///     Enum Noteu for value: noteu
		/// </summary>
		[EnumMember(Value = "noteu")] Noteu = 3,

		/// <summary>
		///     Enum Custom for value: custom
		/// </summary>
		[EnumMember(Value = "custom")] Custom = 4,

		/// <summary>
		///     Enum Ss for value: ss
		/// </summary>
		[EnumMember(Value = "ss")] Ss = 5
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="ModelContactUpdate" /> class.
	/// </summary>
	/// <param name="name">
	///     The organization name.&lt;br&gt; Be aware that the type of contact will depend on this attribute.
	///     &lt;br&gt; If it holds a value, the contact will be regarded as an organization..
	/// </param>
	/// <param name="status">
	///     Defines the status of the contact. 100 &lt;-&gt; Lead - 500 &lt;-&gt; Pending - 1000 &lt;-&gt;
	///     Active. (default to 100).
	/// </param>
	/// <param name="customerNumber">The customer number.</param>
	/// <param name="parent">parent.</param>
	/// <param name="surename">
	///     The &lt;b&gt;first&lt;/b&gt; name of the contact.&lt;br&gt; Yeah... not quite right in literally
	///     every way. We know.&lt;br&gt; Not to be used for organizations..
	/// </param>
	/// <param name="familyname">The last name of the contact.&lt;br&gt; Not to be used for organizations..</param>
	/// <param name="titel">A non-academic title for the contact. Not to be used for organizations..</param>
	/// <param name="category">category.</param>
	/// <param name="description">A description for the contact..</param>
	/// <param name="academicTitle">A academic title for the contact. Not to be used for organizations..</param>
	/// <param name="gender">Gender of the contact.&lt;br&gt; Not to be used for organizations..</param>
	/// <param name="name2">Second name of the contact.&lt;br&gt; Not to be used for organizations..</param>
	/// <param name="birthday">Birthday of the contact.&lt;br&gt; Not to be used for organizations..</param>
	/// <param name="vatNumber">Vat number of the contact..</param>
	/// <param name="bankAccount">Bank account number (IBAN) of the contact..</param>
	/// <param name="bankNumber">Bank number of the bank used by the contact..</param>
	/// <param name="defaultCashbackTime">
	///     Absolute time in days which the contact has to pay his invoices and subsequently get
	///     a cashback..
	/// </param>
	/// <param name="defaultCashbackPercent">Percentage of the invoice sum the contact gets back if he payed invoices in time..</param>
	/// <param name="defaultTimeToPay">The payment goal in days which is set for every invoice of the contact..</param>
	/// <param name="taxNumber">The tax number of the contact..</param>
	/// <param name="taxOffice">The tax office of the contact (only for greek customers)..</param>
	/// <param name="exemptVat">Defines if the contact is freed from paying vat..</param>
	/// <param name="taxType">Defines which tax regulation the contact is using..</param>
	/// <param name="taxSet">taxSet.</param>
	/// <param name="defaultDiscountAmount">
	///     The default discount the contact gets for every invoice.&lt;br&gt; Depending on
	///     defaultDiscountPercentage attribute, in percent or absolute value..
	/// </param>
	/// <param name="defaultDiscountPercentage">Defines if the discount is a percentage (true) or an absolute value (false)..</param>
	/// <param name="buyerReference">Buyer reference of the contact..</param>
	/// <param name="governmentAgency">Defines whether the contact is a government agency (true) or not (false)..</param>
	public ModelContactUpdate(string name = default, int? status = 100, string customerNumber = default,
		ModelContactUpdateParent parent = default, string surename = default, string familyname = default,
		string titel = default, ModelContactUpdateCategory category = default, string description = default,
		string academicTitle = default, string gender = default, string name2 = default, DateTime? birthday = default,
		string vatNumber = default, string bankAccount = default, string bankNumber = default,
		int? defaultCashbackTime = default, float? defaultCashbackPercent = default, int? defaultTimeToPay = default,
		string taxNumber = default, string taxOffice = default, bool? exemptVat = default,
		TaxTypeEnum? taxType = default, ModelContactTaxSet taxSet = default, float? defaultDiscountAmount = default,
		bool? defaultDiscountPercentage = default, string buyerReference = default, bool? governmentAgency = default)
	{
		Name = name;
		// use default value if no "status" provided
		if (status == null)
		{
			Status = 100;
		}
		else
		{
			Status = status;
		}

		CustomerNumber = customerNumber;
		Parent = parent;
		Surename = surename;
		Familyname = familyname;
		Titel = titel;
		Category = category;
		Description = description;
		AcademicTitle = academicTitle;
		Gender = gender;
		Name2 = name2;
		Birthday = birthday;
		VatNumber = vatNumber;
		BankAccount = bankAccount;
		BankNumber = bankNumber;
		DefaultCashbackTime = defaultCashbackTime;
		DefaultCashbackPercent = defaultCashbackPercent;
		DefaultTimeToPay = defaultTimeToPay;
		TaxNumber = taxNumber;
		TaxOffice = taxOffice;
		ExemptVat = exemptVat;
		TaxType = taxType;
		TaxSet = taxSet;
		DefaultDiscountAmount = defaultDiscountAmount;
		DefaultDiscountPercentage = defaultDiscountPercentage;
		BuyerReference = buyerReference;
		GovernmentAgency = governmentAgency;
	}

	/// <summary>
	///     Defines which tax regulation the contact is using.
	/// </summary>
	/// <value>Defines which tax regulation the contact is using.</value>
	[DataMember(Name = "taxType", EmitDefaultValue = false)]
	public TaxTypeEnum? TaxType { get; set; }

	/// <summary>
	///     The organization name.&lt;br&gt; Be aware that the type of contact will depend on this attribute.&lt;br&gt; If it
	///     holds a value, the contact will be regarded as an organization.
	/// </summary>
	/// <value>
	///     The organization name.&lt;br&gt; Be aware that the type of contact will depend on this attribute.&lt;br&gt; If
	///     it holds a value, the contact will be regarded as an organization.
	/// </value>
	[DataMember(Name = "name", EmitDefaultValue = false)]
	public string Name { get; set; }

	/// <summary>
	///     Defines the status of the contact. 100 &lt;-&gt; Lead - 500 &lt;-&gt; Pending - 1000 &lt;-&gt; Active.
	/// </summary>
	/// <value>Defines the status of the contact. 100 &lt;-&gt; Lead - 500 &lt;-&gt; Pending - 1000 &lt;-&gt; Active.</value>
	[DataMember(Name = "status", EmitDefaultValue = false)]
	public int? Status { get; set; }

	/// <summary>
	///     The customer number
	/// </summary>
	/// <value>The customer number</value>
	[DataMember(Name = "customerNumber", EmitDefaultValue = false)]
	public string CustomerNumber { get; set; }

	/// <summary>
	///     Gets or Sets Parent
	/// </summary>
	[DataMember(Name = "parent", EmitDefaultValue = false)]
	public ModelContactUpdateParent Parent { get; set; }

	/// <summary>
	///     The &lt;b&gt;first&lt;/b&gt; name of the contact.&lt;br&gt; Yeah... not quite right in literally every way. We
	///     know.&lt;br&gt; Not to be used for organizations.
	/// </summary>
	/// <value>
	///     The &lt;b&gt;first&lt;/b&gt; name of the contact.&lt;br&gt; Yeah... not quite right in literally every way. We
	///     know.&lt;br&gt; Not to be used for organizations.
	/// </value>
	[DataMember(Name = "surename", EmitDefaultValue = false)]
	public string Surename { get; set; }

	/// <summary>
	///     The last name of the contact.&lt;br&gt; Not to be used for organizations.
	/// </summary>
	/// <value>The last name of the contact.&lt;br&gt; Not to be used for organizations.</value>
	[DataMember(Name = "familyname", EmitDefaultValue = false)]
	public string Familyname { get; set; }

	/// <summary>
	///     A non-academic title for the contact. Not to be used for organizations.
	/// </summary>
	/// <value>A non-academic title for the contact. Not to be used for organizations.</value>
	[DataMember(Name = "titel", EmitDefaultValue = false)]
	public string Titel { get; set; }

	/// <summary>
	///     Gets or Sets Category
	/// </summary>
	[DataMember(Name = "category", EmitDefaultValue = false)]
	public ModelContactUpdateCategory Category { get; set; }

	/// <summary>
	///     A description for the contact.
	/// </summary>
	/// <value>A description for the contact.</value>
	[DataMember(Name = "description", EmitDefaultValue = false)]
	public string Description { get; set; }

	/// <summary>
	///     A academic title for the contact. Not to be used for organizations.
	/// </summary>
	/// <value>A academic title for the contact. Not to be used for organizations.</value>
	[DataMember(Name = "academicTitle", EmitDefaultValue = false)]
	public string AcademicTitle { get; set; }

	/// <summary>
	///     Gender of the contact.&lt;br&gt; Not to be used for organizations.
	/// </summary>
	/// <value>Gender of the contact.&lt;br&gt; Not to be used for organizations.</value>
	[DataMember(Name = "gender", EmitDefaultValue = false)]
	public string Gender { get; set; }

	/// <summary>
	///     Second name of the contact.&lt;br&gt; Not to be used for organizations.
	/// </summary>
	/// <value>Second name of the contact.&lt;br&gt; Not to be used for organizations.</value>
	[DataMember(Name = "name2", EmitDefaultValue = false)]
	public string Name2 { get; set; }

	/// <summary>
	///     Birthday of the contact.&lt;br&gt; Not to be used for organizations.
	/// </summary>
	/// <value>Birthday of the contact.&lt;br&gt; Not to be used for organizations.</value>
	[DataMember(Name = "birthday", EmitDefaultValue = false)]
	[JsonConverter(typeof(SwaggerDateConverter))]
	public DateTime? Birthday { get; set; }

	/// <summary>
	///     Vat number of the contact.
	/// </summary>
	/// <value>Vat number of the contact.</value>
	[DataMember(Name = "vatNumber", EmitDefaultValue = false)]
	public string VatNumber { get; set; }

	/// <summary>
	///     Bank account number (IBAN) of the contact.
	/// </summary>
	/// <value>Bank account number (IBAN) of the contact.</value>
	[DataMember(Name = "bankAccount", EmitDefaultValue = false)]
	public string BankAccount { get; set; }

	/// <summary>
	///     Bank number of the bank used by the contact.
	/// </summary>
	/// <value>Bank number of the bank used by the contact.</value>
	[DataMember(Name = "bankNumber", EmitDefaultValue = false)]
	public string BankNumber { get; set; }

	/// <summary>
	///     Absolute time in days which the contact has to pay his invoices and subsequently get a cashback.
	/// </summary>
	/// <value>Absolute time in days which the contact has to pay his invoices and subsequently get a cashback.</value>
	[DataMember(Name = "defaultCashbackTime", EmitDefaultValue = false)]
	public int? DefaultCashbackTime { get; set; }

	/// <summary>
	///     Percentage of the invoice sum the contact gets back if he payed invoices in time.
	/// </summary>
	/// <value>Percentage of the invoice sum the contact gets back if he payed invoices in time.</value>
	[DataMember(Name = "defaultCashbackPercent", EmitDefaultValue = false)]
	public float? DefaultCashbackPercent { get; set; }

	/// <summary>
	///     The payment goal in days which is set for every invoice of the contact.
	/// </summary>
	/// <value>The payment goal in days which is set for every invoice of the contact.</value>
	[DataMember(Name = "defaultTimeToPay", EmitDefaultValue = false)]
	public int? DefaultTimeToPay { get; set; }

	/// <summary>
	///     The tax number of the contact.
	/// </summary>
	/// <value>The tax number of the contact.</value>
	[DataMember(Name = "taxNumber", EmitDefaultValue = false)]
	public string TaxNumber { get; set; }

	/// <summary>
	///     The tax office of the contact (only for greek customers).
	/// </summary>
	/// <value>The tax office of the contact (only for greek customers).</value>
	[DataMember(Name = "taxOffice", EmitDefaultValue = false)]
	public string TaxOffice { get; set; }

	/// <summary>
	///     Defines if the contact is freed from paying vat.
	/// </summary>
	/// <value>Defines if the contact is freed from paying vat.</value>
	[DataMember(Name = "exemptVat", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? ExemptVat { get; set; }


	/// <summary>
	///     Gets or Sets TaxSet
	/// </summary>
	[DataMember(Name = "taxSet", EmitDefaultValue = false)]
	public ModelContactTaxSet TaxSet { get; set; }

	/// <summary>
	///     The default discount the contact gets for every invoice.&lt;br&gt; Depending on defaultDiscountPercentage
	///     attribute, in percent or absolute value.
	/// </summary>
	/// <value>
	///     The default discount the contact gets for every invoice.&lt;br&gt; Depending on defaultDiscountPercentage
	///     attribute, in percent or absolute value.
	/// </value>
	[DataMember(Name = "defaultDiscountAmount", EmitDefaultValue = false)]
	public float? DefaultDiscountAmount { get; set; }

	/// <summary>
	///     Defines if the discount is a percentage (true) or an absolute value (false).
	/// </summary>
	/// <value>Defines if the discount is a percentage (true) or an absolute value (false).</value>
	[DataMember(Name = "defaultDiscountPercentage", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? DefaultDiscountPercentage { get; set; }

	/// <summary>
	///     Buyer reference of the contact.
	/// </summary>
	/// <value>Buyer reference of the contact.</value>
	[DataMember(Name = "buyerReference", EmitDefaultValue = false)]
	public string BuyerReference { get; set; }

	/// <summary>
	///     Defines whether the contact is a government agency (true) or not (false).
	/// </summary>
	/// <value>Defines whether the contact is a government agency (true) or not (false).</value>
	[DataMember(Name = "governmentAgency", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? GovernmentAgency { get; set; }

	/// <summary>
	///     Returns true if ModelContactUpdate instances are equal
	/// </summary>
	/// <param name="input">Instance of ModelContactUpdate to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(ModelContactUpdate input)
	{
		if (input == null)
		{
			return false;
		}

		return
			(
				Name == input.Name ||
				(Name != null &&
				 Name.Equals(input.Name))
			) &&
			(
				Status == input.Status ||
				(Status != null &&
				 Status.Equals(input.Status))
			) &&
			(
				CustomerNumber == input.CustomerNumber ||
				(CustomerNumber != null &&
				 CustomerNumber.Equals(input.CustomerNumber))
			) &&
			(
				Parent == input.Parent ||
				(Parent != null &&
				 Parent.Equals(input.Parent))
			) &&
			(
				Surename == input.Surename ||
				(Surename != null &&
				 Surename.Equals(input.Surename))
			) &&
			(
				Familyname == input.Familyname ||
				(Familyname != null &&
				 Familyname.Equals(input.Familyname))
			) &&
			(
				Titel == input.Titel ||
				(Titel != null &&
				 Titel.Equals(input.Titel))
			) &&
			(
				Category == input.Category ||
				(Category != null &&
				 Category.Equals(input.Category))
			) &&
			(
				Description == input.Description ||
				(Description != null &&
				 Description.Equals(input.Description))
			) &&
			(
				AcademicTitle == input.AcademicTitle ||
				(AcademicTitle != null &&
				 AcademicTitle.Equals(input.AcademicTitle))
			) &&
			(
				Gender == input.Gender ||
				(Gender != null &&
				 Gender.Equals(input.Gender))
			) &&
			(
				Name2 == input.Name2 ||
				(Name2 != null &&
				 Name2.Equals(input.Name2))
			) &&
			(
				Birthday == input.Birthday ||
				(Birthday != null &&
				 Birthday.Equals(input.Birthday))
			) &&
			(
				VatNumber == input.VatNumber ||
				(VatNumber != null &&
				 VatNumber.Equals(input.VatNumber))
			) &&
			(
				BankAccount == input.BankAccount ||
				(BankAccount != null &&
				 BankAccount.Equals(input.BankAccount))
			) &&
			(
				BankNumber == input.BankNumber ||
				(BankNumber != null &&
				 BankNumber.Equals(input.BankNumber))
			) &&
			(
				DefaultCashbackTime == input.DefaultCashbackTime ||
				(DefaultCashbackTime != null &&
				 DefaultCashbackTime.Equals(input.DefaultCashbackTime))
			) &&
			(
				DefaultCashbackPercent == input.DefaultCashbackPercent ||
				(DefaultCashbackPercent != null &&
				 DefaultCashbackPercent.Equals(input.DefaultCashbackPercent))
			) &&
			(
				DefaultTimeToPay == input.DefaultTimeToPay ||
				(DefaultTimeToPay != null &&
				 DefaultTimeToPay.Equals(input.DefaultTimeToPay))
			) &&
			(
				TaxNumber == input.TaxNumber ||
				(TaxNumber != null &&
				 TaxNumber.Equals(input.TaxNumber))
			) &&
			(
				TaxOffice == input.TaxOffice ||
				(TaxOffice != null &&
				 TaxOffice.Equals(input.TaxOffice))
			) &&
			(
				ExemptVat == input.ExemptVat ||
				(ExemptVat != null &&
				 ExemptVat.Equals(input.ExemptVat))
			) &&
			(
				TaxType == input.TaxType ||
				(TaxType != null &&
				 TaxType.Equals(input.TaxType))
			) &&
			(
				TaxSet == input.TaxSet ||
				(TaxSet != null &&
				 TaxSet.Equals(input.TaxSet))
			) &&
			(
				DefaultDiscountAmount == input.DefaultDiscountAmount ||
				(DefaultDiscountAmount != null &&
				 DefaultDiscountAmount.Equals(input.DefaultDiscountAmount))
			) &&
			(
				DefaultDiscountPercentage == input.DefaultDiscountPercentage ||
				(DefaultDiscountPercentage != null &&
				 DefaultDiscountPercentage.Equals(input.DefaultDiscountPercentage))
			) &&
			(
				BuyerReference == input.BuyerReference ||
				(BuyerReference != null &&
				 BuyerReference.Equals(input.BuyerReference))
			) &&
			(
				GovernmentAgency == input.GovernmentAgency ||
				(GovernmentAgency != null &&
				 GovernmentAgency.Equals(input.GovernmentAgency))
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
		sb.Append("class ModelContactUpdate {\n");
		sb.Append("  Name: ").Append(Name).Append("\n");
		sb.Append("  Status: ").Append(Status).Append("\n");
		sb.Append("  CustomerNumber: ").Append(CustomerNumber).Append("\n");
		sb.Append("  Parent: ").Append(Parent).Append("\n");
		sb.Append("  Surename: ").Append(Surename).Append("\n");
		sb.Append("  Familyname: ").Append(Familyname).Append("\n");
		sb.Append("  Titel: ").Append(Titel).Append("\n");
		sb.Append("  Category: ").Append(Category).Append("\n");
		sb.Append("  Description: ").Append(Description).Append("\n");
		sb.Append("  AcademicTitle: ").Append(AcademicTitle).Append("\n");
		sb.Append("  Gender: ").Append(Gender).Append("\n");
		sb.Append("  Name2: ").Append(Name2).Append("\n");
		sb.Append("  Birthday: ").Append(Birthday).Append("\n");
		sb.Append("  VatNumber: ").Append(VatNumber).Append("\n");
		sb.Append("  BankAccount: ").Append(BankAccount).Append("\n");
		sb.Append("  BankNumber: ").Append(BankNumber).Append("\n");
		sb.Append("  DefaultCashbackTime: ").Append(DefaultCashbackTime).Append("\n");
		sb.Append("  DefaultCashbackPercent: ").Append(DefaultCashbackPercent).Append("\n");
		sb.Append("  DefaultTimeToPay: ").Append(DefaultTimeToPay).Append("\n");
		sb.Append("  TaxNumber: ").Append(TaxNumber).Append("\n");
		sb.Append("  TaxOffice: ").Append(TaxOffice).Append("\n");
		sb.Append("  ExemptVat: ").Append(ExemptVat).Append("\n");
		sb.Append("  TaxType: ").Append(TaxType).Append("\n");
		sb.Append("  TaxSet: ").Append(TaxSet).Append("\n");
		sb.Append("  DefaultDiscountAmount: ").Append(DefaultDiscountAmount).Append("\n");
		sb.Append("  DefaultDiscountPercentage: ").Append(DefaultDiscountPercentage).Append("\n");
		sb.Append("  BuyerReference: ").Append(BuyerReference).Append("\n");
		sb.Append("  GovernmentAgency: ").Append(GovernmentAgency).Append("\n");
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
		return Equals(input as ModelContactUpdate);
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
			if (Name != null)
			{
				hashCode = hashCode * 59 + Name.GetHashCode();
			}

			if (Status != null)
			{
				hashCode = hashCode * 59 + Status.GetHashCode();
			}

			if (CustomerNumber != null)
			{
				hashCode = hashCode * 59 + CustomerNumber.GetHashCode();
			}

			if (Parent != null)
			{
				hashCode = hashCode * 59 + Parent.GetHashCode();
			}

			if (Surename != null)
			{
				hashCode = hashCode * 59 + Surename.GetHashCode();
			}

			if (Familyname != null)
			{
				hashCode = hashCode * 59 + Familyname.GetHashCode();
			}

			if (Titel != null)
			{
				hashCode = hashCode * 59 + Titel.GetHashCode();
			}

			if (Category != null)
			{
				hashCode = hashCode * 59 + Category.GetHashCode();
			}

			if (Description != null)
			{
				hashCode = hashCode * 59 + Description.GetHashCode();
			}

			if (AcademicTitle != null)
			{
				hashCode = hashCode * 59 + AcademicTitle.GetHashCode();
			}

			if (Gender != null)
			{
				hashCode = hashCode * 59 + Gender.GetHashCode();
			}

			if (Name2 != null)
			{
				hashCode = hashCode * 59 + Name2.GetHashCode();
			}

			if (Birthday != null)
			{
				hashCode = hashCode * 59 + Birthday.GetHashCode();
			}

			if (VatNumber != null)
			{
				hashCode = hashCode * 59 + VatNumber.GetHashCode();
			}

			if (BankAccount != null)
			{
				hashCode = hashCode * 59 + BankAccount.GetHashCode();
			}

			if (BankNumber != null)
			{
				hashCode = hashCode * 59 + BankNumber.GetHashCode();
			}

			if (DefaultCashbackTime != null)
			{
				hashCode = hashCode * 59 + DefaultCashbackTime.GetHashCode();
			}

			if (DefaultCashbackPercent != null)
			{
				hashCode = hashCode * 59 + DefaultCashbackPercent.GetHashCode();
			}

			if (DefaultTimeToPay != null)
			{
				hashCode = hashCode * 59 + DefaultTimeToPay.GetHashCode();
			}

			if (TaxNumber != null)
			{
				hashCode = hashCode * 59 + TaxNumber.GetHashCode();
			}

			if (TaxOffice != null)
			{
				hashCode = hashCode * 59 + TaxOffice.GetHashCode();
			}

			if (ExemptVat != null)
			{
				hashCode = hashCode * 59 + ExemptVat.GetHashCode();
			}

			if (TaxType != null)
			{
				hashCode = hashCode * 59 + TaxType.GetHashCode();
			}

			if (TaxSet != null)
			{
				hashCode = hashCode * 59 + TaxSet.GetHashCode();
			}

			if (DefaultDiscountAmount != null)
			{
				hashCode = hashCode * 59 + DefaultDiscountAmount.GetHashCode();
			}

			if (DefaultDiscountPercentage != null)
			{
				hashCode = hashCode * 59 + DefaultDiscountPercentage.GetHashCode();
			}

			if (BuyerReference != null)
			{
				hashCode = hashCode * 59 + BuyerReference.GetHashCode();
			}

			if (GovernmentAgency != null)
			{
				hashCode = hashCode * 59 + GovernmentAgency.GetHashCode();
			}

			return hashCode;
		}
	}
}
