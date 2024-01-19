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

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     Voucher position model
/// </summary>
[DataContract]
public class ModelVoucherPosResponse : IEquatable<ModelVoucherPosResponse>, IValidatableObject
{
	/// <summary>
	///     Initializes a new instance of the <see cref="ModelVoucherPosResponse" /> class.
	/// </summary>
	/// <param name="sevClient">sevClient.</param>
	/// <param name="voucher">voucher (required).</param>
	/// <param name="accountingType">accountingType (required).</param>
	/// <param name="estimatedAccountingType">estimatedAccountingType.</param>
	/// <param name="taxRate">Tax rate of the voucher position. (required).</param>
	/// <param name="net">
	///     Determines whether &#x27;sumNet&#x27; or &#x27;sumGross&#x27; is regarded.&lt;br&gt;       If both
	///     are not given, &#x27;sum&#x27; is regarded and treated as net or gross depending on &#x27;net&#x27;. (required).
	/// </param>
	/// <param name="isAsset">Determines whether position is regarded as an asset which can be depreciated..</param>
	/// <param name="sumNet">
	///     Net sum of the voucher position.&lt;br&gt;      Only regarded if &#x27;net&#x27; is &#x27;true
	///     &#x27;, otherwise its readOnly. (required).
	/// </param>
	/// <param name="sumGross">
	///     Gross sum of the voucher position.&lt;br&gt;      Only regarded if &#x27;net&#x27; is &#x27;
	///     false&#x27;, otherwise its readOnly. (required).
	/// </param>
	/// <param name="comment">Comment for the voucher position..</param>
	public ModelVoucherPosResponse(ModelVoucherPosResponseSevClient sevClient = default,
		ModelVoucherPosResponseVoucher voucher = default,
		ModelVoucherPosResponseAccountingType accountingType = default,
		ModelVoucherPosResponseEstimatedAccountingType estimatedAccountingType = default, string taxRate = default,
		bool? net = default, bool? isAsset = default, string sumNet = default, string sumGross = default,
		string comment = default)
	{
		// to ensure "voucher" is required (not null)
		if (voucher == null)
		{
			throw new InvalidDataException(
				"voucher is a required property for ModelVoucherPosResponse and cannot be null");
		}

		Voucher = voucher;
		// to ensure "accountingType" is required (not null)
		if (accountingType == null)
		{
			throw new InvalidDataException(
				"accountingType is a required property for ModelVoucherPosResponse and cannot be null");
		}

		AccountingType = accountingType;
		// to ensure "taxRate" is required (not null)
		if (taxRate == null)
		{
			throw new InvalidDataException(
				"taxRate is a required property for ModelVoucherPosResponse and cannot be null");
		}

		TaxRate = taxRate;
		// to ensure "net" is required (not null)
		if (net == null)
		{
			throw new InvalidDataException("net is a required property for ModelVoucherPosResponse and cannot be null");
		}

		Net = net;
		// to ensure "sumNet" is required (not null)
		if (sumNet == null)
		{
			throw new InvalidDataException(
				"sumNet is a required property for ModelVoucherPosResponse and cannot be null");
		}

		SumNet = sumNet;
		// to ensure "sumGross" is required (not null)
		if (sumGross == null)
		{
			throw new InvalidDataException(
				"sumGross is a required property for ModelVoucherPosResponse and cannot be null");
		}

		SumGross = sumGross;
		SevClient = sevClient;
		EstimatedAccountingType = estimatedAccountingType;
		IsAsset = isAsset;
		Comment = comment;
	}

	/// <summary>
	///     The voucher position id
	/// </summary>
	/// <value>The voucher position id</value>
	[DataMember(Name = "id", EmitDefaultValue = false)]
	public string Id { get; private set; }

	/// <summary>
	///     The voucher position object name
	/// </summary>
	/// <value>The voucher position object name</value>
	[DataMember(Name = "objectName", EmitDefaultValue = false)]
	public string ObjectName { get; private set; }

	/// <summary>
	///     Date of voucher position creation
	/// </summary>
	/// <value>Date of voucher position creation</value>
	[DataMember(Name = "create", EmitDefaultValue = false)]
	public string Create { get; private set; }

	/// <summary>
	///     Date of last voucher position update
	/// </summary>
	/// <value>Date of last voucher position update</value>
	[DataMember(Name = "update", EmitDefaultValue = false)]
	public string Update { get; private set; }

	/// <summary>
	///     Gets or Sets SevClientReference
	/// </summary>
	[DataMember(Name = "sevClient", EmitDefaultValue = false)]
	public ModelVoucherPosResponseSevClient SevClient { get; set; }

	/// <summary>
	///     Gets or Sets Voucher
	/// </summary>
	[DataMember(Name = "voucher", EmitDefaultValue = false)]
	public ModelVoucherPosResponseVoucher Voucher { get; set; }

	/// <summary>
	///     Gets or Sets AccountingTypeReference
	/// </summary>
	[DataMember(Name = "accountingType", EmitDefaultValue = false)]
	public ModelVoucherPosResponseAccountingType AccountingType { get; set; }

	/// <summary>
	///     Gets or Sets EstimatedAccountingType
	/// </summary>
	[DataMember(Name = "estimatedAccountingType", EmitDefaultValue = false)]
	public ModelVoucherPosResponseEstimatedAccountingType EstimatedAccountingType { get; set; }

	/// <summary>
	///     Tax rate of the voucher position.
	/// </summary>
	/// <value>Tax rate of the voucher position.</value>
	[DataMember(Name = "taxRate", EmitDefaultValue = false)]
	public string TaxRate { get; set; }

	/// <summary>
	///     Determines whether &#x27;sumNet&#x27; or &#x27;sumGross&#x27; is regarded.&lt;br&gt;       If both are not given,
	///     &#x27;sum&#x27; is regarded and treated as net or gross depending on &#x27;net&#x27;.
	/// </summary>
	/// <value>
	///     Determines whether &#x27;sumNet&#x27; or &#x27;sumGross&#x27; is regarded.&lt;br&gt;       If both are not
	///     given, &#x27;sum&#x27; is regarded and treated as net or gross depending on &#x27;net&#x27;.
	/// </value>
	[DataMember(Name = "net", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? Net { get; set; }

	/// <summary>
	///     Determines whether position is regarded as an asset which can be depreciated.
	/// </summary>
	/// <value>Determines whether position is regarded as an asset which can be depreciated.</value>
	[DataMember(Name = "isAsset", EmitDefaultValue = false)]
	[JsonConverter(typeof(BooleanJsonConverter))]
	public bool? IsAsset { get; set; }

	/// <summary>
	///     Net sum of the voucher position.&lt;br&gt;      Only regarded if &#x27;net&#x27; is &#x27;true&#x27;, otherwise its
	///     readOnly.
	/// </summary>
	/// <value>
	///     Net sum of the voucher position.&lt;br&gt;      Only regarded if &#x27;net&#x27; is &#x27;true&#x27;, otherwise
	///     its readOnly.
	/// </value>
	[DataMember(Name = "sumNet", EmitDefaultValue = false)]
	public string SumNet { get; set; }

	/// <summary>
	///     Tax sum of the voucher position.
	/// </summary>
	/// <value>Tax sum of the voucher position.</value>
	[DataMember(Name = "sumTax", EmitDefaultValue = false)]
	public string SumTax { get; private set; }

	/// <summary>
	///     Gross sum of the voucher position.&lt;br&gt;      Only regarded if &#x27;net&#x27; is &#x27;false&#x27;, otherwise
	///     its readOnly.
	/// </summary>
	/// <value>
	///     Gross sum of the voucher position.&lt;br&gt;      Only regarded if &#x27;net&#x27; is &#x27;false&#x27;,
	///     otherwise its readOnly.
	/// </value>
	[DataMember(Name = "sumGross", EmitDefaultValue = false)]
	public string SumGross { get; set; }

	/// <summary>
	///     Net accounting sum. Is equal to sumNet.
	/// </summary>
	/// <value>Net accounting sum. Is equal to sumNet.</value>
	[DataMember(Name = "sumNetAccounting", EmitDefaultValue = false)]
	public string SumNetAccounting { get; private set; }

	/// <summary>
	///     Tax accounting sum. Is equal to sumTax.
	/// </summary>
	/// <value>Tax accounting sum. Is equal to sumTax.</value>
	[DataMember(Name = "sumTaxAccounting", EmitDefaultValue = false)]
	public string SumTaxAccounting { get; private set; }

	/// <summary>
	///     Gross accounting sum. Is equal to sumGross.
	/// </summary>
	/// <value>Gross accounting sum. Is equal to sumGross.</value>
	[DataMember(Name = "sumGrossAccounting", EmitDefaultValue = false)]
	public string SumGrossAccounting { get; private set; }

	/// <summary>
	///     Comment for the voucher position.
	/// </summary>
	/// <value>Comment for the voucher position.</value>
	[DataMember(Name = "comment", EmitDefaultValue = false)]
	public string Comment { get; set; }

	/// <summary>
	///     Returns true if ModelVoucherPosResponse instances are equal
	/// </summary>
	/// <param name="input">Instance of ModelVoucherPosResponse to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(ModelVoucherPosResponse input)
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
				SevClient == input.SevClient ||
				(SevClient != null &&
				 SevClient.Equals(input.SevClient))
			) &&
			(
				Voucher == input.Voucher ||
				(Voucher != null &&
				 Voucher.Equals(input.Voucher))
			) &&
			(
				AccountingType == input.AccountingType ||
				(AccountingType != null &&
				 AccountingType.Equals(input.AccountingType))
			) &&
			(
				EstimatedAccountingType == input.EstimatedAccountingType ||
				(EstimatedAccountingType != null &&
				 EstimatedAccountingType.Equals(input.EstimatedAccountingType))
			) &&
			(
				TaxRate == input.TaxRate ||
				(TaxRate != null &&
				 TaxRate.Equals(input.TaxRate))
			) &&
			(
				Net == input.Net ||
				(Net != null &&
				 Net.Equals(input.Net))
			) &&
			(
				IsAsset == input.IsAsset ||
				(IsAsset != null &&
				 IsAsset.Equals(input.IsAsset))
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
				SumNetAccounting == input.SumNetAccounting ||
				(SumNetAccounting != null &&
				 SumNetAccounting.Equals(input.SumNetAccounting))
			) &&
			(
				SumTaxAccounting == input.SumTaxAccounting ||
				(SumTaxAccounting != null &&
				 SumTaxAccounting.Equals(input.SumTaxAccounting))
			) &&
			(
				SumGrossAccounting == input.SumGrossAccounting ||
				(SumGrossAccounting != null &&
				 SumGrossAccounting.Equals(input.SumGrossAccounting))
			) &&
			(
				Comment == input.Comment ||
				(Comment != null &&
				 Comment.Equals(input.Comment))
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
		sb.Append("class ModelVoucherPosResponse {\n");
		sb.Append("  Id: ").Append(Id).Append("\n");
		sb.Append("  ObjectName: ").Append(ObjectName).Append("\n");
		sb.Append("  Create: ").Append(Create).Append("\n");
		sb.Append("  Update: ").Append(Update).Append("\n");
		sb.Append("  SevClientReference: ").Append(SevClient).Append("\n");
		sb.Append("  Voucher: ").Append(Voucher).Append("\n");
		sb.Append("  AccountingTypeReference: ").Append(AccountingType).Append("\n");
		sb.Append("  EstimatedAccountingType: ").Append(EstimatedAccountingType).Append("\n");
		sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
		sb.Append("  Net: ").Append(Net).Append("\n");
		sb.Append("  IsAsset: ").Append(IsAsset).Append("\n");
		sb.Append("  SumNet: ").Append(SumNet).Append("\n");
		sb.Append("  SumTax: ").Append(SumTax).Append("\n");
		sb.Append("  SumGross: ").Append(SumGross).Append("\n");
		sb.Append("  SumNetAccounting: ").Append(SumNetAccounting).Append("\n");
		sb.Append("  SumTaxAccounting: ").Append(SumTaxAccounting).Append("\n");
		sb.Append("  SumGrossAccounting: ").Append(SumGrossAccounting).Append("\n");
		sb.Append("  Comment: ").Append(Comment).Append("\n");
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
		return Equals(input as ModelVoucherPosResponse);
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

			if (SevClient != null)
			{
				hashCode = hashCode * 59 + SevClient.GetHashCode();
			}

			if (Voucher != null)
			{
				hashCode = hashCode * 59 + Voucher.GetHashCode();
			}

			if (AccountingType != null)
			{
				hashCode = hashCode * 59 + AccountingType.GetHashCode();
			}

			if (EstimatedAccountingType != null)
			{
				hashCode = hashCode * 59 + EstimatedAccountingType.GetHashCode();
			}

			if (TaxRate != null)
			{
				hashCode = hashCode * 59 + TaxRate.GetHashCode();
			}

			if (Net != null)
			{
				hashCode = hashCode * 59 + Net.GetHashCode();
			}

			if (IsAsset != null)
			{
				hashCode = hashCode * 59 + IsAsset.GetHashCode();
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

			if (SumNetAccounting != null)
			{
				hashCode = hashCode * 59 + SumNetAccounting.GetHashCode();
			}

			if (SumTaxAccounting != null)
			{
				hashCode = hashCode * 59 + SumTaxAccounting.GetHashCode();
			}

			if (SumGrossAccounting != null)
			{
				hashCode = hashCode * 59 + SumGrossAccounting.GetHashCode();
			}

			if (Comment != null)
			{
				hashCode = hashCode * 59 + Comment.GetHashCode();
			}

			return hashCode;
		}
	}
}
